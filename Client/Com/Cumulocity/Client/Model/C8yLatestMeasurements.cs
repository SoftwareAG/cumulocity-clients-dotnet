//
// C8yLatestMeasurements.cs
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
/// The read only fragment which contains the latest measurements reported by the device.The returned optionally only if the query parameter <c>withLatestValues=true</c> is used. <br />
/// ⚠️ Feature Preview: The feature is part of the Latest Measurement feature which is still under public feature preview. <br />
/// </summary>
///
public sealed class C8yLatestMeasurements 
{

	[JsonPropertyName("additionalProperties")]
	public IDictionary<string, LatestMeasurementFragment?> AdditionalProperties { get; set; } = new Dictionary<string, LatestMeasurementFragment?>();
	
	[JsonIgnore]
	public LatestMeasurementFragment? this[string key]
	{
		get => AdditionalProperties[key];
		set => AdditionalProperties[key] = value;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
