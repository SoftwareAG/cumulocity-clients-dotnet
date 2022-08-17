///
/// TenantApiResource.cs
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
	public class TenantApiResource 
	{
	
		/// <summary>
		/// Collection of tenant options
		/// </summary>
		[JsonPropertyName("options")]
		public Options? POptions { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of subtenants
		/// </summary>
		[JsonPropertyName("tenants")]
		public Tenants? PTenants { get; set; }
	
		/// <summary>
		/// Retrieves subscribed applications.
		/// </summary>
		[JsonPropertyName("tenantApplications")]
		public string? TenantApplications { get; set; }
	
		/// <summary>
		/// Represents an individual application reference that can be viewed.
		/// </summary>
		[JsonPropertyName("tenantApplicationForId")]
		public string? TenantApplicationForId { get; set; }
	
		/// <summary>
		/// Represents an individual tenant that can be viewed.
		/// </summary>
		[JsonPropertyName("tenantForId")]
		public string? TenantForId { get; set; }
	
		/// <summary>
		/// Represents a category of tenant options.
		/// </summary>
		[JsonPropertyName("tenantOptionsForCategory")]
		public string? TenantOptionsForCategory { get; set; }
	
		/// <summary>
		/// Retrieves a key of the category of tenant options.
		/// </summary>
		[JsonPropertyName("tenantOptionForCategoryAndKey")]
		public string? TenantOptionForCategoryAndKey { get; set; }
	
		/// <summary>
		/// Retrieves the tenant system options.
		/// </summary>
		[JsonPropertyName("tenantSystemOptions")]
		public string? TenantSystemOptions { get; set; }
	
		/// <summary>
		/// Retrieves the tenant system options based on category and key.
		/// </summary>
		[JsonPropertyName("tenantSystemOptionsForCategoryAndKey")]
		public string? TenantSystemOptionsForCategoryAndKey { get; set; }
	
		/// <summary>
		/// Collection of tenant options
		/// </summary>
		public class Options 
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("options")]
			public List<Option>? POptions { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		/// <summary>
		/// Collection of subtenants
		/// </summary>
		public class Tenants 
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("tenants")]
			public List<Tenant>? PTenants { get; set; }
		
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
