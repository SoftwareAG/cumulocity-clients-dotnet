///
/// Tenant.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class Tenant<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary> 
		/// Email address of the tenant's administrator. <br />
		/// </summary>
		///
		[JsonPropertyName("adminEmail")]
		public string? AdminEmail { get; set; }
	
		/// <summary> 
		/// Username of the tenant's administrator. <br />
		/// ⓘ Info: When it is provided in the request body, also <c>adminEmail</c> and <c>adminPass</c> must be provided. <br />
		/// </summary>
		///
		[JsonPropertyName("adminName")]
		public string? AdminName { get; set; }
	
		/// <summary> 
		/// Password of the tenant's administrator. <br />
		/// </summary>
		///
		[JsonPropertyName("adminPass")]
		public string? AdminPass { get; set; }
	
		/// <summary> 
		/// Indicates if this tenant can create subtenants. <br />
		/// </summary>
		///
		[JsonPropertyName("allowCreateTenants")]
		public bool? AllowCreateTenants { get; set; }
	
		/// <summary> 
		/// Collection of the subscribed applications. <br />
		/// </summary>
		///
		[JsonPropertyName("applications")]
		public Applications? PApplications { get; set; }
	
		/// <summary> 
		/// Tenant's company name. <br />
		/// </summary>
		///
		[JsonPropertyName("company")]
		public string? Company { get; set; }
	
		/// <summary> 
		/// Name of the contact person. <br />
		/// </summary>
		///
		[JsonPropertyName("contactName")]
		public string? ContactName { get; set; }
	
		/// <summary> 
		/// Phone number of the contact person, provided in the international format, for example, +48 123 456 7890. <br />
		/// </summary>
		///
		[JsonPropertyName("contactPhone")]
		public string? ContactPhone { get; set; }
	
		/// <summary> 
		/// The date and time when the tenant was created. <br />
		/// </summary>
		///
		[JsonPropertyName("creationTime")]
		public System.DateTime? CreationTime { get; set; }
	
		/// <summary> 
		/// An object with a list of custom properties. <br />
		/// </summary>
		///
		[JsonPropertyName("customProperties")]
		public TCustomProperties? PCustomProperties { get; set; }
	
		/// <summary> 
		/// URL of the tenant's domain. The domain name permits only the use of alphanumeric characters separated by dots <c>.</c> and hyphens <c>-</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("domain")]
		public string? Domain { get; set; }
	
		/// <summary> 
		/// Unique identifier of a Cumulocity IoT tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// Collection of the owned applications. <br />
		/// </summary>
		///
		[JsonPropertyName("ownedApplications")]
		public OwnedApplications? POwnedApplications { get; set; }
	
		/// <summary> 
		/// ID of the parent tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("parent")]
		public string? Parent { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Current status of the tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		/// <summary> 
		/// Current status of the tenant. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Status 
		{
			[EnumMember(Value = "ACTIVE")]
			ACTIVE,
			[EnumMember(Value = "SUSPENDED")]
			SUSPENDED
		}
	
		/// <summary> 
		/// Collection of the subscribed applications. <br />
		/// </summary>
		///
		public class Applications 
		{
		
			/// <summary> 
			/// An array containing all subscribed applications. <br />
			/// </summary>
			///
			[JsonPropertyName("references")]
			public List<Application> References { get; set; } = new List<Application>();
		
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
	
		/// <summary> 
		/// Collection of the owned applications. <br />
		/// </summary>
		///
		public class OwnedApplications 
		{
		
			/// <summary> 
			/// An array containing all owned applications (only applications with availability MARKET). <br />
			/// </summary>
			///
			[JsonPropertyName("references")]
			public List<Application> References { get; set; } = new List<Application>();
		
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
