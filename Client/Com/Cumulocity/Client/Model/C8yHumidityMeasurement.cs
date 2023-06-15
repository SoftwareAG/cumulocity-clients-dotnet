//
// C8yHumidityMeasurement.cs
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
/// There are three main measurements of humidity; absolute, relative and specific. <br />
/// Absolute humidity is the water content of air. Relative humidity, expressed as a percentage, measures the current absolute humidity relative to the maximum for that temperature. Specific humidity is a ratio of the water vapour content of the mixture to the total air content on a mass basis. <br />
/// </summary>
///
public sealed class C8yHumidityMeasurement 
{

	/// <summary> 
	/// A measurement is a value with a unit. <br />
	/// </summary>
	///
	[JsonPropertyName("h")]
	public C8yMeasurementValue? H { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
