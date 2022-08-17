///
/// C8yAvailabilityStatus.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// The current status, one of `AVAILABLE`, `CONNECTED`, `MAINTENANCE`, `DISCONNECTED`.
	/// [AVAILABLE, CONNECTED, MAINTENANCE, DISCONNECTED]
	/// </summary>
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum C8yAvailabilityStatus 
	{
		[EnumMember(Value = "AVAILABLE")]
		AVAILABLE,
		[EnumMember(Value = "CONNECTED")]
		CONNECTED,
		[EnumMember(Value = "MAINTENANCE")]
		MAINTENANCE,
		[EnumMember(Value = "DISCONNECTED")]
		DISCONNECTED
	}
}
