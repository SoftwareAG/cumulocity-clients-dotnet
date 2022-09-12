///
/// DeviceStatisticsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// Device statistics are collected for each inventory object with at least one measurement, event or alarm. There are no additional checks if the inventory object is marked as device using the `c8y_IsDevice` fragment. When the first measurement, event or alarm is created for a specific inventory object, Cumulocity IoT is always considering this as a device and starts counting.
	/// 
	/// Device statistics are counted with daily and monthy rate. All requests are considered when counting device statistics, no matter which processing mode is used.
	/// 
	/// The following requests are counted:
	/// 
	/// * Alarm creation and update
	/// * Event creation and update
	/// * Measurement creation
	/// * Bulk measurement creation is counted as multiple requests
	/// * Bulk alarm status update is counted as multiple requests
	/// * MQTT and SmartREST requests with multiple rows are counted as multiple requests
	/// 
	/// ### Frequently asked questions
	/// 
	/// #### Are operations on device firmware counted?
	/// 
	/// **No**, device configuration and firmware update operate on inventory objects, hence they are not counted.
	/// 
	/// #### Are requests done by the UI applications, for example, when browsing device details, counted?
	/// 
	/// **No**, viewing device details performs only GET requests which are not counted.
	/// 
	/// #### Is the clear alarm operation done from the UI counted?
	/// 
	/// **Yes**, a clear alarm operation in fact performs an alarm update operation and it will be counted as device request.
	/// 
	/// #### Is there any operation performed on the device which is counted?
	/// 
	/// **Yes**, retrieving device logs requires from the device to create an event and attach a binary with logs to it. Those are two separate requests and both are counted.
	/// 
	/// #### When I have a device with children are the requests counted always to the root device or separately for each child?
	/// 
	/// Separately for each child.
	/// 
	/// </summary>
	#nullable enable
	public class DeviceStatisticsApi : AdaptableApi 
	{
		public DeviceStatisticsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve monthly device statistics<br/>
		/// Retrieve monthly device statistics from a specific tenant (by a given ID).  <section><h5>Required roles</h5> ROLE_TENANT_STATISTICS_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the devices statistics are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="date">Date (format YYYY-MM-dd) of the queried month (the day value is ignored).</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="deviceId">The ID of the device to search for.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		public async Task<DeviceStatisticsCollection?> GetMonthlyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/statistics/device/{tenantId}/monthly/{date}"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"deviceId", deviceId},
				{"pageSize", pageSize},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<DeviceStatisticsCollection?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve daily device statistics<br/>
		/// Retrieve daily device statistics from a specific tenant (by a given ID).  <section><h5>Required roles</h5> ROLE_TENANT_STATISTICS_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the devices statistics are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="date">Date (format YYYY-MM-dd) of the queried day.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="deviceId">The ID of the device to search for.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		public async Task<DeviceStatisticsCollection?> GetDailyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/statistics/device/{tenantId}/daily/{date}"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"deviceId", deviceId},
				{"pageSize", pageSize},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<DeviceStatisticsCollection?>(responseStream);
		}
	}
	#nullable disable
}
