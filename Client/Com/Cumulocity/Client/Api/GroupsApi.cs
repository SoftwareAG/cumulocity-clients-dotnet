//
// GroupsApi.cs
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
/// API methods to create, retrieve, update and delete user groups. <br />
/// ⚠️ Important: In the Cumulocity IoT user interface, user groups are referred to as "global roles". Global roles are not to be confused with user roles. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class GroupsApi : IGroupsApi
{
	private readonly HttpClient _httpClient;

	public GroupsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<UserGroupCollection<TCustomProperties>?> GetTenantUserGroups<TCustomProperties>(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups";
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
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.groupcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<UserGroupCollection<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<Group<TCustomProperties>?> CreateUserGroup<TCustomProperties>(Group<TCustomProperties> body, string tenantId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		var jsonNode = body.ToJsonNode<Group<TCustomProperties>>();
		jsonNode?.RemoveFromNode("roles");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("devicePermissions");
		jsonNode?.RemoveFromNode("users");
		jsonNode?.RemoveFromNode("applications");
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.group+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.group+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.group+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Group<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<Group<TCustomProperties>?> GetUserGroup<TCustomProperties>(string tenantId, int groupId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups/{HttpUtility.UrlEncode(groupId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.group+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Group<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<Group<TCustomProperties>?> UpdateUserGroup<TCustomProperties>(Group<TCustomProperties> body, string tenantId, int groupId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		var jsonNode = body.ToJsonNode<Group<TCustomProperties>>();
		jsonNode?.RemoveFromNode("roles");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("devicePermissions");
		jsonNode?.RemoveFromNode("users");
		jsonNode?.RemoveFromNode("applications");
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups/{HttpUtility.UrlEncode(groupId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.group+json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.group+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.group+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Group<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<System.IO.Stream> DeleteUserGroup(string tenantId, int groupId, CancellationToken cToken = default) 
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groups/{HttpUtility.UrlEncode(groupId.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return responseStream;
	}
	
	/// <inheritdoc />
	public async Task<Group<TCustomProperties>?> GetUserGroupByName<TCustomProperties>(string tenantId, string groupName, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/groupByName/{HttpUtility.UrlEncode(groupName.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.group+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<Group<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
	
	/// <inheritdoc />
	public async Task<GroupReferenceCollection<TCustomProperties>?> GetUserGroups<TCustomProperties>(string tenantId, string userId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/{HttpUtility.UrlEncode(tenantId.GetStringValue())}/users/{HttpUtility.UrlEncode(userId.GetStringValue())}/groups";
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
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.groupreferencecollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<GroupReferenceCollection<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
}
