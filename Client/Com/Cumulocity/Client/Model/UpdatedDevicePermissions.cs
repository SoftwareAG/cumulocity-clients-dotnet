//
// UpdatedDevicePermissions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// A list of device permissions. <br />
/// </summary>
///
public sealed class UpdatedDevicePermissions 
{

	[JsonPropertyName("users")]
	public List<Users> PUsers { get; set; } = new List<Users>();

	[JsonPropertyName("groups")]
	public List<Groups> PGroups { get; set; } = new List<Groups>();

	public sealed class Users 
	{
	
		[JsonPropertyName("userName")]
		public string? UserName { get; set; }
	
		/// <summary> 
		/// An object with a list of the user's device permissions. <br />
		/// </summary>
		///
		[System.Obsolete("This property might be removed in future releases.", false)]
		[JsonPropertyName("devicePermissions")]
		public DevicePermissions? PDevicePermissions { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public sealed class Groups 
	{
	
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// An object with a list of the user's device permissions. <br />
		/// </summary>
		///
		[System.Obsolete("This property might be removed in future releases.", false)]
		[JsonPropertyName("devicePermissions")]
		public DevicePermissions? PDevicePermissions { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
