///
/// DeviceStatisticsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

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
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// Device statistics are collected for each inventory object with at least one measurement, event or alarm. There are no additional checks if the inventory object is marked as device using the <c>c8y_IsDevice</c> fragment. When the first measurement, event or alarm is created for a specific inventory object, Cumulocity IoT is always considering this as a device and starts counting. <br />
	/// Device statistics are counted with daily and monthy rate. All requests are considered when counting device statistics, no matter which processing mode is used. <br />
	/// The following requests are counted: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>Alarm creation and update <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Event creation and update <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Measurement creation <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Bulk measurement creation is counted as multiple requests <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Bulk alarm status update is counted as multiple requests <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>MQTT and SmartREST requests with multiple rows are counted as multiple requests <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// <br /> Frequently asked questions <br />
	/// <br /> Are operations on device firmware counted? <br />
	/// No, device configuration and firmware update operate on inventory objects, hence they are not counted. <br />
	/// <br /> Are requests done by the UI applications, for example, when browsing device details, counted? <br />
	/// No, viewing device details performs only GET requests which are not counted. <br />
	/// <br /> Is the clear alarm operation done from the UI counted? <br />
	/// Yes, a clear alarm operation in fact performs an alarm update operation and it will be counted as device request. <br />
	/// <br /> Is there any operation performed on the device which is counted? <br />
	/// Yes, retrieving device logs requires from the device to create an event and attach a binary with logs to it. Those are two separate requests and both are counted. <br />
	/// <br /> When I have a device with children are the requests counted always to the root device or separately for each child? <br />
	/// Separately for each child. <br />
	/// </summary>
	///
	#nullable enable
	public class DeviceStatisticsApi : AdaptableApi, IDeviceStatisticsApi
	{
		public DeviceStatisticsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<DeviceStatisticsCollection?> GetMonthlyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/statistics/device/{tenantId}/monthly/{date}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("deviceId", deviceId);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<DeviceStatisticsCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<DeviceStatisticsCollection?> GetDailyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/statistics/device/{tenantId}/daily/{date}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("deviceId", deviceId);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<DeviceStatisticsCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
