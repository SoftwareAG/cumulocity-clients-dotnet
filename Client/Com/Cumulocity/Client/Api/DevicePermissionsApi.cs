//
// DevicePermissionsApi.cs
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
public sealed class DevicePermissionsApi : IDevicePermissionsApi
{
	private readonly HttpClient _httpClient;

	public DevicePermissionsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<DevicePermissionOwners<TCustomProperties>?> GetDevicePermissionAssignments<TCustomProperties>(string id, CancellationToken cToken = default) where TCustomProperties : CustomProperties
	{
		string resourcePath = $"/user/devicePermissions/{HttpUtility.UrlEncode(id.GetStringValue())}";
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
		return await JsonSerializerWrapper.DeserializeAsync<DevicePermissionOwners<TCustomProperties>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<string?> UpdateDevicePermissionAssignments(UpdatedDevicePermissions body, string id, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<UpdatedDevicePermissions>();
		string resourcePath = $"/user/devicePermissions/{HttpUtility.UrlEncode(id.GetStringValue())}";
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
}
