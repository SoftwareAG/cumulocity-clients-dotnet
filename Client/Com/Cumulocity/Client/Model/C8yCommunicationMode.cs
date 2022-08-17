///
/// C8yCommunicationMode.cs
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
	/// In order to send commands as text messages to devices, the devices must be put into SMS mode. To indicate that it supports SMS mode, a device needs to add the fragment `c8y_CommunicationMode` with a mode property of `SMS`.
	/// </summary>
	public class C8yCommunicationMode 
	{
	
		[JsonPropertyName("mode")]
		public string? Mode { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
