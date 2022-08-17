///
/// MeasurementFragmentSeries.cs
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
	public class MeasurementFragmentSeries 
	{
	
		/// <summary>
		/// The unit of the measurement.
		/// </summary>
		[JsonPropertyName("unit")]
		public string? Unit { get; set; }
	
		/// <summary>
		/// The name of the measurement.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary>
		/// The type of measurement.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
