///
/// C8yVoltageMeasurement.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// A voltage sensor measures the voltage difference between two points in an electric circuit.
	/// </summary>
	public class C8yVoltageMeasurement 
	{
	
		/// <summary>
		/// A measurement is a value with a unit.
		/// </summary>
		[JsonPropertyName("voltage")]
		public C8yMeasurementValue? Voltage { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
