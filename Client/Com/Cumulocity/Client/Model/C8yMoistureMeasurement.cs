///
/// C8yMoistureMeasurement.cs
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
	/// There are three main measurements of moisture; absolute, relative and specific.
	/// 
	/// Absolute moisture is the absolute water content of a substance. Relative moisture, expressed as a percentage, measures the current absolute moisture relative to the maximum for that temperature. Specific humidity is a ratio of the water vapour content of the mixture to the total substance content on a mass basis.
	/// 
	/// </summary>
	public class C8yMoistureMeasurement 
	{
	
		/// <summary>
		/// A measurement is a value with a unit.
		/// </summary>
		[JsonPropertyName("moisture")]
		public C8yMeasurementValue? Moisture { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
