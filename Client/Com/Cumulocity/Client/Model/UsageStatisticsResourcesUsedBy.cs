//
// UsageStatisticsResourcesUsedBy.cs
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

public sealed class UsageStatisticsResourcesUsedBy 
{

	/// <summary> 
	/// Reason for calculating statistics of the specified microservice. <br />
	/// </summary>
	///
	[JsonPropertyName("cause")]
	public string? Cause { get; set; }

	/// <summary> 
	/// Number of CPU usage for a single microservice. <br />
	/// </summary>
	///
	[JsonPropertyName("cpu")]
	public int? Cpu { get; set; }

	/// <summary> 
	/// Number of memory usage for a single microservice. <br />
	/// </summary>
	///
	[JsonPropertyName("memory")]
	public int? Memory { get; set; }

	/// <summary> 
	/// Name of the microservice. <br />
	/// </summary>
	///
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
