///
/// C8yCurrentSensor.cs
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
	/// A current sensor measures the current flowing through it. In a managed object, a current sensor is modeled as a simple empty fragment.
	/// </summary>
	public class C8yCurrentSensor 
	{
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
