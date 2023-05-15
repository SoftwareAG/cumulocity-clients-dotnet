//
// C8yCommand.cs
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
/// To carry out interactive sessions with a device, use the <c>c8y_Command</c> fragment. If this fragment is in the list of supported operations for a device, a tab <c>Shell</c> will be shown. Using the <c>Shell</c> tab, the user can send commands in an arbitrary, device-specific syntax to the device. The command is sent to the device in a property <c>text</c>. <br />
/// </summary>
///
public sealed class C8yCommand 
{

	/// <summary> 
	/// The command sent to the device. <br />
	/// </summary>
	///
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary> 
	/// To communicate the results of a particular command, the device adds a property <c>result</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("result")]
	public string? Result { get; set; }

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
