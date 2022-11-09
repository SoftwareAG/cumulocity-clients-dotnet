///
/// C8yMobile.cs
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
	/// <summary>
	/// Holds basic connectivity-related information, such as the equipment identifier of the modem (IMEI) in the device. This identifier is globally unique and often used to identify a mobile device.
	/// </summary>
	public class C8yMobile 
	{
	
		/// <summary>
		/// The equipment identifier (IMEI) of the modem in the device.
		/// </summary>
		[JsonPropertyName("imei")]
		public string? Imei { get; set; }
	
		/// <summary>
		/// The identifier of the cell in the mobile network that the device is currently connected with.
		/// </summary>
		[JsonPropertyName("cellId")]
		public string? CellId { get; set; }
	
		/// <summary>
		/// The identifier of the SIM card that is currently in the device (often printed on the card).
		/// </summary>
		[JsonPropertyName("iccid")]
		public string? Iccid { get; set; }
	
		/// <summary>
		/// Other possible values are: `c8y_Mobile.imsi`, `c8y_Mobile.currentOperator`, `c8y_Mobile.currentBand`, `c8y_Mobile.connType`, `c8y_Mobile.rssi`, `c8y_Mobile.ecn0`, `c8y_Mobile.rcsp`, `c8y_Mobile.mnc`, `c8y_Mobile.lac` and `c8y_Mobile.msisdn`.
		/// 
		/// </summary>
		[JsonPropertyName("customFragments")]
		public Dictionary<string, string> CustomFragments { get; set; } = new Dictionary<string, string>();
		
		public string this[string key]
		{
			get => CustomFragments[key];
			set => CustomFragments[key] = value;
		}
	
		public C8yMobile() 
		{
		}
	
		public C8yMobile(string imei, string cellId, string iccid)
		{
			this.Imei = imei;
			this.CellId = cellId;
			this.Iccid = iccid;
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
