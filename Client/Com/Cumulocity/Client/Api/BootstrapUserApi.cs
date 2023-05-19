//
// BootstrapUserApi.cs
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
/// API methods to retrieve the bootstrap user of an application. <br />
/// </summary>
///
public sealed class BootstrapUserApi : IBootstrapUserApi
{
	private readonly HttpClient _httpClient;

	public BootstrapUserApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<BootstrapUser?> GetBootstrapUser(string id, CancellationToken cToken = default) 
	{
		string resourcePath = $"/application/applications/{HttpUtility.UrlEncode(id.GetStringValue())}/bootstrapUser";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.user+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<BootstrapUser?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
	}
}
