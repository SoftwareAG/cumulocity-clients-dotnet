///
/// MeasurementApiResource.cs
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
	public class MeasurementApiResource<TMeasurement> where TMeasurement : Measurement
	{
	
		/// <summary> 
		/// Collection of all measurements <br />
		/// </summary>
		///
		[JsonPropertyName("measurements")]
		public Measurements<TMeasurement>? PMeasurements { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements for a specific source object. The placeholder {source} must be a unique ID of an object in the inventory. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForSource")]
		public string? MeasurementsForSource { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements of a particular type and a specific source object. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForSourceAndType")]
		public string? MeasurementsForSourceAndType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements of a particular type. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForType")]
		public string? MeasurementsForType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements containing a particular fragment type. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForValueFragmentType")]
		public string? MeasurementsForValueFragmentType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements for a particular time range. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForDate")]
		public string? MeasurementsForDate { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements for a specific source object in a particular time range. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForSourceAndDate")]
		public string? MeasurementsForSourceAndDate { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements for a specific fragment type and a particular time range. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForDateAndFragmentType")]
		public string? MeasurementsForDateAndFragmentType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all measurements for a specific source object, particular fragment type and series, and an event type. <br />
		/// </summary>
		///
		[JsonPropertyName("measurementsForSourceAndValueFragmentTypeAndValueFragmentSeries")]
		public string? MeasurementsForSourceAndValueFragmentTypeAndValueFragmentSeries { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Collection of all measurements <br />
		/// </summary>
		///
		public class Measurements<TMeasurement> where TMeasurement : Measurement
		{
		
			[JsonPropertyName("measurements")]
			public List<TMeasurement> PMeasurements { get; set; } = new List<TMeasurement>();
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
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
