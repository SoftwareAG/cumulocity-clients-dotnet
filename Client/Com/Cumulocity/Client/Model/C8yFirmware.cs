//
// C8yFirmware.cs
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

/// <summary> 
/// Contains information on a device's firmware. In the inventory, <c>c8y_Firmware</c> represents the currently installed firmware on the device. As part of an operation, <c>c8y_Firmware</c> requests the device to install the indicated firmware. To enable firmware installation through the user interface, add <c>c8y_Firmware</c> to the list of supported operations. <br />
/// </summary>
///
public sealed class C8yFirmware 
{

	/// <summary> 
	/// Name of the firmware. <br />
	/// </summary>
	///
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary> 
	/// A version identifier of the firmware. <br />
	/// </summary>
	///
	[JsonPropertyName("version")]
	public string? Version { get; set; }

	/// <summary> 
	/// A URI linking to the location to download the firmware from. <br />
	/// </summary>
	///
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
