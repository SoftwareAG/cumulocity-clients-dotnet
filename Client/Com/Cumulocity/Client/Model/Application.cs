///
/// Application.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class Application 
	{
	
		/// <summary>
		/// Application access level for other tenants.
		/// </summary>
		[JsonPropertyName("availability")]
		public Availability? PAvailability { get; set; }
	
		/// <summary>
		/// The context path in the URL makes the application accessible. Mandatory when the type of the application is `HOSTED`.
		/// </summary>
		[JsonPropertyName("contextPath")]
		public string? ContextPath { get; set; }
	
		/// <summary>
		/// Description of the application.
		/// </summary>
		[JsonPropertyName("description")]
		public string? Description { get; set; }
	
		/// <summary>
		/// Unique identifier of the application.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// Applications, regardless of their form, are identified by an application key.
		/// </summary>
		[JsonPropertyName("key")]
		public string? Key { get; set; }
	
		/// <summary>
		/// Name of the application.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary>
		/// Reference to the tenant owning this application. The default value is a reference to the current tenant.
		/// </summary>
		[JsonPropertyName("owner")]
		public ApplicationOwner? Owner { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The type of the application.
		/// </summary>
		[JsonPropertyName("type")]
		public Type? PType { get; set; }
	
		[JsonPropertyName("manifest")]
		public object? Manifest { get; set; }
	
		/// <summary>
		/// Roles provided by the microservice.
		/// </summary>
		[JsonPropertyName("roles")]
		public List<string>? Roles { get; set; }
	
		/// <summary>
		/// List of permissions required by a microservice to work.
		/// </summary>
		[JsonPropertyName("requiredRoles")]
		public List<string>? RequiredRoles { get; set; }
	
		/// <summary>
		/// A flag to indicate if the application has a breadcrumbs navigation on the UI.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("breadcrumbs")]
		public bool? Breadcrumbs { get; set; }
	
		/// <summary>
		/// The content security policy of the application.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("contentSecurityPolicy")]
		public string? ContentSecurityPolicy { get; set; }
	
		/// <summary>
		/// A URL to a JSON object with dynamic content options.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("dynamicOptionsUrl")]
		public string? DynamicOptionsUrl { get; set; }
	
		/// <summary>
		/// The global title of the application.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("globalTitle")]
		public string? GlobalTitle { get; set; }
	
		/// <summary>
		/// A flag that shows if the application is a legacy application or not.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("legacy")]
		public bool? Legacy { get; set; }
	
		/// <summary>
		/// A flag to indicate if the application uses the UI context menu on the right side.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("rightDrawer")]
		public bool? RightDrawer { get; set; }
	
		/// <summary>
		/// A flag that shows if the application is hybrid and using Angular and AngularJS simultaneously.
		/// > **&#9432; Info:** This property is specific to the web application type.
		/// 
		/// </summary>
		[JsonPropertyName("upgrade")]
		public bool? Upgrade { get; set; }
	
		/// <summary>
		/// The active version ID of the application. For microservice applications the active version ID is the microservice manifest version ID.
		/// </summary>
		[JsonPropertyName("activeVersionId")]
		public string? ActiveVersionId { get; set; }
	
		/// <summary>
		/// URL to the application base directory hosted on an external server. Only present in legacy hosted applications.
		/// </summary>
		[System.ObsoleteAttribute("This property might be removed in future releases.", false)]
		[JsonPropertyName("resourcesUrl")]
		public string? ResourcesUrl { get; set; }
	
		/// <summary>
		/// Application access level for other tenants.
		/// [MARKET, PRIVATE]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Availability 
		{
			[EnumMember(Value = "MARKET")]
			MARKET,
			[EnumMember(Value = "PRIVATE")]
			PRIVATE
		}
	
		/// <summary>
		/// The type of the application.
		/// [EXTERNAL, HOSTED, MICROSERVICE]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
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
