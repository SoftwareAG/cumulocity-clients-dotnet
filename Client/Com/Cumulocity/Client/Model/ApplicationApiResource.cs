///
/// ApplicationApiResource.cs
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
	public class ApplicationApiResource 
	{
	
		/// <summary>
		/// Collection of all applications..
		/// </summary>
		[JsonPropertyName("applications")]
		public string? Applications { get; set; }
	
		/// <summary>
		/// A reference to a resource of type Application.
		/// </summary>
		[JsonPropertyName("applicationById")]
		public string? ApplicationById { get; set; }
	
		/// <summary>
		/// Read-only collection of all applications with a particular name.
		/// </summary>
		[JsonPropertyName("applicationsByName")]
		public string? ApplicationsByName { get; set; }
	
		/// <summary>
		/// Read-only collection of all applications subscribed by a particular tenant.
		/// </summary>
		[JsonPropertyName("applicationsByTenant")]
		public string? ApplicationsByTenant { get; set; }
	
		/// <summary>
		/// Read-only collection of all applications owned by a particular tenant.
		/// </summary>
		[JsonPropertyName("applicationsByOwner")]
		public string? ApplicationsByOwner { get; set; }
	
		/// <summary>
		/// Read-only collection of all applications owned by a particular user.
		/// </summary>
		[JsonPropertyName("applicationsByUser")]
		public string? ApplicationsByUser { get; set; }
	
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
}
