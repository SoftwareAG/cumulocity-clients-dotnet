///
/// C8yConfiguration.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// Text configuration fragment that allows you to configure parameters and initial settings of your device. <br />
	/// In the inventory, <c>c8y_Configuration</c> represents the currently active configuration on the device. As part of an operation, <c>c8y_Configuration</c> requests the device to switch the transmitted configuration to the currently active one. To enable configuration through the user interface, add <c>c8y_Configuration</c> to the list of supported operations. <br />
	/// </summary>
	///
	public class C8yConfiguration 
	{
	
		/// <summary> 
		/// A text in a device-specific format, representing the configuration of the device. <br />
		/// </summary>
		///
		[JsonPropertyName("config")]
		public string? Config { get; set; }
	
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
}
