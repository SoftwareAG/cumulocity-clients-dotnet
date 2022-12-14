///
/// InventoryApiResource.cs
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
	public class InventoryApiResource<TManagedObject> where TManagedObject : ManagedObject
	{
	
		/// <summary>
		/// Read-only collection of all managed objects with a particular fragment type or capability (placeholder {fragmentType}).
		/// </summary>
		[JsonPropertyName("managedObjectsForFragmentType")]
		public string? ManagedObjectsForFragmentType { get; set; }
	
		/// <summary>
		/// Read-only collection of all managed objects of a particular type (placeholder {type}).
		/// </summary>
		[JsonPropertyName("managedObjectsForType")]
		public string? ManagedObjectsForType { get; set; }
	
		/// <summary>
		/// Read-only collection of managed objects fetched for a given list of ids, for example, “ids=41,43,68”.
		/// </summary>
		[JsonPropertyName("managedObjectsForListOfIds")]
		public string? ManagedObjectsForListOfIds { get; set; }
	
		/// <summary>
		/// Collection of all managed objects
		/// </summary>
		[JsonPropertyName("managedObjects")]
		public ManagedObjects<TManagedObject>? PManagedObjects { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of all managed objects
		/// </summary>
		public class ManagedObjects<TManagedObject> where TManagedObject : ManagedObject
		{
		
			/// <summary>
			/// An array containing the referenced managed objects.
			/// </summary>
			[JsonPropertyName("references")]
			public List<TManagedObject>? References { get; set; }
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
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
