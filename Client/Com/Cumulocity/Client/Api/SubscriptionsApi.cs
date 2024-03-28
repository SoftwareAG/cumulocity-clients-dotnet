//
// SubscriptionsApi.cs
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
/// Methods to create, retrieve and delete notification subscriptions. <br />
/// </summary>
///
public sealed class SubscriptionsApi : ISubscriptionsApi
{
	private readonly HttpClient _httpClient;

	public SubscriptionsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<NotificationSubscriptionCollection?> GetSubscriptions(string? context = null, int? currentPage = null, int? pageSize = null, string? source = null, string? subscription = null, string? typeFilter = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/notification2/subscriptions";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("context", context);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("source", source);
		queryString.TryAdd("subscription", subscription);
		queryString.TryAdd("typeFilter", typeFilter);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.subscriptioncollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NotificationSubscriptionCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<NotificationSubscription?> CreateSubscription(NotificationSubscription body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<NotificationSubscription>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("source", "self");
		const string resourcePath = "/notification2/subscriptions";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.subscription+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.subscription+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.subscription+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NotificationSubscription?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteSubscriptions(string? xCumulocityProcessingMode = null, string? context = null, string? source = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/notification2/subscriptions";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("context", context);
		queryString.TryAdd("source", source);
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
	public async Task<NotificationSubscription?> GetSubscription(string id, CancellationToken cToken = default) 
	{
		string resourcePath = $"/notification2/subscriptions/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.subscription+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<NotificationSubscription?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteSubscription(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/notification2/subscriptions/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
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
