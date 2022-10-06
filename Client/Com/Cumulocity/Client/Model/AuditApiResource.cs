///
/// AuditApiResource.cs
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
	public class AuditApiResource<TAuditRecord> where TAuditRecord : AuditRecord
	{
	
		/// <summary>
		/// Collection of audit records
		/// </summary>
		[JsonPropertyName("auditRecords")]
		public AuditRecords<TAuditRecord>? PAuditRecords { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for a specific application. The placeholder {application} must be the name of a registered application.
		/// </summary>
		[JsonPropertyName("auditRecordsForApplication")]
		public string? AuditRecordsForApplication { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for a specific type.
		/// </summary>
		[JsonPropertyName("auditRecordsForType")]
		public string? AuditRecordsForType { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for a specific user. The placeholder {user} must be a username of a registered user.
		/// </summary>
		[JsonPropertyName("auditRecordsForUser")]
		public string? AuditRecordsForUser { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for specific type and application.
		/// </summary>
		[JsonPropertyName("auditRecordsForTypeAndApplication")]
		public string? AuditRecordsForTypeAndApplication { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for specific type, user and application.
		/// </summary>
		[JsonPropertyName("auditRecordsForTypeAndUserAndApplication")]
		public string? AuditRecordsForTypeAndUserAndApplication { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for specific user and application.
		/// </summary>
		[JsonPropertyName("auditRecordsForUserAndApplication")]
		public string? AuditRecordsForUserAndApplication { get; set; }
	
		/// <summary>
		/// Read-only collection of audit records for specific user and type.
		/// </summary>
		[JsonPropertyName("auditRecordsForUserAndType")]
		public string? AuditRecordsForUserAndType { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of audit records
		/// </summary>
		public class AuditRecords<TAuditRecord> where TAuditRecord : AuditRecord
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			[JsonPropertyName("auditRecords")]
			public List<TAuditRecord>? PAuditRecords { get; set; }
		
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
