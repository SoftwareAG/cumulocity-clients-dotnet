///
/// C8yPosition.cs
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
	/// <summary>
	/// Reports the geographical location of an asset in terms of latitude, longitude and altitude.
	/// 
	/// Altitude is given in meters. To report the current location of an asset or a device, `c8y_Position` is added to the managed object representing the asset or device. To trace the position of an asset or a device, `c8y_Position` is sent as part of an event of type `c8y_LocationUpdate`.
	/// 
	/// </summary>
	public class C8yPosition 
	{
	
		/// <summary>
		/// In meters.
		/// </summary>
		[JsonPropertyName("alt")]
		public decimal? Alt { get; set; }
	
		[JsonPropertyName("lng")]
		public decimal? Lng { get; set; }
	
		[JsonPropertyName("lat")]
		public decimal? Lat { get; set; }
	
		/// <summary>
		/// Describes in which protocol the tracking context of a positioning report was sent.
		/// </summary>
		[JsonPropertyName("trackingProtocol")]
		public string? TrackingProtocol { get; set; }
	
		/// <summary>
		/// Describes why the tracking context of a positioning report was sent.
		/// </summary>
		[JsonPropertyName("reportReason")]
		public string? ReportReason { get; set; }
	
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
