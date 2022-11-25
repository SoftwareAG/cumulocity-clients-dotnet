///
/// TenantsApi.cs
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
	/// Tenants are physically separated data spaces with a separate URL, with own users, a separate application management and no sharing of data by default. Users in a single tenant by default share the same URL and the same data space.
	/// 
	/// ### Tenant ID and tenant domain
	/// 
	/// The **tenant ID** is a unique identifier across all tenants in Cumulocity IoT and it follows the format t&lt;number>, for example, t07007007. It is possible to specify the tenant ID while creating a subtenant, but the ID cannot be changed after creation. If the ID is not specified (recommended), it gets auto-generated for all tenant types.
	/// 
	/// The location where a tenant can be accessed is called **tenant domain**, for example, _mytenant.cumulocity.com_. It needs to be unique across all tenants and it can be changed after tenant creation.
	/// The tenant domain may contain only lowercase letters, digits and hyphens. It must start with a lowercase letter, hyphens are only allowed in the middle, and the minimum length is 2 characters. Note that the usage of underscore characters is deprecated but still possible for backward compatibility reasons.
	/// 
	/// In general, the tenant domain should be used for communication if it is known.
	/// 
	/// > **⚠️ Important:** For support user access, the tenant ID must be used and not the tenant domain.
	/// 
	/// See [Tenant > Current tenant](#operation/getCurrentTenantResource) for information on how to retrieve the tenant ID and domain of the current tenant via the API.
	/// 
	/// In the UI, the tenant ID is displayed in the user dropdown menu, see [Getting started > User options and settings](https://cumulocity.com/guides/users-guide/getting-started/#user-settings) in the User guide.
	/// 
	/// ### Access rights and permissions
	/// 
	/// There are two types of roles in Cumulocity IoT – global and inventory. Global roles are applied at the tenant level. In a Role Based Access Control (RBAC) approach you must use the inventory roles in order to have the correct level of separation. Apart from some global permissions (like "own user management") customer users will not be assigned any roles. Inventory roles must be created, or the default roles used, and then assigned to the user in combination with the assets the roles apply to. This needs to be done at least once for each customer.
	/// 
	/// In a multi-tenancy approach, as the tenant is completely separated from all other customers you do not necessarily need to be involved in setting up the access rights of the customer. If customers are given administration rights for their tenants, they can set up permissions on their own. It is not possible for customers to have any sight or knowledge of other customers.
	/// 
	/// In the RBAC approach, managing access is the most complicated part because a misconfiguration can potentially give customers access to data that they must not see, like other customers' data. The inventory roles allow you to granularly define access for only certain parts of data, but they don't protect you from accidental misconfigurations. A limitation here is that customers won't be able to create their own roles.
	/// 
	/// For more details, see [RBAC versus multi-tenancy approach](https://cumulocity.com/guides/concepts/tenant-hierarchy/#comparison).
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class TenantsApi : AdaptableApi, ITenantsApi
	{
		public TenantsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<TenantCollection<TCustomProperties>?> GetTenants<TCustomProperties>(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"pageSize", pageSize},
				{"withTotalElements", withTotalElements},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).ToList().ForEach(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenantcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TenantCollection<TCustomProperties>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<Tenant<TCustomProperties>?> CreateTenant<TCustomProperties>(Tenant<TCustomProperties> body, string xCumulocityProcessingMode) where TCustomProperties : CustomProperties
		{
			var jsonNode = ToJsonNode<Tenant<TCustomProperties>>(body);
			jsonNode?.RemoveFromNode("allowCreateTenants");
			jsonNode?.RemoveFromNode("parent");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("ownedApplications");
			jsonNode?.RemoveFromNode("applications");
			jsonNode?.RemoveFromNode("status");
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.tenant+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.tenant+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenant+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Tenant<TCustomProperties>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<CurrentTenant<TCustomProperties>?> GetCurrentTenant<TCustomProperties>() where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/currentTenant";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.currenttenant+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<CurrentTenant<TCustomProperties>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<Tenant<TCustomProperties>?> GetTenant<TCustomProperties>(string tenantId) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenant+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Tenant<TCustomProperties>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<Tenant<TCustomProperties>?> UpdateTenant<TCustomProperties>(Tenant<TCustomProperties> body, string tenantId, string xCumulocityProcessingMode) where TCustomProperties : CustomProperties
		{
			var jsonNode = ToJsonNode<Tenant<TCustomProperties>>(body);
			jsonNode?.RemoveFromNode("adminName");
			jsonNode?.RemoveFromNode("allowCreateTenants");
			jsonNode?.RemoveFromNode("parent");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("ownedApplications");
			jsonNode?.RemoveFromNode("applications");
			jsonNode?.RemoveFromNode("status");
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.tenant+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.tenant+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.tenant+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Tenant<TCustomProperties>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteTenant(string tenantId, string xCumulocityProcessingMode) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<TenantTfaData?> GetTenantTfaSettings(string tenantId) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/tfa";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TenantTfaData?>(responseStream);
		}
	}
	#nullable disable
}
