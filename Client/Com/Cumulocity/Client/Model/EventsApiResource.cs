///
/// EventsApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class EventsApiResource<TEvent> where TEvent : Event
	{
	
		/// <summary>
		/// Collection of all events
		/// </summary>
		[JsonPropertyName("events")]
		public Events<TEvent>? PEvents { get; set; }
	
		/// <summary>
		/// Read-only collection of all events for a specific source object. The placeholder {source} must be a unique ID of an object in the inventory.
		/// </summary>
		[JsonPropertyName("eventsForSource")]
		public string? EventsForSource { get; set; }
	
		/// <summary>
		/// Read-only collection of all events of a particular type and a specific source object.
		/// </summary>
		[JsonPropertyName("eventsForSourceAndType")]
		public string? EventsForSourceAndType { get; set; }
	
		/// <summary>
		/// Read-only collection of all events of a particular type.
		/// </summary>
		[JsonPropertyName("eventsForType")]
		public string? EventsForType { get; set; }
	
		/// <summary>
		/// Read-only collection of all events containing a particular fragment type.
		/// </summary>
		[JsonPropertyName("eventsForFragmentType")]
		public string? EventsForFragmentType { get; set; }
	
		/// <summary>
		/// Read-only collection of all events for a particular time range.
		/// </summary>
		[JsonPropertyName("eventsForTime")]
		public string? EventsForTime { get; set; }
	
		/// <summary>
		/// Read-only collection of all events for a specific source object in a particular time range.
		/// </summary>
		[JsonPropertyName("eventsForSourceAndTime")]
		public string? EventsForSourceAndTime { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of all events
		/// </summary>
		public class Events<TEvent> where TEvent : Event
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("events")]
			public List<TEvent>? PEvents { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
