///
/// MeasurementsApi.cs
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
	/// Measurements are produced by reading sensor values. In some cases, this data is read in static intervals and sent to the platform (for example, temperature sensors or electrical meters). In other cases, the data is read on demand or at irregular intervals (for example, health devices such as weight scales). Regardless what kind of protocol the device supports, the agent is responsible for converting it into a "push" protocol by uploading data to Cumulocity IoT.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class MeasurementsApi : AdaptableApi 
	{
		public MeasurementsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve all measurements<br/>
		/// Retrieve all measurements on your tenant, or a specific subset based on queries.  In case of executing [range queries](https://en.wikipedia.org/wiki/Range_query_(database)) between an upper and lower boundary, for example, querying using `dateFrom`–`dateTo`, the oldest registered measurements are returned first. It is possible to change the order using the query parameter `revert=true`.  For large measurement collections, querying older records without filters can be slow as the server needs to scan from the beginning of the input results set before beginning to return the results. For cases when older measurements should be retrieved, it is recommended to narrow the scope by using range queries based on the time stamp reported by a device. The scope of query can also be reduced significantly when a source device is provided.  Review [Measurements Specifics](#tag/Measurements-Specifics) for details about data streaming and response formats.  <section><h5>Required roles</h5> ROLE_MEASUREMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all measurements are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the measurement.</param>
		/// <param name="dateTo">End date or date and time of the measurement.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="revert">If you are using a range query (that is, at least one of the `dateFrom` or `dateTo` parameters is included in the request), then setting `revert=true` will sort the results by the latest measurements first. By default, the results are sorted by the oldest measurements first. </param>
		/// <param name="source">The managed object ID to which the measurement is associated.</param>
		/// <param name="type">The type of measurement to search for.</param>
		/// <param name="valueFragmentSeries">The specific series to search for.</param>
		/// <param name="valueFragmentType">A characteristic which identifies the measurement.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		public async Task<MeasurementCollection?> GetMeasurements(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, string? valueFragmentSeries = null, string? valueFragmentType = null, bool? withTotalElements = null, bool? withTotalPages = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"dateFrom", dateFrom},
				{"dateTo", dateTo},
				{"pageSize", pageSize},
				{"revert", revert},
				{"source", source},
				{"type", type},
				{"valueFragmentSeries", valueFragmentSeries},
				{"valueFragmentType", valueFragmentType},
				{"withTotalElements", withTotalElements},
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
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<MeasurementCollection?>(responseStream);
		}
		
		/// <summary>
		/// Create a measurement<br/>
		/// A measurement must be associated with a source (managed object) identified by ID, and must specify the type of measurement and the time when it was measured by the device (for example, a thermometer).  Each measurement fragment is an object (for example, `c8y_Steam`) containing the actual measurements as properties. The property name represents the name of the measurement (for example, `Temperature`) and it contains two properties:  *   `value` - The value of the individual measurement. The maximum precision for floating point numbers is 64-bit IEEE 754. For integers it's a 64-bit two's complement integer. *   `unit` - The unit of the measurements.  Review the [System of units](#section/System-of-units) section for details about the conversions of units. Also review the [Naming conventions of fragments](https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments) in the Concepts guide.  The example below uses `c8y_Steam` in the request body to illustrate a fragment for recording temperature measurements.  > **⚠️ Important:** Property names used for fragment and series must not contain whitespaces nor the special characters `. , * [ ] ( ) @ $`. This is required to ensure a correct processing and visualization of measurement series on UI graphs.  ### Create multiple measurements  It is also possible to create multiple measurements at once by sending a `measurements` array containing all the measurements to be created. The content type must be `application/vnd.com.nsn.cumulocity.measurementcollection+json`.  > **&#9432; Info:** For more details about fragments with specific meanings, review the sections [Device management library](#section/Device-management-library) and [Sensor library](#section/Sensor-library).  <section><h5>Required roles</h5> ROLE_MEASUREMENT_ADMIN <b>OR</b> owner of the source <b>OR</b> MEASUREMENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A measurement was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		public async Task<Measurement?> CreateMeasurement(Measurement body)
		{
			var jsonNode = ToJsonNode<Measurement>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("source", "self");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.measurement+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.measurement+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Measurement?>(responseStream);
		}
		
		/// <summary>
		/// Create a measurement<br/>
		/// A measurement must be associated with a source (managed object) identified by ID, and must specify the type of measurement and the time when it was measured by the device (for example, a thermometer).  Each measurement fragment is an object (for example, `c8y_Steam`) containing the actual measurements as properties. The property name represents the name of the measurement (for example, `Temperature`) and it contains two properties:  *   `value` - The value of the individual measurement. The maximum precision for floating point numbers is 64-bit IEEE 754. For integers it's a 64-bit two's complement integer. *   `unit` - The unit of the measurements.  Review the [System of units](#section/System-of-units) section for details about the conversions of units. Also review the [Naming conventions of fragments](https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments) in the Concepts guide.  The example below uses `c8y_Steam` in the request body to illustrate a fragment for recording temperature measurements.  > **⚠️ Important:** Property names used for fragment and series must not contain whitespaces nor the special characters `. , * [ ] ( ) @ $`. This is required to ensure a correct processing and visualization of measurement series on UI graphs.  ### Create multiple measurements  It is also possible to create multiple measurements at once by sending a `measurements` array containing all the measurements to be created. The content type must be `application/vnd.com.nsn.cumulocity.measurementcollection+json`.  > **&#9432; Info:** For more details about fragments with specific meanings, review the sections [Device management library](#section/Device-management-library) and [Sensor library](#section/Sensor-library).  <section><h5>Required roles</h5> ROLE_MEASUREMENT_ADMIN <b>OR</b> owner of the source <b>OR</b> MEASUREMENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A measurement was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		public async Task<MeasurementCollection?> CreateMeasurement(MeasurementCollection body)
		{
			var jsonNode = ToJsonNode<MeasurementCollection>(body);
			jsonNode?.RemoveFromNode("next");
			jsonNode?.RemoveFromNode("prev");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("statistics");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.measurementcollection+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.measurementcollection+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<MeasurementCollection?>(responseStream);
		}
		
		/// <summary>
		/// Remove measurement collections<br/>
		/// Remove measurement collections specified by query parameters.  DELETE requests are not synchronous. The response could be returned before the delete request has been completed. This may happen especially when there are a lot of measurements to be deleted.  > **⚠️ Important:** Note that it is possible to call this endpoint without providing any parameter - it may result in deleting all measurements and it is not recommended.  <section><h5>Required roles</h5> ROLE_MEASUREMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A collection of measurements was removed.</description>
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
		/// <param name="dateFrom">Start date or date and time of the measurement.</param>
		/// <param name="dateTo">End date or date and time of the measurement.</param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state.</param>
		/// <param name="source">The managed object ID to which the measurement is associated.</param>
		/// <param name="type">The type of measurement to search for.</param>
		public async Task<System.IO.Stream> DeleteMeasurements(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"dateFrom", dateFrom},
				{"dateTo", dateTo},
				{"fragmentType", fragmentType},
				{"source", source},
				{"type", type}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <summary>
		/// Retrieve a specific measurement<br/>
		/// Retrieve a specific measurement by a given ID.  <section><h5>Required roles</h5> ROLE_MEASUREMENT_READ <b>OR</b> owner of the source <b>OR</b> MEASUREMENT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the measurement is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Measurement not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the measurement.</param>
		/// <returns></returns>
		public async Task<Measurement?> GetMeasurement(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements/{id}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Measurement?>(responseStream);
		}
		
		/// <summary>
		/// Remove a specific measurement<br/>
		/// Remove a specific measurement by a given ID.  <section><h5>Required roles</h5> ROLE_MEASUREMENT_ADMIN <b>OR</b> owner of the source <b>OR</b> MEASUREMENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A measurement was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Measurement not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the measurement.</param>
		public async Task<System.IO.Stream> DeleteMeasurement(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements/{id}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <summary>
		/// Retrieve a list of series and their values<br/>
		/// Retrieve a list of series (all or only those matching the specified names) and their values within a given period of a specific managed object (source).<br> A series is any fragment in measurement that contains a `value` property.  It is possible to fetch aggregated results using the `aggregationType` parameter. If the aggregation is not specified, the result will contain no more than 5000 values.  > **⚠️ Important:** For the aggregation to be done correctly, a device shall always use the same time zone when it sends dates.  <section><h5>Required roles</h5> ROLE_MEASUREMENT_READ <b>OR</b> owner of the source <b>OR</b> MEASUREMENT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the series are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="aggregationType">Fetch aggregated results as specified.</param>
		/// <param name="dateFrom">Start date or date and time of the measurement.</param>
		/// <param name="dateTo">End date or date and time of the measurement.</param>
		/// <param name="revert">If you are using a range query (that is, at least one of the `dateFrom` or `dateTo` parameters is included in the request), then setting `revert=true` will sort the results by the latest measurements first. By default, the results are sorted by the oldest measurements first. </param>
		/// <param name="series">The specific series to search for.</param>
		/// <param name="source">The managed object ID to which the measurement is associated.</param>
		/// <returns></returns>
		public async Task<MeasurementSeries?> GetMeasurementSeries(string? aggregationType = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? revert = null, List<string>? series = null, string? source = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}measurement/measurements/series"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"aggregationType", aggregationType},
				{"dateFrom", dateFrom},
				{"dateTo", dateTo},
				{"revert", revert},
				{"series", series},
				{"source", source}
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
			return await JsonSerializer.DeserializeAsync<MeasurementSeries?>(responseStream);
		}
	}
	#nullable disable
}
