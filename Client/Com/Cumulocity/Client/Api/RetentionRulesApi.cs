//
// RetentionRulesApi.cs
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
/// It is possible to define rules that make the platform remove certain data. A retention rule shows which data will be deleted. For example, a retention rule with <c>dataType=EVENT</c> and <c>maximumAge=30</c> removes from the system all events older than 30 days. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class RetentionRulesApi : IRetentionRulesApi
{
	private readonly HttpClient _httpClient;

	public RetentionRulesApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<RetentionRuleCollection?> GetRetentionRules(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/retention/retentions";
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
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrulecollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<RetentionRuleCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<RetentionRule?> CreateRetentionRule(RetentionRule body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<RetentionRule>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		const string resourcePath = "/retention/retentions";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.retentionrule+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.retentionrule+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrule+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<RetentionRule?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<RetentionRule?> GetRetentionRule(string id, CancellationToken cToken = default) 
	{
		string resourcePath = $"/retention/retentions/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrule+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<RetentionRule?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<RetentionRule?> UpdateRetentionRule(RetentionRule body, string id, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<RetentionRule>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		string resourcePath = $"/retention/retentions/{HttpUtility.UrlEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.retentionrule+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.retentionrule+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrule+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<RetentionRule?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteRetentionRule(string id, CancellationToken cToken = default) 
	{
		string resourcePath = $"/retention/retentions/{HttpUtility.UrlEncode(id.GetStringValue())}";
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
