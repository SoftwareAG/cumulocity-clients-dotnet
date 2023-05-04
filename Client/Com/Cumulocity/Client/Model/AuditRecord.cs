///
/// AuditRecord.cs
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
	[JsonConverter(typeof(AuditRecordJsonConverter<AuditRecord>))]
	public class AuditRecord 
	{
	
		/// <summary> 
		/// Summary of the action that was carried out. <br />
		/// </summary>
		///
		[JsonPropertyName("activity")]
		public string? Activity { get; set; }
	
		/// <summary> 
		/// Name of the application that performed the action. <br />
		/// </summary>
		///
		[JsonPropertyName("application")]
		public string? Application { get; set; }
	
		/// <summary> 
		/// Metadata of the audit record. <br />
		/// </summary>
		///
		[JsonPropertyName("c8y_Metadata")]
		public C8yMetadata? PC8yMetadata { get; set; }
	
		/// <summary> 
		/// Collection of objects describing the changes that were carried out. <br />
		/// </summary>
		///
		[JsonPropertyName("changes")]
		public List<Changes> PChanges { get; set; } = new List<Changes>();
	
		/// <summary> 
		/// The date and time when the audit record was created. <br />
		/// </summary>
		///
		[JsonPropertyName("creationTime")]
		public System.DateTime? CreationTime { get; set; }
	
		/// <summary> 
		/// Unique identifier of the audit record. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// The severity of the audit action. <br />
		/// </summary>
		///
		[JsonPropertyName("severity")]
		public Severity? PSeverity { get; set; }
	
		/// <summary> 
		/// The managed object to which the audit is associated. <br />
		/// </summary>
		///
		[JsonPropertyName("source")]
		public Source? PSource { get; set; }
	
		/// <summary> 
		/// Details of the action that was carried out. <br />
		/// </summary>
		///
		[JsonPropertyName("text")]
		public string? Text { get; set; }
	
		/// <summary> 
		/// The date and time when the audit is updated. <br />
		/// </summary>
		///
		[JsonPropertyName("time")]
		public System.DateTime? Time { get; set; }
	
		/// <summary> 
		/// Identifies the platform component of the audit. <br />
		/// </summary>
		///
		[JsonPropertyName("type")]
		public Type? PType { get; set; }
	
		/// <summary> 
		/// The user who carried out the activity. <br />
		/// </summary>
		///
		[JsonPropertyName("user")]
		public string? User { get; set; }
	
		/// <summary> 
		/// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, <c>"property1": {}</c>, <c>"property2": "value"</c>. These properties can be of any type, for example, object or string. <br />
		/// </summary>
		///
		[JsonPropertyName("customProperties")]
		public Dictionary<string, object> CustomProperties { get; set; } = new Dictionary<string, object>();
		
		[JsonIgnore]
		public object this[string key]
		{
			get => CustomProperties[key];
			set => CustomProperties[key] = value;
		}
	
		public AuditRecord() 
		{
		}
	
		public AuditRecord(string activity, Source source, string text, System.DateTime time, Type type)
		{
			this.Activity = activity;
			this.PSource = source;
			this.Text = text;
			this.Time = time;
			this.PType = type;
		}
	
		/// <summary> 
		/// The severity of the audit action. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Severity 
		{
			[EnumMember(Value = "CRITICAL")]
			CRITICAL,
			[EnumMember(Value = "MAJOR")]
			MAJOR,
			[EnumMember(Value = "MINOR")]
			MINOR,
			[EnumMember(Value = "WARNING")]
			WARNING,
			[EnumMember(Value = "INFORMATION")]
			INFORMATION
		}
	
		/// <summary> 
		/// Identifies the platform component of the audit. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Type 
		{
			[EnumMember(Value = "Alarm")]
			ALARM,
			[EnumMember(Value = "Application")]
			APPLICATION,
			[EnumMember(Value = "BulkOperation")]
			BULKOPERATION,
			[EnumMember(Value = "CepModule")]
			CEPMODULE,
			[EnumMember(Value = "Connector")]
			CONNECTOR,
			[EnumMember(Value = "Event")]
			EVENT,
			[EnumMember(Value = "Group")]
			GROUP,
			[EnumMember(Value = "Inventory")]
			INVENTORY,
			[EnumMember(Value = "InventoryRole")]
			INVENTORYROLE,
			[EnumMember(Value = "Operation")]
			OPERATION,
			[EnumMember(Value = "Option")]
			OPTION,
			[EnumMember(Value = "Report")]
			REPORT,
			[EnumMember(Value = "SingleSignOn")]
			SINGLESIGNON,
			[EnumMember(Value = "SmartRule")]
			SMARTRULE,
			[EnumMember(Value = "SYSTEM")]
			SYSTEM,
			[EnumMember(Value = "Tenant")]
			TENANT,
			[EnumMember(Value = "TenantAuthConfig")]
			TENANTAUTHCONFIG,
			[EnumMember(Value = "TrustedCertificates")]
			TRUSTEDCERTIFICATES,
			[EnumMember(Value = "User")]
			USER,
			[EnumMember(Value = "UserAuthentication")]
			USERAUTHENTICATION
		}
	
		/// <summary> 
		/// Metadata of the audit record. <br />
		/// </summary>
		///
		public class C8yMetadata 
		{
		
			/// <summary> 
			/// The action that was carried out. <br />
			/// </summary>
			///
			[JsonPropertyName("action")]
			public Action? PAction { get; set; }
		
			/// <summary> 
			/// The action that was carried out. <br />
			/// </summary>
			///
			[JsonConverter(typeof(EnumConverterFactory))]
			public enum Action 
			{
				[EnumMember(Value = "SUBSCRIBE")]
				SUBSCRIBE,
				[EnumMember(Value = "DEPLOY")]
				DEPLOY,
				[EnumMember(Value = "SCALE")]
				SCALE,
				[EnumMember(Value = "DELETE")]
				DELETE
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
	
		public class Changes 
		{
		
			/// <summary> 
			/// The attribute that was changed. <br />
			/// </summary>
			///
			[JsonPropertyName("attribute")]
			public string? Attribute { get; set; }
		
			/// <summary> 
			/// The type of change that was carried out. <br />
			/// </summary>
			///
			[JsonPropertyName("changeType")]
			public ChangeType? PChangeType { get; set; }
		
			/// <summary> 
			/// The new value of the object. <br />
			/// </summary>
			///
			[JsonPropertyName("newValue")]
			public object? NewValue { get; set; }
		
			/// <summary> 
			/// The previous value of the object. <br />
			/// </summary>
			///
			[JsonPropertyName("previousValue")]
			public object? PreviousValue { get; set; }
		
			/// <summary> 
			/// The type of the object. <br />
			/// </summary>
			///
			[JsonPropertyName("type")]
			public string? Type { get; set; }
		
			/// <summary> 
			/// The type of change that was carried out. <br />
			/// </summary>
			///
			[JsonConverter(typeof(EnumConverterFactory))]
			public enum ChangeType 
			{
				[EnumMember(Value = "ADDED")]
				ADDED,
				[EnumMember(Value = "REPLACED")]
				REPLACED
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
	
	
		/// <summary> 
		/// The managed object to which the audit is associated. <br />
		/// </summary>
		///
		public class Source 
		{
		
			/// <summary> 
			/// Unique identifier of the object. <br />
			/// </summary>
			///
			[JsonPropertyName("id")]
			public string? Id { get; set; }
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			public Source() 
			{
			}
		
			public Source(string id)
			{
				this.Id = id;
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
	
	
		public override string ToString()
		{
			var jsonOptions = new JsonSerializerOptions() 
			{ 
				WriteIndented = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			};
			return JsonSerializer.Serialize(this, jsonOptions);
		}
	
		public class Serialization
		{
			public static readonly IDictionary<string, System.Type> AdditionalPropertyClasses = new Dictionary<string, System.Type>();
		
			public static void RegisterAdditionalProperty(string typeName, System.Type type)
			{
				AdditionalPropertyClasses[typeName] = type;
			}
		}
	}
}
