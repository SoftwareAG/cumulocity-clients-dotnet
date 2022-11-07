///
/// C8yRequiredAvailability.cs
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
	/// Devices can be monitored for availability by adding a `c8y_RequiredAvailability` fragment to the device.
	/// 
	/// Devices that have not sent any message in the response interval are considered disconnected. The response interval can have a value between `-32768` and `32767` and any values out of range will be shrunk to the range borders. Such devices are marked as unavailable and an unavailability alarm is raised.
	/// 
	/// </summary>
	public class C8yRequiredAvailability 
	{
	
		[JsonPropertyName("responseInterval")]
		public int? ResponseInterval { get; set; }
	
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
