///
/// C8yCommand.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// To carry out interactive sessions with a device, use the `c8y_Command` fragment. If this fragment is in the list of supported operations for a device, a tab `Shell` will be shown. Using the `Shell` tab, the user can send commands in an arbitrary, device-specific syntax to the device. The command is sent to the device in a property `text`.
	/// </summary>
	public class C8yCommand 
	{
	
		/// <summary>
		/// The command sent to the device.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary>
		/// To communicate the results of a particular command, the device adds a property `result`.
		/// </summary>
		[JsonPropertyName("result")]
		public string? Result { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
