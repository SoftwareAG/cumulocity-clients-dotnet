///
/// BulkNewDeviceRequest.cs
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
	public class BulkNewDeviceRequest 
	{
	
		/// <summary> 
		/// Number of lines processed from the CSV file, without the first line (column headers). <br />
		/// </summary>
		///
		[JsonPropertyName("numberOfAll")]
		public int? NumberOfAll { get; set; }
	
		/// <summary> 
		/// Number of created device credentials. <br />
		/// </summary>
		///
		[JsonPropertyName("numberOfCreated")]
		public int? NumberOfCreated { get; set; }
	
		/// <summary> 
		/// Number of failed creations of device credentials. <br />
		/// </summary>
		///
		[JsonPropertyName("numberOfFailed")]
		public int? NumberOfFailed { get; set; }
	
		/// <summary> 
		/// Number of successful creations of device credentials. This counts both create and update operations. <br />
		/// </summary>
		///
		[JsonPropertyName("numberOfSuccessful")]
		public int? NumberOfSuccessful { get; set; }
	
		/// <summary> 
		/// An array with the updated device credentials. <br />
		/// </summary>
		///
		[JsonPropertyName("credentialUpdatedList")]
		public List<CredentialUpdatedList> PCredentialUpdatedList { get; set; } = new List<CredentialUpdatedList>();
	
		/// <summary> 
		/// An array with details of the failed device credentials. <br />
		/// </summary>
		///
		[JsonPropertyName("failedCreationList")]
		public List<FailedCreationList> PFailedCreationList { get; set; } = new List<FailedCreationList>();
	
		public class CredentialUpdatedList 
		{
		
			/// <summary> 
			/// The device credentials creation status. <br />
			/// </summary>
			///
			[JsonPropertyName("bulkNewDeviceStatus")]
			public NewDeviceStatus? BulkNewDeviceStatus { get; set; }
		
			/// <summary> 
			/// Unique identifier of the device. <br />
			/// </summary>
			///
			[JsonPropertyName("deviceId")]
			public string? DeviceId { get; set; }
		
			/// <summary> 
			/// The device credentials creation status. <br />
			/// </summary>
			///
			[JsonConverter(typeof(EnumConverterFactory))]
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
			/// The device credentials creation status. <br />
			/// </summary>
			///
			[JsonPropertyName("bulkNewDeviceStatus")]
			public NewDeviceStatus? BulkNewDeviceStatus { get; set; }
		
			/// <summary> 
			/// Unique identifier of the device. <br />
			/// </summary>
			///
			[JsonPropertyName("deviceId")]
			public string? DeviceId { get; set; }
		
			/// <summary> 
			/// Reason for the failure. <br />
			/// </summary>
			///
			[JsonPropertyName("failureReason")]
			public string? FailureReason { get; set; }
		
			/// <summary> 
			/// Line where the failure occurred. <br />
			/// </summary>
			///
			[JsonPropertyName("line")]
			public string? Line { get; set; }
		
			/// <summary> 
			/// The device credentials creation status. <br />
			/// </summary>
			///
			[JsonConverter(typeof(EnumConverterFactory))]
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
