///
/// TrustedCertificatesApi.cs
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
	/// API methods for managing trusted certificates used to establish device connections via MQTT. <br />
	/// More detailed information about trusted certificates and their role can be found in <see href="https://cumulocity.com/guides/users-guide/device-management/#managing-device-data" langword="Device management > Managing device data" /> in the User guide. <br />
	/// ⓘ Info: The Accept header must be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class TrustedCertificatesApi : AdaptableApi, ITrustedCertificatesApi
	{
		public TrustedCertificatesApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<TrustedCertificateCollection?> GetTrustedCertificates(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificateCollection?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificate?> AddTrustedCertificate(UploadedTrustedCertificate body, string tenantId, string? xCumulocityProcessingMode = null, bool? addToTrustStore = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<UploadedTrustedCertificate>(body);
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("addToTrustStore", addToTrustStore);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificateCollection?> AddTrustedCertificates(UploadedTrustedCertificateCollection body, string tenantId, bool? addToTrustStore = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<UploadedTrustedCertificateCollection>(body);
			jsonNode?.RemoveFromNode("next");
			jsonNode?.RemoveFromNode("prev");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("statistics");
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates/bulk";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("addToTrustStore", addToTrustStore);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificateCollection?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificate?> GetTrustedCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates/{fingerprint}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificate?> UpdateTrustedCertificate(TrustedCertificate body, string tenantId, string fingerprint, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<TrustedCertificate>(body);
			jsonNode?.RemoveFromNode("proofOfPossessionValid");
			jsonNode?.RemoveFromNode("notAfter");
			jsonNode?.RemoveFromNode("serialNumber");
			jsonNode?.RemoveFromNode("proofOfPossessionVerificationCodeUsableUntil");
			jsonNode?.RemoveFromNode("subject");
			jsonNode?.RemoveFromNode("algorithmName");
			jsonNode?.RemoveFromNode("version");
			jsonNode?.RemoveFromNode("issuer");
			jsonNode?.RemoveFromNode("notBefore");
			jsonNode?.RemoveFromNode("proofOfPossessionUnsignedVerificationCode");
			jsonNode?.RemoveFromNode("fingerprint");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("certInPemFormat");
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates/{fingerprint}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> RemoveTrustedCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates/{fingerprint}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificate?> ProveCertificatePossession(UploadedTrustedCertSignedVerificationCode body, string tenantId, string fingerprint, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<UploadedTrustedCertSignedVerificationCode>(body);
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates-pop/{fingerprint}/pop";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificate?> ConfirmCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates-pop/{fingerprint}/confirmed";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<TrustedCertificate?> GenerateVerificationCode(string tenantId, string fingerprint, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/{tenantId}/trusted-certificates-pop/{fingerprint}/verification-code";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<VerifyCertificateChain?> ValidateChainByFileUpload(string tenantId, byte[] file, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/verify-cert-chain/fileUpload";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var requestContent = new MultipartFormDataContent();
			var fileContentTenantId = new StringContent(JsonSerializer.Serialize(tenantId));
			fileContentTenantId.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
			requestContent.Add(fileContentTenantId, "tenantId");
			var fileContentFile = new ByteArrayContent(file);
			fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
			requestContent.Add(fileContentFile, "file");
			using var request = new HttpRequestMessage 
			{
				Content = requestContent,
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<VerifyCertificateChain?>(responseStream, cancellationToken: cToken);
		}
		
		/// <inheritdoc />
		public async Task<VerifyCertificateChain?> ValidateChainByHeader(string? xCumulocityTenantId = null, string? xCumulocityClientCertChain = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/tenants/verify-cert-chain";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-TenantId", xCumulocityTenantId);
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Client-Cert-Chain", xCumulocityClientCertChain);
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<VerifyCertificateChain?>(responseStream, cancellationToken: cToken);
		}
	}
	#nullable disable
}
