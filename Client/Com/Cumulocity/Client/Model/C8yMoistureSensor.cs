//
// C8yMoistureSensor.cs
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

/// <summary> 
/// A moisture sensor measures the water content of a substance. In a managed object, a moisture sensor is modeled as a simple empty fragment. <br />
/// </summary>
///
public sealed class C8yMoistureSensor 
{

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
