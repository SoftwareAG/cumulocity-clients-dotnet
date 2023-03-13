///
/// CategoryOptions.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	[JsonConverter(typeof(CategoryOptionsJsonConverter<CategoryOptions>))]
	public class CategoryOptions 
	{
	
		/// <summary> 
		/// It is possible to specify an arbitrary number of existing options as a list of key-value pairs, for example, <c>"key1": "value1"</c>, <c>"key2": "value2"</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("keyValuePairs")]
		public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();
		
		[JsonIgnore]
		public object this[string key]
		{
			get => KeyValuePairs[key];
			set => KeyValuePairs[key] = value;
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
