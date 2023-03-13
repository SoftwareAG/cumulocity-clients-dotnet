///
/// ApplicationApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class ApplicationApiResource 
	{
	
		/// <summary> 
		/// Collection of all applications.. <br />
		/// </summary>
		///
		[JsonPropertyName("applications")]
		public string? Applications { get; set; }
	
		/// <summary> 
		/// A reference to a resource of type Application. <br />
		/// </summary>
		///
		[JsonPropertyName("applicationById")]
		public string? ApplicationById { get; set; }
	
		/// <summary> 
		/// Read-only collection of all applications with a particular name. <br />
		/// </summary>
		///
		[JsonPropertyName("applicationsByName")]
		public string? ApplicationsByName { get; set; }
	
		/// <summary> 
		/// Read-only collection of all applications subscribed by a particular tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("applicationsByTenant")]
		public string? ApplicationsByTenant { get; set; }
	
		/// <summary> 
		/// Read-only collection of all applications owned by a particular tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("applicationsByOwner")]
		public string? ApplicationsByOwner { get; set; }
	
		/// <summary> 
		/// Read-only collection of all applications owned by a particular user. <br />
		/// </summary>
		///
		[JsonPropertyName("applicationsByUser")]
		public string? ApplicationsByUser { get; set; }
	
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
}
