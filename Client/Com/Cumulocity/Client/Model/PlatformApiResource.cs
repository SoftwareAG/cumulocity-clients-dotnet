///
/// PlatformApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class PlatformApiResource 
	{
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		[JsonPropertyName("alarm")]
		public AlarmsApiResource? Alarm { get; set; }
	
		[JsonPropertyName("audit")]
		public AuditApiResource? Audit { get; set; }
	
		[JsonPropertyName("deviceControl")]
		public DeviceControlApiResource? DeviceControl { get; set; }
	
		[JsonPropertyName("event")]
		public EventsApiResource? Event { get; set; }
	
		[JsonPropertyName("identity")]
		public IdentityApiResource? Identity { get; set; }
	
		[JsonPropertyName("inventory")]
		public InventoryApiResource? Inventory { get; set; }
	
		[JsonPropertyName("measurement")]
		public MeasurementApiResource? Measurement { get; set; }
	
		[JsonPropertyName("tenant")]
		public TenantApiResource? Tenant { get; set; }
	
		[JsonPropertyName("user")]
		public UserApiResource? User { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
