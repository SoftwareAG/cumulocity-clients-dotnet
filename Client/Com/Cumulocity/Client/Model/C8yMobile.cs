//
// C8yMobile.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Holds basic connectivity-related information, such as the equipment identifier of the modem (IMEI) in the device. This identifier is globally unique and often used to identify a mobile device. <br />
/// </summary>
///
public sealed class C8yMobile 
{

	/// <summary> 
	/// The equipment identifier (IMEI) of the modem in the device. <br />
	/// </summary>
	///
	[JsonPropertyName("imei")]
	public string? Imei { get; set; }

	/// <summary> 
	/// The identifier of the cell in the mobile network that the device is currently connected with. <br />
	/// </summary>
	///
	[JsonPropertyName("cellId")]
	public string? CellId { get; set; }

	/// <summary> 
	/// The identifier of the SIM card that is currently in the device (often printed on the card). <br />
	/// </summary>
	///
	[JsonPropertyName("iccid")]
	public string? Iccid { get; set; }

	/// <summary> 
	/// Other possible values are: <c>c8y_Mobile.imsi</c>, <c>c8y_Mobile.currentOperator</c>, <c>c8y_Mobile.currentBand</c>, <c>c8y_Mobile.connType</c>, <c>c8y_Mobile.rssi</c>, <c>c8y_Mobile.ecn0</c>, <c>c8y_Mobile.rcsp</c>, <c>c8y_Mobile.mnc</c>, <c>c8y_Mobile.lac</c> and <c>c8y_Mobile.msisdn</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("customFragments")]
	public IDictionary<string, string?> CustomFragments { get; set; } = new Dictionary<string, string?>();
	
	[JsonIgnore]
	public string? this[string key]
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
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
