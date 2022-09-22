///
/// ManagedObjectsApi.cs
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
	/// The inventory stores devices and other assets relevant to your IoT solution. We refer to them as managed objects and such can be “smart objects”, for example, smart electricity meters, home automation gateways or GPS devices.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class ManagedObjectsApi : AdaptableApi, IManagedObjectsApi
	{
		public ManagedObjectsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<ManagedObjectCollection?> GetManagedObjects(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, int? currentPage = null, string? fragmentType = null, List<string>? ids = null, bool? onlyRoots = null, string? owner = null, int? pageSize = null, string? q = null, string? query = null, bool? skipChildrenNames = null, string? text = null, string? type = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withGroups = null, bool? withParents = null, bool? withTotalElements = null, bool? withTotalPages = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"childAdditionId", childAdditionId},
				{"childAssetId", childAssetId},
				{"childDeviceId", childDeviceId},
				{"currentPage", currentPage},
				{"fragmentType", fragmentType},
				{"ids", ids},
				{"onlyRoots", onlyRoots},
				{"owner", owner},
				{"pageSize", pageSize},
				{"q", q},
				{"query", query},
				{"skipChildrenNames", skipChildrenNames},
				{"text", text},
				{"type", type},
				{"withChildren", withChildren},
				{"withChildrenCount", withChildrenCount},
				{"withGroups", withGroups},
				{"withParents", withParents},
				{"withTotalElements", withTotalElements},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobjectcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ManagedObjectCollection?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<ManagedObject?> CreateManagedObject(ManagedObject body)
		{
			var jsonNode = ToJsonNode<ManagedObject>(body);
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
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ManagedObject?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<int> GetNumberOfManagedObjects(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, string? fragmentType = null, List<string>? ids = null, string? owner = null, string? text = null, string? type = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/count"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"childAdditionId", childAdditionId},
				{"childAssetId", childAssetId},
				{"childDeviceId", childDeviceId},
				{"fragmentType", fragmentType},
				{"ids", ids},
				{"owner", owner},
				{"text", text},
				{"type", type}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, text/plain,application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<int>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<ManagedObject?> GetManagedObject(string id, bool? skipChildrenNames = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withParents = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"skipChildrenNames", skipChildrenNames},
				{"withChildren", withChildren},
				{"withChildrenCount", withChildrenCount},
				{"withParents", withParents}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ManagedObject?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<ManagedObject?> UpdateManagedObject(ManagedObject body, string id)
		{
			var jsonNode = ToJsonNode<ManagedObject>(body);
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
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ManagedObject?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteManagedObject(string id, bool? cascade = null, bool? forceCascade = null, bool? withDeviceUser = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"cascade", cascade},
				{"forceCascade", forceCascade},
				{"withDeviceUser", withDeviceUser}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
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
		
		/// <inheritdoc />
		public async Task<System.DateTime> GetLatestAvailability(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}/availability"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, text/plain, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<System.DateTime>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<SupportedMeasurements?> GetSupportedMeasurements(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}/supportedMeasurements"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<SupportedMeasurements?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<SupportedSeries?> GetSupportedSeries(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}/supportedSeries"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<SupportedSeries?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<ManagedObjectUser?> GetManagedObjectUser(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}/user"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectuser+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ManagedObjectUser?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<ManagedObjectUser?> UpdateManagedObjectUser(ManagedObjectUser body, string id)
		{
			var jsonNode = ToJsonNode<ManagedObjectUser>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("userName");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}inventory/managedObjects/{id}/user"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectuser+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectuser+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectuser+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ManagedObjectUser?>(responseStream);
		}
	}
	#nullable disable
}
