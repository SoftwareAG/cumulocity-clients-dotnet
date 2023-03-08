///
/// RangeStatisticsFile.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class RangeStatisticsFile 
	{
	
		/// <summary> 
		/// Statistics generation start date. <br />
		/// </summary>
		///
		[JsonPropertyName("dateFrom")]
		public System.DateTime? DateFrom { get; set; }
	
		/// <summary> 
		/// Statistics generation end date. <br />
		/// </summary>
		///
		[JsonPropertyName("dateTo")]
		public System.DateTime? DateTo { get; set; }
	
		public RangeStatisticsFile() 
		{
		}
	
		public RangeStatisticsFile(System.DateTime dateFrom, System.DateTime dateTo)
		{
			this.DateFrom = dateFrom;
			this.DateTo = dateTo;
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
}
