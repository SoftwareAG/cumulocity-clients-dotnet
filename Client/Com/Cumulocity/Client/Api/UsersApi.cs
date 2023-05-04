///
/// UsersApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

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
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to create, retrieve, update and delete users in Cumulocity IoT. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class UsersApi : AdaptableApi, IUsersApi
	{
		public UsersApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<UserCollection<TCustomProperties>?> GetUsers<TCustomProperties>(string tenantId, int? currentPage = null, List<string>? groups = null, bool? onlyDevices = null, string? owner = null, int? pageSize = null, string? username = null, bool? withSubusersCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("groups", groups, false);
			queryString.AddIfRequired("onlyDevices", onlyDevices);
			queryString.AddIfRequired("owner", owner);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("username", username);
			queryString.AddIfRequired("withSubusersCount", withSubusersCount);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.usercollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<UserCollection<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<User<TCustomProperties>?> CreateUser<TCustomProperties>(User<TCustomProperties> body, string tenantId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var jsonNode = ToJsonNode<User<TCustomProperties>>(body);
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
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.user+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.user+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<User<TCustomProperties>?> GetUser<TCustomProperties>(string tenantId, string userId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<User<TCustomProperties>?> UpdateUser<TCustomProperties>(User<TCustomProperties> body, string tenantId, string userId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var jsonNode = ToJsonNode<User<TCustomProperties>>(body);
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
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.user+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.user+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteUser(string tenantId, string userId, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> UpdateUserPassword(PasswordChange body, string tenantId, string userId, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<PasswordChange>(body);
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/password";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<UserTfaData?> GetUserTfaSettings(string tenantId, string userId, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/tfa";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<UserTfaData?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<User<TCustomProperties>?> GetUserByUsername<TCustomProperties>(string tenantId, string username, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/userByName/{username}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<User<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<UserReferenceCollection<TCustomProperties>?> GetUsersFromUserGroup<TCustomProperties>(string tenantId, int groupId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/groups/{groupId}/users";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.userreferencecollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<UserReferenceCollection<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<UserReference<TCustomProperties>?> AssignUserToUserGroup<TCustomProperties>(SubscribedUser body, string tenantId, int groupId, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var jsonNode = ToJsonNode<SubscribedUser>(body);
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/groups/{groupId}/users";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.userreference+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.userreference+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.userreference+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<UserReference<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> RemoveUserFromUserGroup(string tenantId, int groupId, string userId, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/groups/{groupId}/users/{userId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> Logout(string? cookie = null, string? xXSRFTOKEN = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/logout";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Cookie", cookie);
			request.Headers.TryAddWithoutValidation("X-XSRF-TOKEN", xXSRFTOKEN);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> LogoutAllUsers(string tenantId, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/logout/{tenantId}/allUsers";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
	}
	#nullable disable
}
