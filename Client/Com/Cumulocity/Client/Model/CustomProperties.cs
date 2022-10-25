///
/// CustomProperties.cs
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
	/// <summary>
	/// An object with a list of custom properties.
	/// </summary>
	[JsonConverter(typeof(JsonConverterAwareFragments))]
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
		
		public object this[string key]
		{
			get => PCustomProperties[key];
			set => PCustomProperties[key] = value;
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	
		private class JsonConverterAwareFragments : JsonConverter<CustomProperties>
		{
		
			public override CustomProperties? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
			{
				var instance = Activator.CreateInstance(typeToConvert) as CustomProperties;
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
				instance.PCustomProperties = additionalObjects;
				return instance;
			}
		
			public override void Write(Utf8JsonWriter writer, CustomProperties value, JsonSerializerOptions options)
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
