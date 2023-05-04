///
/// ApplicationVersionsApi.cs
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
	/// API methods to retrieve, create, update and delete application versions. <br />
	/// </summary>
	///
	#nullable enable
	public class ApplicationVersionsApi : AdaptableApi, IApplicationVersionsApi
	{
		public ApplicationVersionsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<ApplicationVersion?> GetApplicationVersion(string id, string? version = null, string? tag = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/application/applications/{id}/versions?version=1.0";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("version", version);
			queryString.AddIfRequired("tag", tag);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationVersion+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ApplicationVersion?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<ApplicationVersionCollection?> GetApplicationVersions(string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/application/applications/{id}/versions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationVersionCollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ApplicationVersionCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<ApplicationVersion?> CreateApplicationVersion(byte[] applicationBinary, string applicationVersion, string id, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/application/applications/{id}/versions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var requestContent = new MultipartFormDataContent();
			var fileContentApplicationBinary = new ByteArrayContent(applicationBinary);
			fileContentApplicationBinary.Headers.ContentType = MediaTypeHeaderValue.Parse("application/zip");
			requestContent.Add(fileContentApplicationBinary, "applicationBinary");
			var fileContentApplicationVersion = new StringContent(JsonSerializer.Serialize(applicationVersion));
			fileContentApplicationVersion.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
			requestContent.Add(fileContentApplicationVersion, "applicationVersion");
			using var request = new HttpRequestMessage 
			{
				Content = requestContent,
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationVersion+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ApplicationVersion?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteApplicationVersion(string id, string? version = null, string? tag = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/application/applications/{id}/versions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("version", version);
			queryString.AddIfRequired("tag", tag);
			uriBuilder.Query = queryString.ToString();
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
		public async Task<ApplicationVersion?> UpdateApplicationVersion(ApplicationVersionTag body, string id, string version, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<ApplicationVersionTag>(body);
			var client = HttpClient;
			var resourcePath = $"/application/applications/{id}/versions/{version}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationVersion+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<ApplicationVersion?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
