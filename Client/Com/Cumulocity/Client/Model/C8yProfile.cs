//
// C8yProfile.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Device capability to manage device profiles. Device profiles represent a combination of a firmware version, one or multiple software packages and one or multiple configuration files which can be deployed on a device. <br />
/// </summary>
///
public sealed class C8yProfile 
{

	/// <summary> 
	/// The name of the profile. <br />
	/// </summary>
	///
	[JsonPropertyName("profileName")]
	public string? ProfileName { get; set; }

	/// <summary> 
	/// The ID of the profile. <br />
	/// </summary>
	///
	[JsonPropertyName("profileId")]
	public string? ProfileId { get; set; }

	/// <summary> 
	/// Indicates whether the profile has been executed. <br />
	/// </summary>
	///
	[JsonPropertyName("profileExecuted")]
	public bool? ProfileExecuted { get; set; }

	public override string ToString()
	{
		var jsonOptions = new JsonSerializerOptions() 
		{ 
			WriteIndented = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};
		return JsonSerializer.Serialize(this, jsonOptions);
	}
}
