///
/// TenantApiResource.cs
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
	public class TenantApiResource<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary> 
		/// Collection of tenant options <br />
		/// </summary>
		///
		[JsonPropertyName("options")]
		public Options? POptions { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Collection of subtenants <br />
		/// </summary>
		///
		[JsonPropertyName("tenants")]
		public Tenants<TCustomProperties>? PTenants { get; set; }
	
		/// <summary> 
		/// Retrieves subscribed applications. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantApplications")]
		public string? TenantApplications { get; set; }
	
		/// <summary> 
		/// Represents an individual application reference that can be viewed. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantApplicationForId")]
		public string? TenantApplicationForId { get; set; }
	
		/// <summary> 
		/// Represents an individual tenant that can be viewed. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantForId")]
		public string? TenantForId { get; set; }
	
		/// <summary> 
		/// Represents a category of tenant options. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantOptionsForCategory")]
		public string? TenantOptionsForCategory { get; set; }
	
		/// <summary> 
		/// Retrieves a key of the category of tenant options. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantOptionForCategoryAndKey")]
		public string? TenantOptionForCategoryAndKey { get; set; }
	
		/// <summary> 
		/// Retrieves the tenant system options. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantSystemOptions")]
		public string? TenantSystemOptions { get; set; }
	
		/// <summary> 
		/// Retrieves the tenant system options based on category and key. <br />
		/// </summary>
		///
		[JsonPropertyName("tenantSystemOptionsForCategoryAndKey")]
		public string? TenantSystemOptionsForCategoryAndKey { get; set; }
	
		/// <summary> 
		/// Collection of tenant options <br />
		/// </summary>
		///
		public class Options 
		{
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("options")]
			public List<Option> POptions { get; set; } = new List<Option>();
		
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
	
		/// <summary> 
		/// Collection of subtenants <br />
		/// </summary>
		///
		public class Tenants<TCustomProperties> where TCustomProperties : CustomProperties
		{
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("tenants")]
			public List<Tenant<TCustomProperties>> PTenants { get; set; } = new List<Tenant<TCustomProperties>>();
		
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
