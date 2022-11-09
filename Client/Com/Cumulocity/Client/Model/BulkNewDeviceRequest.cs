///
/// BulkNewDeviceRequest.cs
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
	public class BulkNewDeviceRequest 
	{
	
		/// <summary>
		/// Number of lines processed from the CSV file, without the first line (column headers).
		/// </summary>
		[JsonPropertyName("numberOfAll")]
		public int? NumberOfAll { get; set; }
	
		/// <summary>
		/// Number of created device credentials.
		/// </summary>
		[JsonPropertyName("numberOfCreated")]
		public int? NumberOfCreated { get; set; }
	
		/// <summary>
		/// Number of failed creations of device credentials.
		/// </summary>
		[JsonPropertyName("numberOfFailed")]
		public int? NumberOfFailed { get; set; }
	
		/// <summary>
		/// Number of successful creations of device credentials. This counts both create and update operations.
		/// </summary>
		[JsonPropertyName("numberOfSuccessful")]
		public int? NumberOfSuccessful { get; set; }
	
		/// <summary>
		/// An array with the updated device credentials.
		/// </summary>
		[JsonPropertyName("credentialUpdatedList")]
		public List<CredentialUpdatedList>? PCredentialUpdatedList { get; set; }
	
		/// <summary>
		/// An array with details of the failed device credentials.
		/// </summary>
		[JsonPropertyName("failedCreationList")]
		public List<FailedCreationList>? PFailedCreationList { get; set; }
	
		public class CredentialUpdatedList 
		{
		
			/// <summary>
			/// The device credentials creation status.
			/// </summary>
			[JsonPropertyName("bulkNewDeviceStatus")]
			public NewDeviceStatus? BulkNewDeviceStatus { get; set; }
		
			/// <summary>
			/// Unique identifier of the device.
			/// </summary>
			[JsonPropertyName("deviceId")]
			public string? DeviceId { get; set; }
		
			/// <summary>
			/// The device credentials creation status.
			/// [CREATED, FAILED, CREDENTIAL_UPDATED]
			/// </summary>
			[JsonConverter(typeof(JsonStringEnumConverter))]
			public enum NewDeviceStatus 
			{
				[EnumMember(Value = "CREATED")]
				CREATED,
				[EnumMember(Value = "FAILED")]
				FAILED,
				[EnumMember(Value = "CREDENTIAL_UPDATED")]
				CREDENTIALUPDATED
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
	
		public class FailedCreationList 
		{
		
			/// <summary>
			/// The device credentials creation status.
			/// </summary>
			[JsonPropertyName("bulkNewDeviceStatus")]
			public NewDeviceStatus? BulkNewDeviceStatus { get; set; }
		
			/// <summary>
			/// Unique identifier of the device.
			/// </summary>
			[JsonPropertyName("deviceId")]
			public string? DeviceId { get; set; }
		
			/// <summary>
			/// Reason for the failure.
			/// </summary>
			[JsonPropertyName("failureReason")]
			public string? FailureReason { get; set; }
		
			/// <summary>
			/// Line where the failure occurred.
			/// </summary>
			[JsonPropertyName("line")]
			public string? Line { get; set; }
		
			/// <summary>
			/// The device credentials creation status.
			/// [CREATED, FAILED, CREDENTIAL_UPDATED]
			/// </summary>
			[JsonConverter(typeof(JsonStringEnumConverter))]
			public enum NewDeviceStatus 
			{
				[EnumMember(Value = "CREATED")]
				CREATED,
				[EnumMember(Value = "FAILED")]
				FAILED,
				[EnumMember(Value = "CREDENTIAL_UPDATED")]
				CREDENTIALUPDATED
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
	}
}
