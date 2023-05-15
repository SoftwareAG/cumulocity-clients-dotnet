//
// C8yAgent.cs
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
/// The term "agent" refers to the piece of software that connects a device with Cumulocity IoT. <br />
/// </summary>
///
public sealed class C8yAgent 
{

	/// <summary> 
	/// The name of the agent. <br />
	/// </summary>
	///
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary> 
	/// The version of the agent. <br />
	/// </summary>
	///
	[JsonPropertyName("version")]
	public string? Version { get; set; }

	/// <summary> 
	/// The URL of the agent, for example, its code repository. <br />
	/// </summary>
	///
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	public C8yAgent() 
	{
	}

	public C8yAgent(string name, string version)
	{
		this.Name = name;
		this.Version = version;
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
