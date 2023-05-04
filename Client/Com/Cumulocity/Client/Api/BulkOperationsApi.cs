///
/// BulkOperationsApi.cs
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
	/// The bulk operations API allows to schedule an operation on a group of devices to be executed at a specified time.It is required to specify the delay between the creation of subsequent operations.When the bulk operation is created, it has the status ACTIVE.When all operations are created, the bulk operation has the status COMPLETED.It is also possible to cancel an already created bulk operation by deleting it. <br />
	/// When you create a bulk operation, you can run it in two modes: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>If <c>groupId</c> is passed, it works the standard way, that means, it takes devices from a group and schedules operations on them. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>If <c>failedParentId</c> is passed, it takes the already processed bulk operation by that ID, and schedules operations on devices for which the previous operations failed. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// Note that passing both <c>groupId</c> and <c>failedParentId</c> will not work, and a bulk operation works with groups of type <c>static</c> and <c>dynamic</c>. <br />
	/// ⓘ Info: The bulk operations API requires different roles than the rest of the device control API: <c>BULK_OPERATION_READ</c> and <c>BULK_OPERATION_ADMIN</c>. <br />
	/// The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class BulkOperationsApi : AdaptableApi, IBulkOperationsApi
	{
		public BulkOperationsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<BulkOperationCollection?> GetBulkOperations(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/bulkoperations";
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
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.bulkoperationcollection+json, application/vnd.com.nsn.cumulocity.error+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<BulkOperationCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<BulkOperation?> CreateBulkOperation(BulkOperation body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<BulkOperation>(body);
			jsonNode?.RemoveFromNode("generalStatus");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("progress");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("status");
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/bulkoperations";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.bulkoperation+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.bulkoperation+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.bulkoperation+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<BulkOperation?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<BulkOperation?> GetBulkOperation(string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/bulkoperations/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.bulkoperation+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<BulkOperation?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<BulkOperation?> UpdateBulkOperation(BulkOperation body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<BulkOperation>(body);
			jsonNode?.RemoveFromNode("generalStatus");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("progress");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("status");
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/bulkoperations/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.bulkoperation+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.bulkoperation+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.bulkoperation+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<BulkOperation?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteBulkOperation(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/bulkoperations/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
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
	}
	#nullable disable
}
