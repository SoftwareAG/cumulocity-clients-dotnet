///
/// CustomProperties.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// An object with a list of custom properties.
	/// </summary>
	[JsonConverter(typeof(CustomPropertiesJsonConverter<CustomProperties>))]
	public class CustomProperties 
	{
	
		/// <summary>
		/// The preferred language to be used in the platform.
		/// </summary>
		[JsonPropertyName("language")]
		public string? Language { get; set; }
	
		/// <summary>
		/// It is possible to add an arbitrary number of custom properties as a list of key-value pairs, for example, `"property": "value"`.
		/// 
		/// </summary>
		[JsonPropertyName("customProperties")]
		public Dictionary<string, object> PCustomProperties { get; set; } = new Dictionary<string, object>();
		
		[JsonIgnore]
		public object this[string key]
		{
			get => PCustomProperties[key];
			set => PCustomProperties[key] = value;
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
	
		public class Serialization
		{
			public static readonly IDictionary<string, System.Type> AdditionalPropertyClasses = new Dictionary<string, System.Type>();
		
			public static void RegisterAdditionalProperty(string typeName, System.Type type)
			{
				AdditionalPropertyClasses[typeName] = type;
			}
		}
	}
}
