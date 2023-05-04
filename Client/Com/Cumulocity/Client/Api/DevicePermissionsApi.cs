///
/// DevicePermissionsApi.cs
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
	/// API methods to retrieve and update device permissions assignments. <br />
	/// Device permissions enable users to access and manipulate devices. <br />
	/// The device permission structure is [API:fragment_name:permission] where: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>API is one of the following values: OPERATION, ALARM, AUDIT, EVENT, MANAGED_OBJECT, MEASUREMENT or "*" <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>fragment_name can be the name of any fragment, for example, "c8y_Restart" or "*" <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>permission is ADMIN, READ or "*" <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// Required permission per HTTP method: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>GET - READ or "*" <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>PUT - ADMIN or "*" <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// The wildcard "*" enables you to access every API and stored object regardless of the fragments that are inside it. <br />
	/// ⚠️ Important: If there is no fragment in an object, for example, to read the object, you must use the wildcard "*" for the fragment_name part of the device permission (see the structure above). For example: <c>"10200":["MEASUREMENT:*:READ"]</c>. <br />
	/// </summary>
	///
	#nullable enable
	public class DevicePermissionsApi : AdaptableApi, IDevicePermissionsApi
	{
		public DevicePermissionsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<DevicePermissions<TCustomProperties>?> GetDevicePermissionAssignments<TCustomProperties>(string id, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var client = HttpClient;
			var resourcePath = $"/user/devicePermissions/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<DevicePermissions<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> UpdateDevicePermissionAssignments<TCustomProperties>(DevicePermissions<TCustomProperties> body, string id, CancellationToken cToken = default) where TCustomProperties : CustomProperties
		{
			var jsonNode = ToJsonNode<DevicePermissions<TCustomProperties>>(body);
			var client = HttpClient;
			var resourcePath = $"/user/devicePermissions/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return responseStream;
		}
	}
	#nullable disable
}
