///
/// CurrentApplicationApi.cs
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
	/// API methods to retrieve and update the current application and to retrieve its subscribers.
	/// It is the authenticated microservice user's application.
	/// 
	/// </summary>
	#nullable enable
	public class CurrentApplicationApi : AdaptableApi 
	{
		public CurrentApplicationApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve the current application<br/>
		/// Retrieve the current application. This only works inside an application, for example, a microservice.  <section><h5>Required roles</h5> Microservice bootstrap user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the current application sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not enough permissions/roles to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		public async Task<Application?> GetCurrentApplication()
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}application/currentApplication"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Application?>(responseStream);
		}
		
		/// <summary>
		/// Update the current application<br/>
		/// Update the current application. This only works inside an application, for example, a microservice. This method is deprecated as it is only used by legacy microservices that are not running on Kubernetes.  <section><h5>Required roles</h5> Microservice bootstrap user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The current application was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not enough permissions/roles to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		[Obsolete]
		public async Task<Application?> UpdateCurrentApplication(Application body)
		{
			var jsonNode = ToJsonNode<Application>(body);
			jsonNode?.RemoveFromNode("owner");
			jsonNode?.RemoveFromNode("activeVersionId");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("resourcesUrl");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}application/currentApplication"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.application+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.application+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Application?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve the current application settings<br/>
		/// Retrieve the current application settings. This only works inside an application, for example, a microservice.  <section><h5>Required roles</h5> Microservice bootstrap user <b>OR</b> microservice service user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the current application settings are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not enough permissions/roles to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		public async Task<List<ApplicationSettings>?> GetCurrentApplicationSettings()
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}application/currentApplication/settings"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationsettings+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<List<ApplicationSettings>?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve the subscribed users of the current application<br/>
		/// Retrieve the subscribed users of the current application.  <section><h5>Required roles</h5> Microservice bootstrap user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the list of subscribed users for the current application is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		public async Task<ApplicationUserCollection?> GetSubscribedUsers()
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}application/currentApplication/subscriptions"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.applicationusercollection+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ApplicationUserCollection?>(responseStream);
		}
	}
	#nullable disable
}
