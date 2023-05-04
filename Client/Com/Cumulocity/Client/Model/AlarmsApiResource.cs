///
/// AlarmsApiResource.cs
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
	public class AlarmsApiResource<TAlarm> where TAlarm : Alarm
	{
	
		/// <summary> 
		/// Collection of all alarms <br />
		/// </summary>
		///
		[JsonPropertyName("alarms")]
		public Alarms<TAlarm>? PAlarms { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms for a specific source object. The placeholder {source} must be a unique ID of an object in the inventory. <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForSource")]
		public string? AlarmsForSource { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms in a particular status. The placeholder {status} can be one of the following values: ACTIVE, ACKNOWLEDGED or CLEARED <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForStatus")]
		public string? AlarmsForStatus { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms for a specific source, status and time range. <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForSourceAndStatusAndTime")]
		public string? AlarmsForSourceAndStatusAndTime { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms for a particular status and time range. <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForStatusAndTime")]
		public string? AlarmsForStatusAndTime { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms for a specific source and time range. <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForSourceAndTime")]
		public string? AlarmsForSourceAndTime { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms for a particular time range. <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForTime")]
		public string? AlarmsForTime { get; set; }
	
		/// <summary> 
		/// Read-only collection of all alarms for a specific source object in a particular status. <br />
		/// </summary>
		///
		[JsonPropertyName("alarmsForSourceAndStatus")]
		public string? AlarmsForSourceAndStatus { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Collection of all alarms <br />
		/// </summary>
		///
		public class Alarms<TAlarm> where TAlarm : Alarm
		{
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("alarms")]
			public List<TAlarm> PAlarms { get; set; } = new List<TAlarm>();
		
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
