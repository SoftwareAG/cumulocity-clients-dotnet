///
/// DeviceControlApiResource.cs
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
	public class DeviceControlApiResource 
	{
	
		/// <summary> 
		/// Collection of all operations. <br />
		/// </summary>
		///
		[JsonPropertyName("operations")]
		public Operations? POperations { get; set; }
	
		/// <summary> 
		/// Read-only collection of all operations with a particular status. <br />
		/// </summary>
		///
		[JsonPropertyName("operationsByStatus")]
		public string? OperationsByStatus { get; set; }
	
		/// <summary> 
		/// Read-only collection of all operations targeting a particular agent. <br />
		/// </summary>
		///
		[JsonPropertyName("operationsByAgentId")]
		public string? OperationsByAgentId { get; set; }
	
		/// <summary> 
		/// Read-only collection of all operations targeting a particular agent and with a particular status. <br />
		/// </summary>
		///
		[JsonPropertyName("operationsByAgentIdAndStatus")]
		public string? OperationsByAgentIdAndStatus { get; set; }
	
		/// <summary> 
		/// Read-only collection of all operations to be executed on a particular device. <br />
		/// </summary>
		///
		[JsonPropertyName("operationsByDeviceId")]
		public string? OperationsByDeviceId { get; set; }
	
		/// <summary> 
		/// Read-only collection of all operations with a particular status, that should be executed on a particular device. <br />
		/// </summary>
		///
		[JsonPropertyName("operationsByDeviceIdAndStatus")]
		public string? OperationsByDeviceIdAndStatus { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Collection of all operations. <br />
		/// </summary>
		///
		public class Operations 
		{
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			/// <summary> 
			/// An array containing the registered operations. <br />
			/// </summary>
			///
			[JsonPropertyName("operations")]
			public List<OperationReference> POperations { get; set; } = new List<OperationReference>();
		
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
