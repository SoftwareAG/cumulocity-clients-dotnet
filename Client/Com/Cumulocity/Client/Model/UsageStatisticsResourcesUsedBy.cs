///
/// UsageStatisticsResourcesUsedBy.cs
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
	public class UsageStatisticsResourcesUsedBy 
	{
	
		/// <summary>
		/// Reason for calculating statistics of the specified microservice.
		/// </summary>
		[JsonPropertyName("cause")]
		public string? Cause { get; set; }
	
		/// <summary>
		/// Number of CPU usage for a single microservice.
		/// </summary>
		[JsonPropertyName("cpu")]
		public int? Cpu { get; set; }
	
		/// <summary>
		/// Number of memory usage for a single microservice.
		/// </summary>
		[JsonPropertyName("memory")]
		public int? Memory { get; set; }
	
		/// <summary>
		/// Name of the microservice.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
