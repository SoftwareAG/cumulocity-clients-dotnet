///
/// LoginOptionsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// API methods to retrieve the login options configured in the tenant.
	/// 
	/// More detailed information about the parameters and their meaning can be found in [Administration > Changing settings](https://cumulocity.com/guides/users-guide/administration/#changing-settings) in the *Users guide*.
	/// > **&#9432; Info:** If OAuth external is the only login option shown in the response, the user will be automatically redirected to the SSO login screen.
	/// 
	/// </summary>
	#nullable enable
	public class LoginOptionsApi : AdaptableApi 
	{
		public LoginOptionsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve the login options<br/>
		/// Retrieve the login options available in the tenant.
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the login options are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 400</term>
		/// <description>Bad request – invalid parameters.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="management">If this is set to `true`, the management tenant login options will be returned.  > **&#9432; Info:** The `tenantId` parameter must not be present in the request when using the `management` parameter, otherwise it will cause an error. </param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <returns></returns>
		public async Task<LoginOptionCollection?> GetLoginOptions(bool? management = null, string? tenantId = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}tenant/loginOptions"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"management", management},
				{"tenantId", tenantId}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.loginoptioncollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<LoginOptionCollection?>(responseStream);
		}
		
		/// <summary>
		/// Create a login option<br/>
		/// Create an authentication configuration on your tenant.  <section><h5>Required roles</h5> ROLE_TENANT_ADMIN <b>OR</b> ROLE_TENANT_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>A login option was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 400</term>
		/// <description>Duplicated – The login option already exists.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		public async Task<AuthConfig?> CreateLoginOption(AuthConfig body)
		{
			var jsonNode = ToJsonNode<AuthConfig>(body);
			jsonNode?.RemoveFromNode("self");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}tenant/loginOptions"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.authconfig+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.authconfig+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.authconfig+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<AuthConfig?>(responseStream);
		}
	}
	#nullable disable
}
