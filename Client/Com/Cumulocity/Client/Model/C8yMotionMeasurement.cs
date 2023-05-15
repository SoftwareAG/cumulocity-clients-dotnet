//
// C8yMotionMeasurement.cs
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
/// Measurement of the motion sensor. <br />
/// </summary>
///
public sealed class C8yMotionMeasurement 
{

	/// <summary> 
	/// Boolean value indicating if motion has been detected (non-zero value) or not (zero value). <br />
	/// </summary>
	///
	[JsonPropertyName("motionDetected")]
	public MotionDetected? PMotionDetected { get; set; }

	/// <summary> 
	/// A measurement is a value with a unit. <br />
	/// </summary>
	///
	[JsonPropertyName("speed")]
	public C8yMeasurementValue? Speed { get; set; }

	/// <summary> 
	/// Boolean value indicating if motion has been detected (non-zero value) or not (zero value). <br />
	/// </summary>
	///
	public sealed class MotionDetected 
	{
	
		[JsonPropertyName("value")]
		public decimal? Value { get; set; }
	
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
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
