//
// LatestMeasurementValue.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The read only fragment which contains the latest measurements series values reported by the device. <br />
/// ⚠️ Feature Preview: The feature is part of the Latest Measurement feature which is still under public feature preview. <br />
/// </summary>
///
public sealed class LatestMeasurementValue 
{

	/// <summary> 
	/// The unit of the measurement series. <br />
	/// </summary>
	///
	[JsonPropertyName("unit")]
	public string? Unit { get; set; }

	/// <summary> 
	/// The time of the measurement series. <br />
	/// </summary>
	///
	[JsonPropertyName("time")]
	public System.DateTime? Time { get; set; }

	/// <summary> 
	/// The value of the individual measurement. <br />
	/// </summary>
	///
	[JsonPropertyName("value")]
	public decimal? Value { get; set; }

	public LatestMeasurementValue() 
	{
	}

	public LatestMeasurementValue(decimal value)
	{
		this.Value = value;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
