///
/// IdentityApi.cs
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
	/// Cumulocity IoT can associate devices and assets with multiple external identities.
	/// For instance, devices can often be identified by the IMEI of their modem, by a micro-controller serial number or by an asset tag.
	/// This is useful, for example, when you have non-functional hardware and must replace the hardware without losing the data that was recorded.
	/// 
	/// The identity API resource returns URIs and URI templates for associating external identifiers with unique identifiers.
	/// 
	/// </summary>
	#nullable enable
	public class IdentityApi : AdaptableApi, IIdentityApi
	{
		public IdentityApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<IdentityApiResource?> GetIdentityApiResource() 
		{
			var client = HttpClient;
			var resourcePath = $"/identity";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.identityapi+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<IdentityApiResource?>(responseStream);
		}
	}
	#nullable disable
}
