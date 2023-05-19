//
// OperationsApi.cs
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
/// API methods to create, retrieve, update and delete operations in Cumulocity IoT. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class OperationsApi : IOperationsApi
{
	private readonly HttpClient _httpClient;

	public OperationsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<OperationCollection<TOperation>?> GetOperations<TOperation>(string? agentId = null, string? bulkOperationId = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? fragmentType = null, int? pageSize = null, bool? revert = null, string? status = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TOperation : Operation
	{
		const string resourcePath = "/devicecontrol/operations";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("agentId", agentId);
		queryString.TryAdd("bulkOperationId", bulkOperationId);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("deviceId", deviceId);
		queryString.TryAdd("fragmentType", fragmentType);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("revert", revert);
		queryString.TryAdd("status", status);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operationcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<OperationCollection<TOperation>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<TOperation?> CreateOperation<TOperation>(TOperation body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TOperation : Operation
	{
		var jsonNode = body.ToJsonNode<TOperation>();
		jsonNode?.RemoveFromNode("creationTime");
		jsonNode?.RemoveFromNode("deviceExternalIDs", "self");
		jsonNode?.RemoveFromNode("bulkOperationId");
		jsonNode?.RemoveFromNode("failureReason");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("status");
		const string resourcePath = "/devicecontrol/operations";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.operation+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.operation+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operation+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TOperation?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<System.IO.Stream> DeleteOperations(string? xCumulocityProcessingMode = null, string? agentId = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? status = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/devicecontrol/operations";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("agentId", agentId);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("deviceId", deviceId);
		queryString.TryAdd("status", status);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return responseStream;
	}
	
	/// <inheritdoc />
	public async Task<TOperation?> GetOperation<TOperation>(string id, CancellationToken cToken = default) where TOperation : Operation
	{
		string resourcePath = $"/devicecontrol/operations/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operation+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TOperation?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<TOperation?> UpdateOperation<TOperation>(TOperation body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TOperation : Operation
	{
		var jsonNode = body.ToJsonNode<TOperation>();
		jsonNode?.RemoveFromNode("creationTime");
		jsonNode?.RemoveFromNode("deviceExternalIDs", "self");
		jsonNode?.RemoveFromNode("bulkOperationId");
		jsonNode?.RemoveFromNode("failureReason");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("deviceId");
		string resourcePath = $"/devicecontrol/operations/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.operation+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.operation+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operation+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TOperation?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
}
