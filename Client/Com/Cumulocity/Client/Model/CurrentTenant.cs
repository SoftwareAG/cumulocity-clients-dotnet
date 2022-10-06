///
/// CurrentTenant.cs
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
	public class CurrentTenant<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary>
		/// Indicates if this tenant can create subtenants.
		/// </summary>
		[JsonPropertyName("allowCreateTenants")]
		public bool? AllowCreateTenants { get; set; }
	
		/// <summary>
		/// Collection of the subscribed applications.
		/// </summary>
		[JsonPropertyName("applications")]
		public Applications? PApplications { get; set; }
	
		/// <summary>
		/// An object with a list of custom properties.
		/// </summary>
		[JsonPropertyName("customProperties")]
		public TCustomProperties? PCustomProperties { get; set; }
	
		/// <summary>
		/// URL of the tenant's domain. The domain name permits only the use of alphanumeric characters separated by dots `.`, hyphens `-` and underscores `_`.
		/// </summary>
		[JsonPropertyName("domainName")]
		public string? DomainName { get; set; }
	
		/// <summary>
		/// Unique identifier of a Cumulocity IoT tenant.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of the subscribed applications.
		/// </summary>
		public class Applications 
		{
		
			/// <summary>
			/// An array containing all subscribed applications.
			/// </summary>
			[JsonPropertyName("references")]
			public List<Application>? References { get; set; }
		
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
