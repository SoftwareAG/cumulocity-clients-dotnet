///
/// MicroserviceApplicationManifest.cs
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
	/// <summary> 
	/// The manifest of the microservice application. <br />
	/// </summary>
	///
	public class MicroserviceApplicationManifest 
	{
	
		/// <summary> 
		/// Document type format discriminator, for future changes in format. <br />
		/// </summary>
		///
		[JsonPropertyName("apiVersion")]
		public string? ApiVersion { get; set; }
	
		/// <summary> 
		/// The billing mode of the application. <br />
		/// In case of RESOURCES, the number of resources used is exposed for billing calculation per usage.In case of SUBSCRIPTION, all resources usage is counted for the microservice owner and the subtenant is charged for subscription. <br />
		/// </summary>
		///
		[JsonPropertyName("billingMode")]
		public BillingMode? PBillingMode { get; set; }
	
		/// <summary> 
		/// The context path in the URL makes the application accessible. <br />
		/// </summary>
		///
		[JsonPropertyName("contextPath")]
		public string? ContextPath { get; set; }
	
		/// <summary> 
		/// A list of URL extensions for this microservice application. <br />
		/// </summary>
		///
		[JsonPropertyName("extensions")]
		public List<Extensions> PExtensions { get; set; } = new List<Extensions>();
	
		/// <summary> 
		/// Deployment isolation.In case of PER_TENANT, there is a separate instance for each tenant.Otherwise, there is one single instance for all subscribed tenants.This will affect billing. <br />
		/// </summary>
		///
		[JsonPropertyName("isolation")]
		public Isolation? PIsolation { get; set; }
	
		[JsonPropertyName("livenessProbe")]
		public ApplicationManifestProbe? LivenessProbe { get; set; }
	
		/// <summary> 
		/// Application provider information.Simple name allowed for predefined providers, for example, c8y.Detailed object for external provider. <br />
		/// </summary>
		///
		[JsonPropertyName("provider")]
		public Provider? PProvider { get; set; }
	
		[JsonPropertyName("readinessProbe")]
		public ApplicationManifestProbe? ReadinessProbe { get; set; }
	
		/// <summary> 
		/// The minimum required resources for the microservice application. <br />
		/// </summary>
		///
		[JsonPropertyName("requestResources")]
		public RequestResources? PRequestResources { get; set; }
	
		/// <summary> 
		/// The recommended resources for this microservice application. <br />
		/// </summary>
		///
		[JsonPropertyName("resources")]
		public Resources? PResources { get; set; }
	
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
		/// Allows to configure a microservice auto scaling policy.If the microservice uses a lot of CPU resources, a second instance will be created automatically when this is set to <c>AUTO</c>.The default is <c>NONE</c>, meaning auto scaling will not happen. <br />
		/// </summary>
		///
		[JsonPropertyName("scale")]
		public Scale? PScale { get; set; }
	
		/// <summary> 
		/// A list of settings objects for this microservice application. <br />
		/// </summary>
		///
		[JsonPropertyName("settings")]
		public List<ApplicationSettings> Settings { get; set; } = new List<ApplicationSettings>();
	
		/// <summary> 
		/// Allows to specify a custom category for microservice settings.By default, <c>contextPath</c> is used. <br />
		/// </summary>
		///
		[JsonPropertyName("settingsCategory")]
		public string? SettingsCategory { get; set; }
	
		/// <summary> 
		/// Application version.Must be a correct <see href="https://semver.org/" langword="SemVer" /> value but the "+" sign is disallowed. <br />
		/// </summary>
		///
		[JsonPropertyName("version")]
		public string? Version { get; set; }
	
		/// <summary> 
		/// The billing mode of the application. <br />
		/// In case of RESOURCES, the number of resources used is exposed for billing calculation per usage.In case of SUBSCRIPTION, all resources usage is counted for the microservice owner and the subtenant is charged for subscription. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum BillingMode 
		{
			[EnumMember(Value = "RESOURCES")]
			RESOURCES,
			[EnumMember(Value = "SUBSCRIPTION")]
			SUBSCRIPTION
		}
	
		/// <summary> 
		/// Deployment isolation.In case of PER_TENANT, there is a separate instance for each tenant.Otherwise, there is one single instance for all subscribed tenants.This will affect billing. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Isolation 
		{
			[EnumMember(Value = "MULTI_TENANT")]
			MULTITENANT,
			[EnumMember(Value = "PER_TENANT")]
			PERTENANT
		}
	
		/// <summary> 
		/// Allows to configure a microservice auto scaling policy.If the microservice uses a lot of CPU resources, a second instance will be created automatically when this is set to <c>AUTO</c>.The default is <c>NONE</c>, meaning auto scaling will not happen. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Scale 
		{
			[EnumMember(Value = "NONE")]
			NONE,
			[EnumMember(Value = "AUTO")]
			AUTO
		}
	
	
		public class Extensions 
		{
		
			/// <summary> 
			/// The relative path in Cumulocity IoT for this microservice application. <br />
			/// </summary>
			///
			[JsonPropertyName("path")]
			public string? Path { get; set; }
		
			/// <summary> 
			/// The type of this extension. <br />
			/// </summary>
			///
			[JsonPropertyName("type")]
			public string? Type { get; set; }
		
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
		/// Application provider information.Simple name allowed for predefined providers, for example, c8y.Detailed object for external provider. <br />
		/// </summary>
		///
		public class Provider 
		{
		
			/// <summary> 
			/// The name of the application provider. <br />
			/// </summary>
			///
			[JsonPropertyName("name")]
			public string? Name { get; set; }
		
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
		/// The minimum required resources for the microservice application. <br />
		/// </summary>
		///
		public class RequestResources 
		{
		
			/// <summary> 
			/// The required CPU resource for this microservice application. <br />
			/// </summary>
			///
			[JsonPropertyName("cpu")]
			public string? Cpu { get; set; }
		
			/// <summary> 
			/// The required memory resource for this microservice application. <br />
			/// </summary>
			///
			[JsonPropertyName("memory")]
			public string? Memory { get; set; }
		
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
		/// The recommended resources for this microservice application. <br />
		/// </summary>
		///
		public class Resources 
		{
		
			/// <summary> 
			/// The required CPU resource for this microservice application. <br />
			/// </summary>
			///
			[JsonPropertyName("cpu")]
			public string? Cpu { get; set; }
		
			/// <summary> 
			/// The required memory resource for this microservice application. <br />
			/// </summary>
			///
			[JsonPropertyName("memory")]
			public string? Memory { get; set; }
		
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
