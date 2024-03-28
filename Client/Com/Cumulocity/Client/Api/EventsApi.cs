//
// EventsApi.cs
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
/// Events are used to pass real-time information through Cumulocity IoT. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class EventsApi : IEventsApi
{
	private readonly HttpClient _httpClient;

	public EventsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<EventCollection<TEvent>?> GetEvents<TEvent>(System.DateTime? createdFrom = null, System.DateTime? createdTo = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? fragmentValue = null, System.DateTime? lastUpdatedFrom = null, System.DateTime? lastUpdatedTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TEvent : Event
	{
		const string resourcePath = "/event/events";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("createdFrom", createdFrom);
		queryString.TryAdd("createdTo", createdTo);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("fragmentType", fragmentType);
		queryString.TryAdd("fragmentValue", fragmentValue);
		queryString.TryAdd("lastUpdatedFrom", lastUpdatedFrom);
		queryString.TryAdd("lastUpdatedTo", lastUpdatedTo);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("revert", revert);
		queryString.TryAdd("source", source);
		queryString.TryAdd("type", type);
		queryString.TryAdd("withSourceAssets", withSourceAssets);
		queryString.TryAdd("withSourceDevices", withSourceDevices);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.eventcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<EventCollection<TEvent>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TEvent?> CreateEvent<TEvent>(TEvent body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TEvent : Event
	{
		var jsonNode = body.ToJsonNode<TEvent>();
		jsonNode?.RemoveFromNode("lastUpdated");
		jsonNode?.RemoveFromNode("creationTime");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("source", "self");
		const string resourcePath = "/event/events";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.event+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.event+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.event+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TEvent?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteEvents(string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/event/events";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("createdFrom", createdFrom);
		queryString.TryAdd("createdTo", createdTo);
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
	public async Task<TEvent?> GetEvent<TEvent>(string id, CancellationToken cToken = default) where TEvent : Event
	{
		string resourcePath = $"/event/events/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.event+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TEvent?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TEvent?> UpdateEvent<TEvent>(TEvent body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TEvent : Event
	{
		var jsonNode = body.ToJsonNode<TEvent>();
		jsonNode?.RemoveFromNode("lastUpdated");
		jsonNode?.RemoveFromNode("creationTime");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("source");
		jsonNode?.RemoveFromNode("time");
		jsonNode?.RemoveFromNode("type");
		string resourcePath = $"/event/events/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.event+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.event+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.event+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TEvent?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteEvent(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/event/events/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
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
}
