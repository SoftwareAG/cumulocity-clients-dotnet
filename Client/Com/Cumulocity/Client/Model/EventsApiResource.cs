///
/// EventsApiResource.cs
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
	public class EventsApiResource<TEvent> where TEvent : Event
	{
	
		/// <summary> 
		/// Collection of all events <br />
		/// </summary>
		///
		[JsonPropertyName("events")]
		public Events<TEvent>? PEvents { get; set; }
	
		/// <summary> 
		/// Read-only collection of all events for a specific source object. The placeholder {source} must be a unique ID of an object in the inventory. <br />
		/// </summary>
		///
		[JsonPropertyName("eventsForSource")]
		public string? EventsForSource { get; set; }
	
		/// <summary> 
		/// Read-only collection of all events of a particular type and a specific source object. <br />
		/// </summary>
		///
		[JsonPropertyName("eventsForSourceAndType")]
		public string? EventsForSourceAndType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all events of a particular type. <br />
		/// </summary>
		///
		[JsonPropertyName("eventsForType")]
		public string? EventsForType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all events containing a particular fragment type. <br />
		/// </summary>
		///
		[JsonPropertyName("eventsForFragmentType")]
		public string? EventsForFragmentType { get; set; }
	
		/// <summary> 
		/// Read-only collection of all events for a particular time range. <br />
		/// </summary>
		///
		[JsonPropertyName("eventsForTime")]
		public string? EventsForTime { get; set; }
	
		/// <summary> 
		/// Read-only collection of all events for a specific source object in a particular time range. <br />
		/// </summary>
		///
		[JsonPropertyName("eventsForSourceAndTime")]
		public string? EventsForSourceAndTime { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Collection of all events <br />
		/// </summary>
		///
		public class Events<TEvent> where TEvent : Event
		{
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("events")]
			public List<TEvent> PEvents { get; set; } = new List<TEvent>();
		
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
