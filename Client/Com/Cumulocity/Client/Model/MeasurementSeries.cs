///
/// MeasurementSeries.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class MeasurementSeries 
	{
	
		/// <summary>
		/// Each property contained here is a date taken from the measurement and it contains an array of objects specifying `min` and `max` pair of values. Each pair corresponds to a single series object in the `series` array. If there is no aggregation used, `min` is equal to `max` in every pair.
		/// </summary>
		[JsonPropertyName("values")]
		public Values? PValues { get; set; }
	
		/// <summary>
		/// An array containing the type of series and units.
		/// </summary>
		[JsonPropertyName("series")]
		public List<MeasurementFragmentSeries>? Series { get; set; }
	
		/// <summary>
		/// If there were more than 5000 values, the final result was truncated.
		/// </summary>
		[JsonPropertyName("truncated")]
		public bool? Truncated { get; set; }
	
		/// <summary>
		/// Each property contained here is a date taken from the measurement and it contains an array of objects specifying `min` and `max` pair of values. Each pair corresponds to a single series object in the `series` array. If there is no aggregation used, `min` is equal to `max` in every pair.
		/// </summary>
		public class Values 
		{
		
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
