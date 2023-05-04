///
/// SystemOptionsApi.cs
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
	/// API methods to retrieve the read-only properties predefined in the platform's configuration. <br />
	/// For security reasons, a few system options are considered secured, which means the user must have the required role ROLE_OPTION_MANAGEMENT_ADMIN to read their values. <br />
	/// List of options: <br />
	/// |         Category          | Key                           | Considered as secured ||:-------------------------:|:------------------------------|:----------------------||         password          | green.min-length              | yes                   || two-factor-authentication | pin.validity                  | yes                   || two-factor-authentication | token.length                  | yes                   || two-factor-authentication | token.validity                | yes                   ||      authentication       | badRequestCounter             | yes                   ||           files           | microservice.zipped.max.size  | yes                   ||           files           | microservice.unzipped.max.size| yes                   ||           files           | webapp.zipped.max.size        | yes                   ||           files           | webapp.unzipped.max.size      | yes                   || two-factor-authentication | enforced                      | no                    ||       reportMailer        | available                     | no                    ||          system           | version                       | no                    ||          plugin           | eventprocessing.enabled       | no                    ||         password          | limit.validity                | no                    ||         password          | enforce.strength              | no                    || two-factor-authentication | strategy                      | no                    || two-factor-authentication | pin.length                    | no                    || two-factor-authentication | enabled                       | no                    || two-factor-authentication | enforced.group                | no                    || two-factor-authentication | tenant-scope-settings.enabled | no                    || two-factor-authentication | logout-on-browser-termination | no                    ||       connectivity        | microservice.url              | no                    ||       support-user        | enabled                       | no                    ||          support          | url                           | no                    ||         trackers          | supported.models              | no                    ||         encoding          | test                          | no                    ||        data-broker        | bootstrap.period              | no                    ||           files           | max.size                      | no                    ||      device-control       | bulkoperation.creationramp    | no                    ||         gainsight         | api.key                       | no                    ||            cep            | deprecation.alarm             | no                    ||       remoteaccess        | pass-through.enabled          | no                    ||    device-registration    | security-token.policy         | no                    | <br />
	/// </summary>
	///
	#nullable enable
	public class SystemOptionsApi : AdaptableApi, ISystemOptionsApi
	{
		public SystemOptionsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<SystemOptionCollection?> GetSystemOptions(CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/system/options";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.optioncollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<SystemOptionCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<SystemOption?> GetSystemOption(string category, string key, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/system/options/{category}/{key}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.option+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<SystemOption?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
