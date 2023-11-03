//
// UsersApi.cs
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
/// API methods to create, retrieve, update and delete users in Cumulocity IoT. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class UsersApi : IUsersApi
{
	private readonly HttpClient _httpClient;

	public UsersApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<UserCollection<TCustomProperties>?> GetUsers<TCustomProperties>(string tenantId, int? currentPage = null, List<string>? groups = null, bool? onlyDevices = null, string? owner = null, int? pageSize = null, string? username = null, bool? withSubusersCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("groups", groups, false);
		queryString.TryAdd("onlyDevices", onlyDevices);
		queryString.TryAdd("owner", owner);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("username", username);
		queryString.TryAdd("withSubusersCount", withSubusersCount);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.usercollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<UserCollection<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<User<TCustomProperties>?> CreateUser<TCustomProperties>(User<TCustomProperties> body, string tenantId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		var jsonNode = body.ToJsonNode<User<TCustomProperties>>();
		jsonNode?.RemoveFromNode("owner");
		jsonNode?.RemoveFromNode("passwordStrength");
		jsonNode?.RemoveFromNode("roles");
		jsonNode?.RemoveFromNode("groups");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("shouldResetPassword");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("lastPasswordChange");
		jsonNode?.RemoveFromNode("twoFactorAuthenticationEnabled");
		jsonNode?.RemoveFromNode("devicePermissions");
		jsonNode?.RemoveFromNode("applications");
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.user+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.user+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<User<TCustomProperties>?> GetUser<TCustomProperties>(string tenantId, string userId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<User<TCustomProperties>?> UpdateUser<TCustomProperties>(User<TCustomProperties> body, string tenantId, string userId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		var jsonNode = body.ToJsonNode<User<TCustomProperties>>();
		jsonNode?.RemoveFromNode("owner");
		jsonNode?.RemoveFromNode("passwordStrength");
		jsonNode?.RemoveFromNode("roles");
		jsonNode?.RemoveFromNode("groups");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("shouldResetPassword");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("lastPasswordChange");
		jsonNode?.RemoveFromNode("userName");
		jsonNode?.RemoveFromNode("twoFactorAuthenticationEnabled");
		jsonNode?.RemoveFromNode("devicePermissions");
		jsonNode?.RemoveFromNode("applications");
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.user+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.user+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> DeleteUser(string tenantId, string userId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}";
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
	
	/// <inheritdoc />
	public async Task<string?> UpdateUserPassword(PasswordChange body, string tenantId, string userId, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<PasswordChange>();
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}/password";
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
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<UserTfaData?> GetUserTfaSettings(string tenantId, string userId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}/tfa";
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
		return await JsonSerializerWrapper.DeserializeAsync<UserTfaData?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<User<TCustomProperties>?> GetUserByUsername<TCustomProperties>(string tenantId, string username, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/userByName/{HttpUtility.UrlEncode(username.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<UserReferenceCollection<TCustomProperties>?> GetUsersFromUserGroup<TCustomProperties>(string tenantId, int groupId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups/{HttpUtility.UrlEncode(groupId.GetStringValue())}/users";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalElements", withTotalElements);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.userreferencecollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<UserReferenceCollection<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<UserReference<TCustomProperties>?> AssignUserToUserGroup<TCustomProperties>(SubscribedUser body, string tenantId, int groupId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		var jsonNode = body.ToJsonNode<SubscribedUser>();
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups/{HttpUtility.UrlEncode(groupId.GetStringValue())}/users";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.userreference+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.userreference+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.userreference+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<UserReference<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> RemoveUserFromUserGroup(string tenantId, int groupId, string userId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups/{HttpUtility.UrlEncode(groupId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}";
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
	
	/// <inheritdoc />
	public async Task<string?> Logout(string? cookie = null, string? xXSRFTOKEN = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/user/logout";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Cookie", cookie);
		request.Headers.TryAddWithoutValidation("X-XSRF-TOKEN", xXSRFTOKEN);
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> LogoutAllUsers(string tenantId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/user/logout/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/allUsers";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
}
