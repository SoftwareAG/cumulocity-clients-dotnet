///
/// C8yHardware.cs
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
	/// Contains basic hardware information for a device, such as make and serial number. Often, the hardware serial number is printed on the board of the device or on an asset tag on the device to uniquely identify the device within all devices of the same make.
	/// </summary>
	public class C8yHardware 
	{
	
		/// <summary>
		/// A text identifier of the device's hardware model.
		/// </summary>
		[JsonPropertyName("model")]
		public string? Model { get; set; }
	
		/// <summary>
		/// A text identifier of the hardware revision.
		/// </summary>
		[JsonPropertyName("revision")]
		public string? Revision { get; set; }
	
		/// <summary>
		/// The hardware serial number of the device.
		/// </summary>
		[JsonPropertyName("serialNumber")]
		public string? SerialNumber { get; set; }
	
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
