///
/// DevicePermissions.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// A list of device permissions. <br />
	/// </summary>
	///
	public class DevicePermissions<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		[JsonPropertyName("users")]
		public List<User<TCustomProperties>> Users { get; set; } = new List<User<TCustomProperties>>();
	
		[JsonPropertyName("groups")]
		public List<Group<TCustomProperties>> Groups { get; set; } = new List<Group<TCustomProperties>>();
	
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
