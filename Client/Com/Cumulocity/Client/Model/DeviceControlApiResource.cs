///
/// DeviceControlApiResource.cs
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
	public class DeviceControlApiResource 
	{
	
		/// <summary>
		/// Collection of all operations.
		/// </summary>
		[JsonPropertyName("operations")]
		public Operations? POperations { get; set; }
	
		/// <summary>
		/// Read-only collection of all operations with a particular status.
		/// </summary>
		[JsonPropertyName("operationsByStatus")]
		public string? OperationsByStatus { get; set; }
	
		/// <summary>
		/// Read-only collection of all operations targeting a particular agent.
		/// </summary>
		[JsonPropertyName("operationsByAgentId")]
		public string? OperationsByAgentId { get; set; }
	
		/// <summary>
		/// Read-only collection of all operations targeting a particular agent and with a particular status.
		/// </summary>
		[JsonPropertyName("operationsByAgentIdAndStatus")]
		public string? OperationsByAgentIdAndStatus { get; set; }
	
		/// <summary>
		/// Read-only collection of all operations to be executed on a particular device.
		/// </summary>
		[JsonPropertyName("operationsByDeviceId")]
		public string? OperationsByDeviceId { get; set; }
	
		/// <summary>
		/// Read-only collection of all operations with a particular status, that should be executed on a particular device.
		/// </summary>
		[JsonPropertyName("operationsByDeviceIdAndStatus")]
		public string? OperationsByDeviceIdAndStatus { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of all operations.
		/// </summary>
		public class Operations 
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			/// <summary>
			/// An array containing the registered operations.
			/// </summary>
			[JsonPropertyName("operations")]
			public List<OperationReference>? POperations { get; set; }
		
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
