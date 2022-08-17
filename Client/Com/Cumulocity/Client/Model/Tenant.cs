///
/// Tenant.cs
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
	public class Tenant 
	{
	
		/// <summary>
		/// Email address of the tenant's administrator.
		/// </summary>
		[JsonPropertyName("adminEmail")]
		public string? AdminEmail { get; set; }
	
		/// <summary>
		/// Username of the tenant's administrator.
		/// > **&#9432; Info:** When it is provided in the request body, also `adminEmail` and `adminPass` must be provided.
		/// 
		/// </summary>
		[JsonPropertyName("adminName")]
		public string? AdminName { get; set; }
	
		/// <summary>
		/// Password of the tenant's administrator.
		/// </summary>
		[JsonPropertyName("adminPass")]
		public string? AdminPass { get; set; }
	
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
		/// Tenant's company name.
		/// </summary>
		[JsonPropertyName("company")]
		public string? Company { get; set; }
	
		/// <summary>
		/// Name of the contact person.
		/// </summary>
		[JsonPropertyName("contactName")]
		public string? ContactName { get; set; }
	
		/// <summary>
		/// Phone number of the contact person, provided in the international format, for example, +48 123 456 7890.
		/// </summary>
		[JsonPropertyName("contactPhone")]
		public string? ContactPhone { get; set; }
	
		/// <summary>
		/// The date and time when the tenant was created.
		/// </summary>
		[JsonPropertyName("creationTime")]
		public System.DateTime? CreationTime { get; set; }
	
		/// <summary>
		/// An object with a list of custom properties.
		/// </summary>
		[JsonPropertyName("customProperties")]
		public CustomProperties? PCustomProperties { get; set; }
	
		/// <summary>
		/// URL of the tenant's domain. The domain name permits only the use of alphanumeric characters separated by dots `.`, hyphens `-` and underscores `_`.
		/// </summary>
		[JsonPropertyName("domain")]
		public string? Domain { get; set; }
	
		/// <summary>
		/// Unique identifier of a Cumulocity IoT tenant.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// Collection of the owned applications.
		/// </summary>
		[JsonPropertyName("ownedApplications")]
		public OwnedApplications? POwnedApplications { get; set; }
	
		/// <summary>
		/// ID of the parent tenant.
		/// </summary>
		[JsonPropertyName("parent")]
		public string? Parent { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Current status of the tenant.
		/// </summary>
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		/// <summary>
		/// Current status of the tenant.
		/// [ACTIVE, SUSPENDED]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Status 
		{
			[EnumMember(Value = "ACTIVE")]
			ACTIVE,
			[EnumMember(Value = "SUSPENDED")]
			SUSPENDED
		}
	
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
	
		/// <summary>
		/// Collection of the owned applications.
		/// </summary>
		public class OwnedApplications 
		{
		
			/// <summary>
			/// An array containing all owned applications (only applications with availability MARKET).
			/// </summary>
			[JsonPropertyName("references")]
			public List<Application>? References { get; set; }
		
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
