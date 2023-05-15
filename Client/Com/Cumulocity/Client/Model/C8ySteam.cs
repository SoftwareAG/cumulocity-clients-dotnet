//
// C8ySteam.cs
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
/// A type of measurement fragment. <br />
/// </summary>
///
public sealed class C8ySteam 
{

	[JsonPropertyName("Temperature")]
	public Temperature? PTemperature { get; set; }

	public sealed class Temperature 
	{
	
		/// <summary> 
		/// The unit of the measurement. <br />
		/// </summary>
		///
		[JsonPropertyName("unit")]
		public string? Unit { get; set; }
	
		/// <summary> 
		/// The value of the individual measurement. <br />
		/// </summary>
		///
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
