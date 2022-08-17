///
/// CategoryOptions.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	[JsonConverter(typeof(JsonConverterAwareFragments))]
	public class CategoryOptions 
	{
	
		/// <summary>
		/// It is possible to specify an arbitrary number of existing options as a list of key-value pairs, for example, `"key1": "value1"`, `"key2": "value2"`.
		/// </summary>
		[JsonPropertyName("keyValuePairs")]
		public Dictionary<string, object>? KeyValuePairs { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	
		private class JsonConverterAwareFragments : JsonConverter<CategoryOptions>
		{
		
			public override CategoryOptions? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
			{
				var instance = Activator.CreateInstance(typeToConvert) as CategoryOptions;
				var additionalObjects = new Dictionary<string, object>();
				var instanceProperties = typeToConvert.GetTypeInfo().DeclaredProperties.ToList();
				using (var jsonDocument = JsonDocument.ParseValue(ref reader))
				{
					var objectEnumerator = jsonDocument.RootElement.EnumerateObject();
					while (objectEnumerator.MoveNext())
					{
						var current = objectEnumerator.Current;
						var property = instanceProperties.Find(x =>
						{
							var jsonProperty = (JsonPropertyNameAttribute)Attribute.GetCustomAttribute(x, typeof(JsonPropertyNameAttribute));
							var jsonPropertyName = jsonProperty != null ? jsonProperty.Name : x.Name;
							return current.NameEquals(jsonPropertyName);
						});
						if (property != null)
						{
							var value = current.Value.Deserialize(property.PropertyType, options);
							property.SetValue(instance, value);
						}
						else if (Serialization.AdditionalPropertyClasses.ContainsKey(current.Name))
						{
							var type = Serialization.AdditionalPropertyClasses[current.Name];
							additionalObjects.Add(current.Name, current.Value.Deserialize(type, options));
						}
						else
						{
							additionalObjects.Add(current.Name, current.Value.Deserialize<object>(options));
						}
					}
				}
				instance.KeyValuePairs = additionalObjects;
				return instance;
			}
		
			public override void Write(Utf8JsonWriter writer, CategoryOptions value, JsonSerializerOptions options)
			{
				writer.WriteStartObject();
				var type = value.GetType();
		
				foreach (PropertyInfo property in type.GetProperties())
				{
			if (property.CanRead)
			{
				var propertyValue = property.GetValue(value, null);
				if (propertyValue != null)
				{
					if (typeof(System.Collections.IDictionary).IsAssignableFrom(property.PropertyType))
					{
						var dictionary = propertyValue as System.Collections.IDictionary;
						foreach (DictionaryEntry item in dictionary)
						{
							writer.WritePropertyName((string)item.Key);
							JsonSerializer.Serialize(writer, item.Value, options);
						}
					}
					else
					{
						var jsonProperty = (JsonPropertyNameAttribute)Attribute.GetCustomAttribute(property, typeof(JsonPropertyNameAttribute));
						var jsonPropertyName = jsonProperty != null ? jsonProperty.Name : property.Name;
						writer.WritePropertyName(jsonPropertyName);
						JsonSerializer.Serialize(writer, propertyValue, options);
					}
				}
			}
				}
				writer.WriteEndObject();
			}
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
