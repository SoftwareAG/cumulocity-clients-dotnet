//
// NewDeviceRequestsApi.cs
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
/// API methods to create, retrieve, update and delete new device requests in Cumulocity IoT. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class NewDeviceRequestsApi : INewDeviceRequestsApi
{
	private readonly HttpClient _httpClient;

	public NewDeviceRequestsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<NewDeviceRequestCollection?> GetNewDeviceRequests(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/devicecontrol/newDeviceRequests";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.newdevicerequestcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NewDeviceRequestCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<NewDeviceRequest?> CreateNewDeviceRequest(NewDeviceRequest body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<NewDeviceRequest>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("status");
		const string resourcePath = "/devicecontrol/newDeviceRequests";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.newdevicerequest+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.newdevicerequest+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.newdevicerequest+json, application/vnd.com.nsn.cumulocity.error+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NewDeviceRequest?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<NewDeviceRequest?> GetNewDeviceRequest(string requestId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/devicecontrol/newDeviceRequests/{HttpUtility.UrlPathEncode(requestId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.newdevicerequest+json, application/vnd.com.nsn.cumulocity.error+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NewDeviceRequest?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<NewDeviceRequest?> UpdateNewDeviceRequest(NewDeviceRequest body, string requestId, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<NewDeviceRequest>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		string resourcePath = $"/devicecontrol/newDeviceRequests/{HttpUtility.UrlPathEncode(requestId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.newdevicerequest+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.newdevicerequest+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.newdevicerequest+json, application/vnd.com.nsn.cumulocity.error+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NewDeviceRequest?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteNewDeviceRequest(string requestId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/devicecontrol/newDeviceRequests/{HttpUtility.UrlPathEncode(requestId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
}
