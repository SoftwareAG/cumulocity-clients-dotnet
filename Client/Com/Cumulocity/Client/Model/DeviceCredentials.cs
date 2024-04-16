//
// DeviceCredentials.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class DeviceCredentials 
{

	/// <summary> 
	/// The external ID of the device. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary> 
	/// Password of these device credentials. <br />
	/// </summary>
	///
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// Tenant ID for these device credentials. <br />
	/// </summary>
	///
	[JsonPropertyName("tenantId")]
	public string? TenantId { get; set; }

	/// <summary> 
	/// Username of these device credentials. <br />
	/// </summary>
	///
	[JsonPropertyName("username")]
	public string? Username { get; set; }

	/// <summary> 
	/// Security token which is required and verified against during device request acceptance.See <see href="https://cumulocity.com/docs/device-management-application/registering-devices/#security-token-policy" langword="Security token policy" /> for more details on configuration.See <see href="/#operation/putNewDeviceRequestResource" langword="Update specific new device request status" /> for details on submitting token upon device acceptance. <br />
	/// </summary>
	///
	[JsonPropertyName("securityToken")]
	public string? SecurityToken { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
