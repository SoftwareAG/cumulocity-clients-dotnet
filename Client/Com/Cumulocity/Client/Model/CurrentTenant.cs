///
/// CurrentTenant.cs
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
	public class CurrentTenant<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
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
		/// An object with a list of custom properties. <br />
		/// </summary>
		///
		[JsonPropertyName("customProperties")]
		public TCustomProperties? PCustomProperties { get; set; }
	
		/// <summary> 
		/// URL of the tenant's domain. The domain name permits only the use of alphanumeric characters separated by dots <c>.</c>, hyphens <c>-</c> and underscores <c>_</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("domainName")]
		public string? DomainName { get; set; }
	
		/// <summary> 
		/// Unique identifier of a Cumulocity IoT tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
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
