///
/// DeviceStatistics.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// Statistics of a specific device (identified by an ID). <br />
	/// </summary>
	///
	public class DeviceStatistics 
	{
	
		/// <summary> 
		/// Sum of measurements, events and alarms created and updated for the specified device. <br />
		/// </summary>
		///
		[JsonPropertyName("count")]
		public int? Count { get; set; }
	
		/// <summary> 
		/// Unique identifier of the device. <br />
		/// </summary>
		///
		[JsonPropertyName("deviceId")]
		public string? DeviceId { get; set; }
	
		/// <summary> 
		/// List of unique identifiers of parents for the corresponding device. Available only with monthly data. <br />
		/// </summary>
		///
		[JsonPropertyName("deviceParents")]
		public List<string> DeviceParents { get; set; } = new List<string>();
	
		/// <summary> 
		/// Value of the <c>type</c> field from the corresponding device. Available only with monthly data. <br />
		/// </summary>
		///
		[JsonPropertyName("deviceType")]
		public string? DeviceType { get; set; }
	
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
