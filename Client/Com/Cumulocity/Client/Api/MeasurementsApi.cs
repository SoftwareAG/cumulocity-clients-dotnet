///
/// MeasurementsApi.cs
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
	/// Measurements are produced by reading sensor values. In some cases, this data is read in static intervals and sent to the platform (for example, temperature sensors or electrical meters). In other cases, the data is read on demand or at irregular intervals (for example, health devices such as weight scales). Regardless what kind of protocol the device supports, the agent is responsible for converting it into a "push" protocol by uploading data to Cumulocity IoT. <br />
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class MeasurementsApi : AdaptableApi, IMeasurementsApi
	{
		public MeasurementsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<MeasurementCollection<TMeasurement>?> GetMeasurements<TMeasurement>(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, string? valueFragmentSeries = null, string? valueFragmentType = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TMeasurement : Measurement
		{
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("revert", revert);
			queryString.AddIfRequired("source", source);
			queryString.AddIfRequired("type", type);
			queryString.AddIfRequired("valueFragmentSeries", valueFragmentSeries);
			queryString.AddIfRequired("valueFragmentType", valueFragmentType);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<MeasurementCollection<TMeasurement>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<TMeasurement?> CreateMeasurement<TMeasurement>(TMeasurement body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TMeasurement : Measurement
		{
			var jsonNode = ToJsonNode<TMeasurement>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("source", "self");
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.measurement+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.measurement+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<TMeasurement?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<MeasurementCollection<TMeasurement>?> CreateMeasurement<TMeasurement>(MeasurementCollection<TMeasurement> body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TMeasurement : Measurement
		{
			var jsonNode = ToJsonNode<MeasurementCollection<TMeasurement>>(body);
			jsonNode?.RemoveFromNode("next");
			jsonNode?.RemoveFromNode("prev");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("statistics");
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.measurementcollection+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.measurementcollection+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<MeasurementCollection<TMeasurement>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteMeasurements(string? xCumulocityProcessingMode = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("fragmentType", fragmentType);
			queryString.AddIfRequired("source", source);
			queryString.AddIfRequired("type", type);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<TMeasurement?> GetMeasurement<TMeasurement>(string id, CancellationToken cToken = default) where TMeasurement : Measurement
		{
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<TMeasurement?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteMeasurement(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<MeasurementSeries?> GetMeasurementSeries(string? aggregationType = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? revert = null, List<string>? series = null, string? source = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/measurement/measurements/series";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("aggregationType", aggregationType);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("revert", revert);
			queryString.AddIfRequired("series", series, false);
			queryString.AddIfRequired("source", source);
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
			return await JsonSerializer.DeserializeAsync<MeasurementSeries?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
