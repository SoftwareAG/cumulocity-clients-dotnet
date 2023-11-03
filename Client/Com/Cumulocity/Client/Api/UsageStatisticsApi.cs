//
// UsageStatisticsApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// Days are counted according to server timezone, so be aware that the tenant usage statistics displaying/filtering may not work correctly when the client is not in the same timezone as the server. However, it is possible to send a request with a time range (using the query parameters <c>dateFrom</c> and <c>dateTo</c>) in zoned format (for example, <c>2020-10-26T03:00:00%2B01:00</c>). Statistics from past days are stored with daily aggregations, which means that for a specific day you get either the statistics for the whole day or none at all. <br />
/// <br /> Request counting in SmartREST and MQTT <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>SmartREST: Each row in a SmartREST request is transformed into a separate HTTP request. For example, if one SmartREST request contains 10 rows, then 10 separate calls are executed, meaning that request count is increased by 10. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>MQTT: Each row/line counts as a separate request. Creating custom template counts as a single request. <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> REST specific counting details <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>All counters increase also when the request is invalid, for example, wrong payload or missing permissions. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Bulk measurements creation and bulk alarm status update are counted as a single "requestCount"/"deviceRequestCount" and multiple inbound data transfer count. <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> SmartREST 1.0 specific counting details <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>Invalid SmartREST requests are not counted, for example, when the template doesn't exist. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>A new template registration is treated as two separate requests. Create a new inventory object which increases "requestCount", "deviceRequestCount" and "inventoriesCreatedCount". There is also a second request which binds the template with X-ID, this increases "requestCount" and "deviceRequestCount". <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Each row in a SmartREST request is transformed into a separate HTTP request. For example, if one SmartREST request contains 10 rows, then 10 separate calls are executed, meaning that both "requestCount" and "deviceRequestCount" are increased by 10. <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> MQTT specific counting details <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>Invalid requests are counted, for example, when sending a message with a wrong template ID. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Device creation request and automatic device creation are counted. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Each row/line counts as a separate request. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Creating a custom template counts as a single request, no matter how many rows are sent in the request. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>There is one special SmartREST 2.0 template (402 Create location update event with device update) which is doing two things in one call, that is, create a new location event and update the location of the device. It is counted as two separate requests. <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> JSON via MQTT specific counting details <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>Invalid requests are counted, for example, when the message payload is invalid. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Bulk creation requests are counted as a single "requestCount"/"deviceRequestCount" and multiple inbound data transfer count. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Bulk creation requests with a wrong payload are not counted for inbound data transfer count. <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> Total inbound data transfer <br />
/// Inbound data transfer refers to the total number of inbound requests performed to transfer data into the Cumulocity IoT platform. This includes sensor readings, alarms, events, commands and alike that are transferred between devices and the Cumulocity IoT platform using the REST and/or MQTT interfaces. Such an inbound request could also originate from a custom microservice, website or any other client. <br />
/// See the table below for more information on how the counters are increased. Additionally, it shows how inbound data transfers are handled for both MQTT and REST: <br />
/// |Type of transfer|MQTT counter information|REST counter information||:---------------|:-----------------------|:-----------------------||Creation of an alarm in one request|One alarm creation is counted.|One alarm creation is counted via REST.||Update of an alarm (for example, status change)|One alarm update is counted.|One alarm update is counted via REST.||Creation of multiple alarms in one request|Each alarm creation in a single MQTT request will be counted.|Not supported by C8Y (REST does not support creating multiple alarms in one call).||Update of multiple alarms (for example, status change) in one request|Each alarm update in a single MQTT request will be counted.|Each alarm that matches the filter is counted as an alarm update (causing multiple updates).||Creation of an event in one request|One event creation is counted.|One event creation is counted.||Update of an event (for example, text change)|One event update is counted.|One event update is counted.||Creation of multiple events in one request|Each event creation in a single MQTT request will be counted.|Not supported by C8Y (REST does not support creating multiple events in one call).||Update of multiple events (for example, text change) in one request|Each event update in a single MQTT request will be counted.|Not supported by C8Y (REST does not support updating multiple events in one call).||Creation of a measurement in one request|One measurement creation is counted. |One measurement creation is counted.||Creation of multiple measurements in one request|Each measurement creation in a single MQTT request will be counted. Example: If MQTT is used to report 5 measurements, the measurementCreated counter will be incremented by five.|REST allows multiple measurements to be created by sending multiple measurements in one call. In this case, each measurement sent via REST is counted individually. The call itself is not counted. For example, if somebody sends 5 measurements via REST in one call, the corresponding counter will be increased by 5. Measurements with multiple series are counted as a singular measurement.||Creation of a managed object in one request|One managed object creation is counted.|One managed object creation is counted.||Update of one managed object (for example, status change)|One managed object update is counted.|One managed object update is counted.||Update of multiple managed objects in one request|Each managed object update in a single MQTT request will be counted.|Not supported by C8Y (REST does not support updating multiple managed objects in one call).||Creation/update of multiple alarms/measurements/events/inventories mixed in a single call.|Each MQTT line is processed separately. If it is a creation/update of an event/alarm/measurement/inventory, the corresponding counter is increased by one.|Not supported by the REST API.||Assign/unassign of child devices and child assets in one request|One managed object update is counted.|One managed object update is counted.| <br />
/// <br /> Microservice usage statistics <br />
/// The microservice usage statistics gathers information on the resource usage for tenants for each subscribed application which are collected on a daily base. <br />
/// The microservice usage's information is stored in the <c>resources</c> object. <br />
/// <br /> Frequently asked questions <br />
/// <br /> Which requests are counted as general "requestCount"? <br />
/// All requests which the platform receives are counted, including,for example, UI requests, microservices requests, device requests and agents requests. Only a few internal endpoints are not counted: <br />
/// <list type="bullet">
/// 	<item>
/// 		<description><c>/health</c> (and all endpoints including this URI fragment, like <c>/tenant/health</c>) <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/application/currentApplication</c> (and all subresources, like <c>/application/currentApplication/subscriptions</c>) <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/tenant/limit</c> <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/devicecontrol/deviceCredentials</c> <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/inventory/templates</c> (and all subresources) <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> My devices are not sending any data, but "requestCount" is increasing, and the total number is really big. Why is this happening? <br />
/// Not only device requests are counted. Every user interaction with UI applications generates some requests to the backend API. Additionally you may have subscribed standard or custom microservices, which also regularly send requests to the platform. <br />
/// Example: If you have four microservices and each microservice sends five requests per minute, this setup creates <c>4 * 5 * 60 * 24 = 28800</c> requests per day. Similar numbers arise if there are multiple users working with the given tenant UI concurrently. <br />
/// <br /> Which requests are counted as "deviceRequestCount"? <br />
/// All requests from "requestCount" except the following: <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>Tenant API requests <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Application API requests <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>User API requests <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Requests with the proper HTTP header <c>X-Cumulocity-Application-Key</c>, matching the application key of one of the applications used by a particular tenant <br />
/// 		</description>
/// 	</item>
/// </list>
/// The exclusion of the APIs in the list above means that requests to endpoints which start with the mentioned API prefixes are not counted. For example, for the Tenant API the following endpoints are not counted (the list is incomplete): <br />
/// <list type="bullet">
/// 	<item>
/// 		<description><c>/tenant/tenants</c> <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/tenant/currentTenant</c> <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/tenant/statistics</c> <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description><c>/tenant/options</c> <br />
/// 		</description>
/// 	</item>
/// </list>
/// ⓘ Info: Each microservice and web application must include the <c>X-Cumulocity-Application-Key</c> header in all requests.Otherwise such requests are counted as device requests which incorrectly affects the "deviceRequestCount" usage metric. <br />
/// </summary>
///
public sealed class UsageStatisticsApi : IUsageStatisticsApi
{
	private readonly HttpClient _httpClient;

