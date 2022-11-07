///
/// BulkOperation.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class BulkOperation 
	{
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Unique identifier of this bulk operation.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// Identifies the target group on which this operation should be performed.
		/// </summary>
		[JsonPropertyName("groupId")]
		public string? GroupId { get; set; }
	
		/// <summary>
		/// Identifies the failed bulk operation from which the failed operations should be rescheduled.
		/// </summary>
		[JsonPropertyName("failedParentId")]
		public string? FailedParentId { get; set; }
	
		/// <summary>
		/// Date and time when the operations of this bulk operation should be created.
		/// </summary>
		[JsonPropertyName("startDate")]
		public System.DateTime? StartDate { get; set; }
	
		/// <summary>
		/// Delay between every operation creation in seconds.
		/// </summary>
		[JsonPropertyName("creationRamp")]
		public float? CreationRamp { get; set; }
	
		/// <summary>
		/// Operation to be executed for every device in a group.
		/// </summary>
		[JsonPropertyName("operationPrototype")]
		public OperationPrototype? POperationPrototype { get; set; }
	
		/// <summary>
		/// The status of this bulk operation, in context of the execution of all its single operations.
		/// </summary>
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		/// <summary>
		/// The general status of this bulk operation. The general status is visible for end users and they can filter and evaluate bulk operations by this status.
		/// </summary>
		[JsonPropertyName("generalStatus")]
		public GeneralStatus? PGeneralStatus { get; set; }
	
		/// <summary>
		/// Contains information about the number of processed operations.
		/// </summary>
		[JsonPropertyName("progress")]
		public Progress? PProgress { get; set; }
	
		/// <summary>
		/// The status of this bulk operation, in context of the execution of all its single operations.
		/// [ACTIVE, IN_PROGRESS, COMPLETED, DELETED]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Status 
		{
			[EnumMember(Value = "ACTIVE")]
			ACTIVE,
			[EnumMember(Value = "IN_PROGRESS")]
			INPROGRESS,
			[EnumMember(Value = "COMPLETED")]
			COMPLETED,
			[EnumMember(Value = "DELETED")]
			DELETED
		}
	
		/// <summary>
		/// The general status of this bulk operation. The general status is visible for end users and they can filter and evaluate bulk operations by this status.
		/// [SCHEDULED, EXECUTING, EXECUTING_WITH_ERRORS, SUCCESSFUL, FAILED, CANCELED]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum GeneralStatus 
		{
			[EnumMember(Value = "SCHEDULED")]
			SCHEDULED,
			[EnumMember(Value = "EXECUTING")]
			EXECUTING,
			[EnumMember(Value = "EXECUTING_WITH_ERRORS")]
			EXECUTINGWITHERRORS,
			[EnumMember(Value = "SUCCESSFUL")]
			SUCCESSFUL,
			[EnumMember(Value = "FAILED")]
			FAILED,
			[EnumMember(Value = "CANCELED")]
			CANCELED
		}
	
		/// <summary>
		/// Operation to be executed for every device in a group.
		/// </summary>
		public class OperationPrototype 
		{
		
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
		/// Contains information about the number of processed operations.
		/// </summary>
		public class Progress 
		{
		
			/// <summary>
			/// Number of pending operations.
			/// </summary>
			[JsonPropertyName("pending")]
			public int? Pending { get; set; }
		
			/// <summary>
			/// Number of failed operations.
			/// </summary>
			[JsonPropertyName("failed")]
			public int? Failed { get; set; }
		
			/// <summary>
			/// Number of operations being executed.
			/// </summary>
			[JsonPropertyName("executing")]
			public int? Executing { get; set; }
		
			/// <summary>
			/// Number of operations successfully processed.
			/// </summary>
			[JsonPropertyName("successful")]
			public int? Successful { get; set; }
		
			/// <summary>
			/// Total number of processed operations.
			/// </summary>
			[JsonPropertyName("all")]
			public int? All { get; set; }
		
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
