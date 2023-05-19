//
// CurrentApplicationApi.cs
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
/// API methods to retrieve and update the current application and to retrieve its subscribers.It is the authenticated microservice user's application. <br />
/// </summary>
///
public sealed class CurrentApplicationApi : ICurrentApplicationApi
{
	private readonly HttpClient _httpClient;

	public CurrentApplicationApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<Application?> GetCurrentApplication(CancellationToken cToken = default) 
	{
		const string resourcePath = "/application/currentApplication";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Application?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<Application?> UpdateCurrentApplication(Application body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<Application>();
		jsonNode?.RemoveFromNode("owner");
		jsonNode?.RemoveFromNode("activeVersionId");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("resourcesUrl");
		const string resourcePath = "/application/currentApplication";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.application+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.application+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Application?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<List<ApplicationSettings>?> GetCurrentApplicationSettings(CancellationToken cToken = default) 
	{
		const string resourcePath = "/application/currentApplication/settings";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationsettings+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<List<ApplicationSettings>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<ApplicationUserCollection?> GetSubscribedUsers(CancellationToken cToken = default) 
	{
		const string resourcePath = "/application/currentApplication/subscriptions";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.applicationusercollection+json, application/vnd.com.nsn.cumulocity.error+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<ApplicationUserCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
}
