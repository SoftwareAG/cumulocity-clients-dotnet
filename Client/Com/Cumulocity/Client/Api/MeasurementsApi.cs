//
// MeasurementsApi.cs
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
/// Measurements are produced by reading sensor values. In some cases, this data is read in static intervals and sent to the platform (for example, temperature sensors or electrical meters). In other cases, the data is read on demand or at irregular intervals (for example, health devices such as weight scales). Regardless what kind of protocol the device supports, the agent is responsible for converting it into a "push" protocol by uploading data to Cumulocity IoT. <br />
/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class MeasurementsApi : IMeasurementsApi
{
	private readonly HttpClient _httpClient;

	public MeasurementsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<MeasurementCollection<TMeasurement>?> GetMeasurements<TMeasurement>(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, string? valueFragmentSeries = null, string? valueFragmentType = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TMeasurement : Measurement
	{
		const string resourcePath = "/measurement/measurements";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("revert", revert);
		queryString.TryAdd("source", source);
		queryString.TryAdd("type", type);
		queryString.TryAdd("valueFragmentSeries", valueFragmentSeries);
		queryString.TryAdd("valueFragmentType", valueFragmentType);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<MeasurementCollection<TMeasurement>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TMeasurement?> CreateMeasurement<TMeasurement>(TMeasurement body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TMeasurement : Measurement
	{
		var jsonNode = body.ToJsonNode<TMeasurement>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("source", "self");
		const string resourcePath = "/measurement/measurements";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.measurement+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.measurement+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TMeasurement?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<MeasurementCollection<TMeasurement>?> CreateMeasurement<TMeasurement>(MeasurementCollection<TMeasurement> body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TMeasurement : Measurement
	{
		var jsonNode = body.ToJsonNode<MeasurementCollection<TMeasurement>>();
		jsonNode?.RemoveFromNode("next");
		jsonNode?.RemoveFromNode("prev");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("statistics");
		const string resourcePath = "/measurement/measurements";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.measurementcollection+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.measurementcollection+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json, application/vnd.com.nsn.cumulocity.measurementcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<MeasurementCollection<TMeasurement>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteMeasurements(string? xCumulocityProcessingMode = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/measurement/measurements";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("fragmentType", fragmentType);
		queryString.TryAdd("source", source);
		queryString.TryAdd("type", type);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TMeasurement?> GetMeasurement<TMeasurement>(string id, CancellationToken cToken = default) where TMeasurement : Measurement
	{
		string resourcePath = $"/measurement/measurements/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.measurement+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TMeasurement?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteMeasurement(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/measurement/measurements/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<MeasurementSeries?> GetMeasurementSeries(string? aggregationType = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? revert = null, List<string>? series = null, string? source = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/measurement/measurements/series";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("aggregationType", aggregationType);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("revert", revert);
		queryString.TryAdd("series", series, false);
		queryString.TryAdd("source", source);
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
		return await JsonSerializerWrapper.DeserializeAsync<MeasurementSeries?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
}
