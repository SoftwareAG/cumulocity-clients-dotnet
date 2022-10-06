///
/// OperationsApi.cs
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
	/// API methods to create, retrieve, update and delete operations in Cumulocity IoT.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class OperationsApi : AdaptableApi, IOperationsApi
	{
		public OperationsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<OperationCollection<TOperation>?> GetOperations<TOperation>(string? agentId = null, string? bulkOperationId = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? fragmentType = null, int? pageSize = null, bool? revert = null, string? status = null, bool? withTotalElements = null, bool? withTotalPages = null) where TOperation : Operation
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/operations";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"agentId", agentId},
				{"bulkOperationId", bulkOperationId},
				{"currentPage", currentPage},
				{"dateFrom", dateFrom},
				{"dateTo", dateTo},
				{"deviceId", deviceId},
				{"fragmentType", fragmentType},
				{"pageSize", pageSize},
				{"revert", revert},
				{"status", status},
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
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operationcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<OperationCollection<TOperation>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<TOperation?> CreateOperation<TOperation>(TOperation body) where TOperation : Operation
		{
			var jsonNode = ToJsonNode<TOperation>(body);
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("deviceExternalIDs", "self");
			jsonNode?.RemoveFromNode("bulkOperationId");
			jsonNode?.RemoveFromNode("failureReason");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/operations";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.operation+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.operation+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operation+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TOperation?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteOperations(string? agentId = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? status = null) 
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/operations";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"agentId", agentId},
				{"dateFrom", dateFrom},
				{"dateTo", dateTo},
				{"deviceId", deviceId},
				{"status", status}
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
		public async Task<TOperation?> GetOperation<TOperation>(string id) where TOperation : Operation
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/operations/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operation+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TOperation?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<TOperation?> UpdateOperation<TOperation>(TOperation body, string id) where TOperation : Operation
		{
			var jsonNode = ToJsonNode<TOperation>(body);
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("deviceExternalIDs", "self");
			jsonNode?.RemoveFromNode("com_cumulocity_model_WebCamDevice");
			jsonNode?.RemoveFromNode("bulkOperationId");
			jsonNode?.RemoveFromNode("failureReason");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("deviceId");
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/operations/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.operation+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.operation+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.operation+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TOperation?>(responseStream);
		}
	}
	#nullable disable
}
