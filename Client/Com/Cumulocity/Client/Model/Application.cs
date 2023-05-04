///
/// Application.cs
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
	public class Application 
	{
	
		/// <summary> 
		/// Application access level for other tenants. <br />
		/// </summary>
		///
		[JsonPropertyName("availability")]
		public Availability? PAvailability { get; set; }
	
		/// <summary> 
		/// The context path in the URL makes the application accessible. Mandatory when the type of the application is <c>HOSTED</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("contextPath")]
		public string? ContextPath { get; set; }
	
		/// <summary> 
		/// Description of the application. <br />
		/// </summary>
		///
		[JsonPropertyName("description")]
		public string? Description { get; set; }
	
		/// <summary> 
		/// Unique identifier of the application. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// Applications, regardless of their form, are identified by an application key. <br />
		/// </summary>
		///
		[JsonPropertyName("key")]
		public string? Key { get; set; }
	
		/// <summary> 
		/// Name of the application. <br />
		/// </summary>
		///
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary> 
		/// Reference to the tenant owning this application. The default value is a reference to the current tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("owner")]
		public ApplicationOwner? Owner { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// The type of the application. <br />
		/// </summary>
		///
		[JsonPropertyName("type")]
		public Type? PType { get; set; }
	
		[JsonPropertyName("manifest")]
		public object? Manifest { get; set; }
	
		/// <summary> 
		/// Roles provided by the microservice. <br />
		/// </summary>
		///
		[JsonPropertyName("roles")]
		public List<string> Roles { get; set; } = new List<string>();
	
		/// <summary> 
		/// List of permissions required by a microservice to work. <br />
		/// </summary>
		///
		[JsonPropertyName("requiredRoles")]
		public List<string> RequiredRoles { get; set; } = new List<string>();
	
		/// <summary> 
		/// A flag to indicate if the application has a breadcrumbs navigation on the UI. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("breadcrumbs")]
		public bool? Breadcrumbs { get; set; }
	
		/// <summary> 
		/// The content security policy of the application. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("contentSecurityPolicy")]
		public string? ContentSecurityPolicy { get; set; }
	
		/// <summary> 
		/// A URL to a JSON object with dynamic content options. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("dynamicOptionsUrl")]
		public string? DynamicOptionsUrl { get; set; }
	
		/// <summary> 
		/// The global title of the application. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("globalTitle")]
		public string? GlobalTitle { get; set; }
	
		/// <summary> 
		/// A flag that shows if the application is a legacy application or not. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("legacy")]
		public bool? Legacy { get; set; }
	
		/// <summary> 
		/// A flag to indicate if the application uses the UI context menu on the right side. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("rightDrawer")]
		public bool? RightDrawer { get; set; }
	
		/// <summary> 
		/// A flag that shows if the application is hybrid and using Angular and AngularJS simultaneously. <br />
		/// ⓘ Info: This property is specific to the web application type. <br />
		/// </summary>
		///
		[JsonPropertyName("upgrade")]
		public bool? Upgrade { get; set; }
	
		/// <summary> 
		/// The active version ID of the application. For microservice applications the active version ID is the microservice manifest version ID. <br />
		/// </summary>
		///
		[JsonPropertyName("activeVersionId")]
		public string? ActiveVersionId { get; set; }
	
		/// <summary> 
		/// URL to the application base directory hosted on an external server. Only present in legacy hosted applications. <br />
		/// </summary>
		///
		[System.ObsoleteAttribute("This property might be removed in future releases.", false)]
		[JsonPropertyName("resourcesUrl")]
		public string? ResourcesUrl { get; set; }
	
		/// <summary> 
		/// Application access level for other tenants. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Availability 
		{
			[EnumMember(Value = "MARKET")]
			MARKET,
			[EnumMember(Value = "PRIVATE")]
			PRIVATE
		}
	
		/// <summary> 
		/// The type of the application. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Type 
		{
			[EnumMember(Value = "EXTERNAL")]
			EXTERNAL,
			[EnumMember(Value = "HOSTED")]
			HOSTED,
			[EnumMember(Value = "MICROSERVICE")]
			MICROSERVICE
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
