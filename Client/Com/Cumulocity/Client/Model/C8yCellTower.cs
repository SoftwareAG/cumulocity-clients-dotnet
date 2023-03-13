///
/// C8yCellTower.cs
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
	/// <summary> 
	/// Detailed information about a neighbouring cell tower. <br />
	/// </summary>
	///
	public class C8yCellTower 
	{
	
		/// <summary> 
		/// The radio type of this cell tower. Can also be put directly in root JSON element if all cellTowers have same radioType. <br />
		/// </summary>
		///
		[JsonPropertyName("radioType")]
		public string? RadioType { get; set; }
	
		/// <summary> 
		/// The Mobile Country Code (MCC). <br />
		/// </summary>
		///
		[JsonPropertyName("mobileCountryCode")]
		public decimal? MobileCountryCode { get; set; }
	
		/// <summary> 
		/// The Mobile Network Code (MNC) for GSM, WCDMA and LTE. The SystemID (sid) for CDMA. <br />
		/// </summary>
		///
		[JsonPropertyName("mobileNetworkCode")]
		public decimal? MobileNetworkCode { get; set; }
	
		/// <summary> 
		/// The Location Area Code (LAC) for GSM, WCDMA and LTE. The Network ID for CDMA. <br />
		/// </summary>
		///
		[JsonPropertyName("locationAreaCode")]
		public decimal? LocationAreaCode { get; set; }
	
		/// <summary> 
		/// The Cell ID (CID) for GSM, WCDMA and LTE. The base station ID for CDMA. <br />
		/// </summary>
		///
		[JsonPropertyName("cellId")]
		public decimal? CellId { get; set; }
	
		/// <summary> 
		/// The timing advance value for this cell tower when available. <br />
		/// </summary>
		///
		[JsonPropertyName("timingAdvance")]
		public decimal? TimingAdvance { get; set; }
	
		/// <summary> 
		/// The signal strength for this cell tower in dBm. <br />
		/// </summary>
		///
		[JsonPropertyName("signalStrength")]
		public decimal? SignalStrength { get; set; }
	
		/// <summary> 
		/// The primary scrambling code for WCDMA and physical CellId for LTE. <br />
		/// </summary>
		///
		[JsonPropertyName("primaryScramblingCode")]
		public decimal? PrimaryScramblingCode { get; set; }
	
		/// <summary> 
		/// Specify with 0/1 if the cell is serving or not. If not specified, the first cell is assumed to be serving. <br />
		/// </summary>
		///
		[JsonPropertyName("serving")]
		public decimal? Serving { get; set; }
	
		public C8yCellTower() 
		{
		}
	
		public C8yCellTower(decimal mobileCountryCode, decimal mobileNetworkCode, decimal locationAreaCode, decimal cellId)
		{
			this.MobileCountryCode = mobileCountryCode;
			this.MobileNetworkCode = mobileNetworkCode;
			this.LocationAreaCode = locationAreaCode;
			this.CellId = cellId;
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
