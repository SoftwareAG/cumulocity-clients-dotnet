///
/// ExternalIDsApi.cs
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
	/// The external ID resource represents an individual external ID that can be queried and deleted.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class ExternalIDsApi : AdaptableApi 
	{
		public ExternalIDsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve all external IDs of a specific managed object<br/>
		/// Retrieve all external IDs of a existing managed object (identified by ID).  <section><h5>Required roles</h5> ROLE_IDENTITY_READ <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_READ permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all the external IDs are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		public async Task<ExternalIds?> GetExternalIds(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}identity/globalIds/{id}/externalIds"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.externalidcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ExternalIds?>(responseStream);
		}
		
		/// <summary>
		/// Create an external ID<br/>
		/// Create an external ID for an existing managed object (identified by ID).  <section><h5>Required roles</h5> ROLE_IDENTITY_ADMIN <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_ADMIN permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An external ID was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate – Identity already bound to a different Global ID.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		public async Task<ExternalId?> CreateExternalId(ExternalId body, string id)
		{
			var jsonNode = ToJsonNode<ExternalId>(body);
			jsonNode?.RemoveFromNode("managedObject");
			jsonNode?.RemoveFromNode("self");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}identity/globalIds/{id}/externalIds"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.externalid+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.externalid+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.externalid+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ExternalId?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve a specific external ID<br/>
		/// Retrieve a specific external ID of a particular type.  <section><h5>Required roles</h5> ROLE_IDENTITY_READ <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_READ permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the external ID is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>External ID not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="type">The identifier used in the external system that Cumulocity IoT interfaces with.</param>
		/// <param name="externalId">The type of the external identifier.</param>
		/// <returns></returns>
		public async Task<ExternalId?> GetExternalId(string type, string externalId)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}identity/externalIds/{type}/{externalId}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.externalid+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ExternalId?>(responseStream);
		}
		
		/// <summary>
		/// Remove a specific external ID<br/>
		/// Remove a specific external ID of a particular type.  <section><h5>Required roles</h5> ROLE_IDENTITY_ADMIN <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_ADMIN permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>An external ID was deleted.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>External ID not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="type">The identifier used in the external system that Cumulocity IoT interfaces with.</param>
		/// <param name="externalId">The type of the external identifier.</param>
		public async Task<System.IO.Stream> DeleteExternalId(string type, string externalId)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}identity/externalIds/{type}/{externalId}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
	}
	#nullable disable
}
