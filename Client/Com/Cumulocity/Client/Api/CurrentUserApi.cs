//
// CurrentUserApi.cs
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
/// The current user is the user that is currently authenticated with Cumulocity IoT for the API calls. <br />
/// ⓘ Info: The Accept header should be provided in all PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class CurrentUserApi : ICurrentUserApi
{
	private readonly HttpClient _httpClient;

	public CurrentUserApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<CurrentUser?> GetCurrentUser(CancellationToken cToken = default) 
	{
		const string resourcePath = "/user/currentUser";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.currentuser+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<CurrentUser?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<CurrentUser?> UpdateCurrentUser(CurrentUser body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<CurrentUser>();
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("effectiveRoles");
		jsonNode?.RemoveFromNode("shouldResetPassword");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("lastPasswordChange");
		jsonNode?.RemoveFromNode("twoFactorAuthenticationEnabled");
		jsonNode?.RemoveFromNode("devicePermissions");
		const string resourcePath = "/user/currentUser";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.currentuser+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.currentuser+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.currentuser+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<CurrentUser?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<string?> UpdateCurrentUserPassword(PasswordChange body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<PasswordChange>();
		const string resourcePath = "/user/currentUser/password";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<string?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<CurrentUserTotpSecret?> GenerateTfaSecret(CancellationToken cToken = default) 
	{
		const string resourcePath = "/user/currentUser/totpSecret";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<CurrentUserTotpSecret?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<CurrentUserTotpSecretActivity?> GetTfaState(CancellationToken cToken = default) 
	{
		const string resourcePath = "/user/currentUser/totpSecret/activity";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<CurrentUserTotpSecretActivity?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<string?> SetTfaState(CurrentUserTotpSecretActivity body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<CurrentUserTotpSecretActivity>();
		const string resourcePath = "/user/currentUser/totpSecret/activity";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<string?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<string?> VerifyTfaCode(CurrentUserTotpCode body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<CurrentUserTotpCode>();
		const string resourcePath = "/user/currentUser/totpSecret/verify";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<string?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
}
