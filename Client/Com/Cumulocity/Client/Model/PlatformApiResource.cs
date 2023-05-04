///
/// PlatformApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class PlatformApiResource<TCustomProperties, TAlarm, TAuditRecord, TMeasurement, TManagedObject, TEvent> where TCustomProperties : CustomProperties where TAlarm : Alarm where TManagedObject : ManagedObject where TAuditRecord : AuditRecord where TEvent : Event where TMeasurement : Measurement
	{
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		[JsonPropertyName("alarm")]
		public AlarmsApiResource<TAlarm>? Alarm { get; set; }
	
		[JsonPropertyName("audit")]
		public AuditApiResource<TAuditRecord>? Audit { get; set; }
	
		[JsonPropertyName("deviceControl")]
		public DeviceControlApiResource? DeviceControl { get; set; }
	
		[JsonPropertyName("event")]
		public EventsApiResource<TEvent>? Event { get; set; }
	
		[JsonPropertyName("identity")]
		public IdentityApiResource? Identity { get; set; }
	
		[JsonPropertyName("inventory")]
		public InventoryApiResource<TManagedObject>? Inventory { get; set; }
	
		[JsonPropertyName("measurement")]
		public MeasurementApiResource<TMeasurement>? Measurement { get; set; }
	
		[JsonPropertyName("tenant")]
		public TenantApiResource<TCustomProperties>? Tenant { get; set; }
	
		[JsonPropertyName("user")]
		public UserApiResource? User { get; set; }
	
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
