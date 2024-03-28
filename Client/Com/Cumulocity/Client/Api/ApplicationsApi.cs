//
// ApplicationsApi.cs
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
/// API methods to retrieve, create, update and delete applications. <br />
/// ### Application names <br />
/// For each tenant, Cumulocity IoT manages the subscribed applications and provides a number of applications of various types.In case you want to subscribe a tenant to an application using an API, you must use the application name in the argument (as name). <br />
/// Refer to the tables in <see href="https://cumulocity.com/guides/users-guide/administration#managing-applications" langword="Administration > Managing applications" /> in the User guide for the respective application name to be used. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class ApplicationsApi : IApplicationsApi
{
	private readonly HttpClient _httpClient;

	public ApplicationsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<ApplicationCollection?> GetApplications(int? currentPage = null, string? name = null, string? owner = null, int? pageSize = null, string? providedFor = null, string? subscriber = null, string? tenant = null, string? type = null, string? user = null, bool? withTotalElements = null, bool? withTotalPages = null, bool? hasVersions = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/application/applications";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("name", name);
		queryString.TryAdd("owner", owner);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("providedFor", providedFor);
		queryString.TryAdd("subscriber", subscriber);
		queryString.TryAdd("tenant", tenant);
		queryString.TryAdd("type", type);
		queryString.TryAdd("user", user);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		queryString.TryAdd("hasVersions", hasVersions);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<ApplicationCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<Application?> CreateApplication(Application body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<Application>();
		jsonNode?.RemoveFromNode("owner");
		jsonNode?.RemoveFromNode("activeVersionId");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("resourcesUrl");
		const string resourcePath = "/application/applications";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.application+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.application+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Application?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<Application?> GetApplication(string id, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applications/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Application?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<Application?> UpdateApplication(Application body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<Application>();
		jsonNode?.RemoveFromNode("owner");
		jsonNode?.RemoveFromNode("activeVersionId");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("type");
		jsonNode?.RemoveFromNode("resourcesUrl");
		string resourcePath = $"/application/applications/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.application+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.application+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Application?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteApplication(string id, bool? force = null, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applications/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("force", force);
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
	public async Task<Application?> CopyApplication(string id, string? version = null, string? tag = null, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applications/{HttpUtility.UrlPathEncode(id.GetStringValue())}/clone";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("version", version);
		queryString.TryAdd("tag", tag);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Application?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<ApplicationCollection?> GetApplicationsByName(string name, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applicationsByName/{HttpUtility.UrlPathEncode(name.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<ApplicationCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<ApplicationCollection?> GetApplicationsByTenant(string tenantId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applicationsByTenant/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<ApplicationCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<ApplicationCollection?> GetApplicationsByOwner(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applicationsByOwner/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}";
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
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<ApplicationCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<ApplicationCollection?> GetApplicationsByUser(string username, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applicationsByUser/{HttpUtility.UrlPathEncode(username.GetStringValue())}";
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
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<ApplicationCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
}
