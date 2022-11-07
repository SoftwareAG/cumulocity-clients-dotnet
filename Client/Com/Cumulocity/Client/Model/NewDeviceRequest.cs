///
/// NewDeviceRequest.cs
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
	public class NewDeviceRequest 
	{
	
		/// <summary>
		/// External ID of the device.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Status of this new device request.
		/// </summary>
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		/// <summary>
		/// Status of this new device request.
		/// [WAITING_FOR_CONNECTION, PENDING_ACCEPTANCE, ACCEPTED]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Status 
		{
			[EnumMember(Value = "WAITING_FOR_CONNECTION")]
			WAITINGFORCONNECTION,
			[EnumMember(Value = "PENDING_ACCEPTANCE")]
			PENDINGACCEPTANCE,
			[EnumMember(Value = "ACCEPTED")]
			ACCEPTED
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
