///
/// DeviceCredentialsApi.cs
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
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to create device credentials in Cumulocity IoT. <br />
	/// Device credentials can be enquired by devices that do not have credentials for accessing a tenant yet.Since the device does not have credentials yet, a set of fixed credentials is used for this API.The credentials can be obtained by <see href="https://cumulocity.com/guides/about-doc/contacting-support/" langword="contacting support" />. <br />
	/// ⚠️ Important: Do not use your tenant credentials with this API. <br />
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class DeviceCredentialsApi : AdaptableApi, IDeviceCredentialsApi
	{
		public DeviceCredentialsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<DeviceCredentials?> CreateDeviceCredentials(DeviceCredentials body, string? xCumulocityProcessingMode = null) 
		{
			var jsonNode = ToJsonNode<DeviceCredentials>(body);
			jsonNode?.RemoveFromNode("password");
			jsonNode?.RemoveFromNode("tenantId");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("username");
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/deviceCredentials";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.devicecredentials+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.devicecredentials+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.devicecredentials+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<DeviceCredentials?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<BulkNewDeviceRequest?> CreateBulkDeviceCredentials(byte[] file, string? xCumulocityProcessingMode = null) 
		{
			var client = HttpClient;
			var resourcePath = $"/devicecontrol/bulkNewDeviceRequests";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var requestContent = new MultipartFormDataContent();
			var fileContentFile = new ByteArrayContent(file);
			fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
			requestContent.Add(fileContentFile, "file");
			var request = new HttpRequestMessage 
			{
				Content = requestContent,
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.bulknewdevicerequest+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<BulkNewDeviceRequest?>(responseStream);
		}
	}
	#nullable disable
}
