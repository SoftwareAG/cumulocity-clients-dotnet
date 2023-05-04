///
/// ManagedObjectsApi.cs
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
	/// The inventory stores devices and other assets relevant to your IoT solution. We refer to them as managed objects and such can be “smart objects”, for example, smart electricity meters, home automation gateways or GPS devices. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class ManagedObjectsApi : AdaptableApi, IManagedObjectsApi
	{
		public ManagedObjectsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<ManagedObjectCollection<TManagedObject>?> GetManagedObjects<TManagedObject>(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, int? currentPage = null, string? fragmentType = null, List<string>? ids = null, bool? onlyRoots = null, string? owner = null, int? pageSize = null, string? q = null, string? query = null, bool? skipChildrenNames = null, string? text = null, string? type = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withGroups = null, bool? withParents = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("childAdditionId", childAdditionId);
			queryString.AddIfRequired("childAssetId", childAssetId);
			queryString.AddIfRequired("childDeviceId", childDeviceId);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("fragmentType", fragmentType);
			queryString.AddIfRequired("ids", ids, false);
			queryString.AddIfRequired("onlyRoots", onlyRoots);
			queryString.AddIfRequired("owner", owner);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("q", q);
			queryString.AddIfRequired("query", query);
			queryString.AddIfRequired("skipChildrenNames", skipChildrenNames);
			queryString.AddIfRequired("text", text);
			queryString.AddIfRequired("type", type);
			queryString.AddIfRequired("withChildren", withChildren);
			queryString.AddIfRequired("withChildrenCount", withChildrenCount);
			queryString.AddIfRequired("withGroups", withGroups);
			queryString.AddIfRequired("withParents", withParents);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobjectcollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ManagedObjectCollection<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<TManagedObject?> CreateManagedObject<TManagedObject>(TManagedObject body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
		{
			var jsonNode = ToJsonNode<TManagedObject>(body);
			jsonNode?.RemoveFromNode("owner");
			jsonNode?.RemoveFromNode("additionParents");
			jsonNode?.RemoveFromNode("lastUpdated");
			jsonNode?.RemoveFromNode("childDevices");
			jsonNode?.RemoveFromNode("childAssets");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("childAdditions");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("assetParents");
			jsonNode?.RemoveFromNode("deviceParents");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<TManagedObject?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<int> GetNumberOfManagedObjects(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, string? fragmentType = null, List<string>? ids = null, string? owner = null, string? text = null, string? type = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/count";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("childAdditionId", childAdditionId);
			queryString.AddIfRequired("childAssetId", childAssetId);
			queryString.AddIfRequired("childDeviceId", childDeviceId);
			queryString.AddIfRequired("fragmentType", fragmentType);
			queryString.AddIfRequired("ids", ids, false);
			queryString.AddIfRequired("owner", owner);
			queryString.AddIfRequired("text", text);
			queryString.AddIfRequired("type", type);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, text/plain,application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<int>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<TManagedObject?> GetManagedObject<TManagedObject>(string id, bool? skipChildrenNames = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withParents = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("skipChildrenNames", skipChildrenNames);
			queryString.AddIfRequired("withChildren", withChildren);
			queryString.AddIfRequired("withChildrenCount", withChildrenCount);
			queryString.AddIfRequired("withParents", withParents);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<TManagedObject?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<TManagedObject?> UpdateManagedObject<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
		{
			var jsonNode = ToJsonNode<TManagedObject>(body);
			jsonNode?.RemoveFromNode("owner");
			jsonNode?.RemoveFromNode("additionParents");
			jsonNode?.RemoveFromNode("lastUpdated");
			jsonNode?.RemoveFromNode("childDevices");
			jsonNode?.RemoveFromNode("childAssets");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("childAdditions");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("assetParents");
			jsonNode?.RemoveFromNode("deviceParents");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<TManagedObject?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteManagedObject(string id, string? xCumulocityProcessingMode = null, bool? cascade = null, bool? forceCascade = null, bool? withDeviceUser = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("cascade", cascade);
			queryString.AddIfRequired("forceCascade", forceCascade);
			queryString.AddIfRequired("withDeviceUser", withDeviceUser);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<System.DateTime> GetLatestAvailability(string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}/availability";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, text/plain, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<System.DateTime>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<SupportedMeasurements?> GetSupportedMeasurements(string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}/supportedMeasurements";
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
			return await JsonSerializer.DeserializeAsync<SupportedMeasurements?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<SupportedSeries?> GetSupportedSeries(string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}/supportedSeries";
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
			return await JsonSerializer.DeserializeAsync<SupportedSeries?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<ManagedObjectUser?> GetManagedObjectUser(string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}/user";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectuser+json, application/vnd.com.nsn.cumulocity.error+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ManagedObjectUser?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<ManagedObjectUser?> UpdateManagedObjectUser(ManagedObjectUser body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<ManagedObjectUser>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("userName");
			var client = HttpClient;
			var resourcePath = $"/inventory/managedObjects/{id}/user";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectuser+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectuser+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectuser+json, application/vnd.com.nsn.cumulocity.error+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ManagedObjectUser?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
