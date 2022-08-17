///
/// C8ySteam.cs
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
	/// A type of measurement fragment.
	/// </summary>
	public class C8ySteam 
	{
	
		[JsonPropertyName("Temperature")]
		public Temperature? PTemperature { get; set; }
	
		public class Temperature 
		{
		
			/// <summary>
			/// The unit of the measurement.
			/// </summary>
			[JsonPropertyName("unit")]
			public string? Unit { get; set; }
		
			/// <summary>
			/// The value of the individual measurement.
			/// </summary>
			[JsonPropertyName("value")]
			public decimal? Value { get; set; }
		
			public Temperature() 
			{
			}
		
			public Temperature(decimal value)
			{
				this.Value = value;
			}
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
