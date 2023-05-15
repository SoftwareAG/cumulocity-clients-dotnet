//
// C8yAccelerationMeasurement.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Measurement of the acceleration sensor. <br />
/// </summary>
///
public sealed class C8yAccelerationMeasurement 
{

	/// <summary> 
	/// A measurement is a value with a unit. <br />
	/// </summary>
	///
	[JsonPropertyName("acceleration")]
	public C8yMeasurementValue? Acceleration { get; set; }

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
