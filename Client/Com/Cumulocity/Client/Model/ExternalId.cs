///
/// ExternalId.cs
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
	public class ExternalId 
	{
	
		/// <summary>
		/// The identifier used in the external system that Cumulocity IoT interfaces with.
		/// </summary>
		[JsonPropertyName("externalId")]
		public string? PExternalId { get; set; }
	
		/// <summary>
		/// The managed object linked to the external ID.
		/// </summary>
		[JsonPropertyName("managedObject")]
		public ManagedObject? PManagedObject { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The type of the external identifier.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		public ExternalId() 
		{
		}
	
		public ExternalId(string externalId, string type)
		{
			this.PExternalId = externalId;
			this.Type = type;
		}
	
		/// <summary>
		/// The managed object linked to the external ID.
		/// </summary>
		public class ManagedObject 
		{
		
			/// <summary>
			/// Unique identifier of the object.
			/// </summary>
			[JsonPropertyName("id")]
			public string? Id { get; set; }
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
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