	public UsageStatisticsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<TenantUsageStatisticsCollection?> GetTenantUsageStatisticsCollectionResource(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/tenant/statistics";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenantusagestatisticscollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TenantUsageStatisticsCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<SummaryTenantUsageStatistics?> GetTenantUsageStatistics(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? tenant = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/tenant/statistics/summary";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("tenant", tenant);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenantusagestatisticssummary+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<SummaryTenantUsageStatistics?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<List<SummaryAllTenantsUsageStatistics<TCustomProperties>>?> GetTenantsUsageStatistics<TCustomProperties>(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		const string resourcePath = "/tenant/statistics/allTenantsSummary";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<List<SummaryAllTenantsUsageStatistics<TCustomProperties>>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TenantUsageStatisticsFileCollection?> GetMetadata(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/tenant/statistics/files";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenantStatisticsfilecollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TenantUsageStatisticsFileCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<StatisticsFile?> GenerateStatisticsFile(RangeStatisticsFile body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<RangeStatisticsFile>();
		const string resourcePath = "/tenant/statistics/files";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.tenantstatisticsdate+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.tenantstatisticsdate+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenantstatisticsfile+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<StatisticsFile?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> GetStatisticsFile(string id, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/statistics/files/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/octet-stream");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> GetLatestStatisticsFile(System.DateTime month, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/statistics/files/latest/{HttpUtility.UrlEncode(month.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/octet-stream");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
}
