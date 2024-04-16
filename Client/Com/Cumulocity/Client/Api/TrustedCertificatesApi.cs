//
// TrustedCertificatesApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

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
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// API methods for managing trusted certificates used to establish device connections via MQTT. <br />
/// More detailed information about trusted certificates and their role can be found in <see href="https://cumulocity.com/docs/device-management-application/managing-device-data/" langword="Device management > Device management application > Managing device data" /> in the Cumulocity IoT user documentation. <br />
/// ⓘ Info: The Accept header must be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class TrustedCertificatesApi : ITrustedCertificatesApi
{
	private readonly HttpClient _httpClient;

	public TrustedCertificatesApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<TrustedCertificateCollection?> GetTrustedCertificates(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificateCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificate?> AddTrustedCertificate(UploadedTrustedCertificate body, string tenantId, string? xCumulocityProcessingMode = null, bool? addToTrustStore = null, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<UploadedTrustedCertificate>();
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("addToTrustStore", addToTrustStore);
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
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificateCollection?> AddTrustedCertificates(UploadedTrustedCertificateCollection body, string tenantId, bool? addToTrustStore = null, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<UploadedTrustedCertificateCollection>();
		jsonNode?.RemoveFromNode("next");
		jsonNode?.RemoveFromNode("prev");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("statistics");
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates/bulk";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("addToTrustStore", addToTrustStore);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificateCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificate?> GetTrustedCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates/{HttpUtility.UrlPathEncode(fingerprint.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificate?> UpdateTrustedCertificate(TrustedCertificate body, string tenantId, string fingerprint, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<TrustedCertificate>();
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
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates/{HttpUtility.UrlPathEncode(fingerprint.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> RemoveTrustedCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates/{HttpUtility.UrlPathEncode(fingerprint.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificate?> ProveCertificatePossession(UploadedTrustedCertSignedVerificationCode body, string tenantId, string fingerprint, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<UploadedTrustedCertSignedVerificationCode>();
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates-pop/{HttpUtility.UrlPathEncode(fingerprint.GetStringValue())}/pop";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificate?> ConfirmCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates-pop/{HttpUtility.UrlPathEncode(fingerprint.GetStringValue())}/confirmed";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TrustedCertificate?> GenerateVerificationCode(string tenantId, string fingerprint, CancellationToken cToken = default) 
	{
		string resourcePath = $"/tenant/tenants/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/trusted-certificates-pop/{HttpUtility.UrlPathEncode(fingerprint.GetStringValue())}/verification-code";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TrustedCertificate?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<VerifyCertificateChain?> ValidateChain(string tenantId, byte[] file, string? xCumulocityTenantId = null, string? xCumulocityClientCertChain = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/tenant/trusted-certificates/verify-cert-chain";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var requestContent = new MultipartFormDataContent();
		var fileContentTenantId = new StringContent(JsonSerializerWrapper.Serialize(tenantId));
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
		request.Headers.TryAddWithoutValidation("X-Cumulocity-TenantId", xCumulocityTenantId);
		request.Headers.TryAddWithoutValidation("X-Cumulocity-Client-Cert-Chain", xCumulocityClientCertChain);
		request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<VerifyCertificateChain?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<System.IO.Stream> DownloadCrl(string tenantId, CancellationToken cToken = default) 
	{
		const string resourcePath = "/tenant/trusted-certificates/settings/crl";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/pkix-crl");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> UpdateCRL(UpdateCRLEntries body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<UpdateCRLEntries>();
		const string resourcePath = "/tenant/trusted-certificates/settings/crl";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> UpdateCRL(byte[] file, CancellationToken cToken = default) 
	{
		const string resourcePath = "/tenant/trusted-certificates/settings/crl";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var requestContent = new MultipartFormDataContent();
		var fileContentFile = new ByteArrayContent(file);
		fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
		requestContent.Add(fileContentFile, "file");
		using var request = new HttpRequestMessage 
		{
			Content = requestContent,
			Method = HttpMethod.Put,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<AccessToken?> ObtainAccessToken(string? xSslCertChain = null, CancellationToken cToken = default) 
	{
		const string resourcePath = "/devicecontrol/deviceAccessToken";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("X-Ssl-Cert-Chain", xSslCertChain);
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<AccessToken?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
}
