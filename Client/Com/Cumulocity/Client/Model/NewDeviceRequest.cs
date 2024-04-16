//
// NewDeviceRequest.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class NewDeviceRequest 
{

	/// <summary> 
	/// External ID of the device. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary> 
	/// ID of the group to which the device will be assigned. <br />
	/// </summary>
	///
	[JsonPropertyName("groupId")]
	public string? GroupId { get; set; }

	/// <summary> 
	/// Type of the device. <br />
	/// </summary>
	///
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary> 
	/// Tenant who owns the device. <br />
	/// </summary>
	///
	[JsonPropertyName("tenantId")]
	public string? TenantId { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// Status of this new device request. <br />
	/// </summary>
	///
	[JsonPropertyName("status")]
	public Status? PStatus { get; set; }

	/// <summary> 
	/// Owner of the device. <br />
	/// </summary>
	///
	[JsonPropertyName("owner")]
	public string? Owner { get; set; }

	/// <summary> 
	/// Date and time when the device was created in the database. <br />
	/// </summary>
	///
	[JsonPropertyName("creationTime")]
	public System.DateTime? CreationTime { get; set; }

	/// <summary> 
	/// When accepting a device request, the security token is verified against the token submitted by the device when requesting credentials.See <see href="https://cumulocity.com/docs/device-management-application/registering-devices/#security-token-policy" langword="Security token policy" /> for details on configuration.See <see href="/#operation/postDeviceCredentialsCollectionResource" langword="Create device credentials" /> for details on creating token for device registration.<c>securityToken</c> parameter can be added only when submitting <c>ACCEPTED</c> status. <br />
	/// </summary>
	///
	[JsonPropertyName("securityToken")]
	public string? SecurityToken { get; set; }

	/// <summary> 
	/// Status of this new device request. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Status 
	{
		[EnumMember(Value = "WAITING_FOR_CONNECTION")]
		WAITINGFORCONNECTION,
		[EnumMember(Value = "PENDING_ACCEPTANCE")]
		PENDINGACCEPTANCE,
		[EnumMember(Value = "ACCEPTED")]
		ACCEPTED
	}


	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
