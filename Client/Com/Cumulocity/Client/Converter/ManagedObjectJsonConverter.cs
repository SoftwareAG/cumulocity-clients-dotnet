///
/// ManagedObjectJsonConverter.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Converter 
{
	public class ManagedObjectJsonConverter<T> : JsonConverter<T> where T : ManagedObject
	{
	
		public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var instance = Activator.CreateInstance(typeToConvert) as T;
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
						JsonPropertyNameAttribute? jsonProperty = (JsonPropertyNameAttribute?)Attribute.GetCustomAttribute(x, typeof(JsonPropertyNameAttribute));
						var jsonPropertyName = jsonProperty != null ? jsonProperty.Name : x.Name;
						return current.NameEquals(jsonPropertyName);
					});
					if (property != null)
					{
						var value = current.Value.Deserialize(property.PropertyType, options);
						property.SetValue(instance, value);
					}
					else if (ManagedObject.Serialization.AdditionalPropertyClasses.ContainsKey(current.Name))
					{
						var type = ManagedObject.Serialization.AdditionalPropertyClasses[current.Name];
						additionalObjects.Add(current.Name, current.Value.Deserialize(type, options));
					}
					else
					{
						additionalObjects.Add(current.Name, current.Value.Deserialize<object>(options));
					}
				}
			}
			instance.CustomFragments = additionalObjects;
			return instance;
		}
	
		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			var type = value.GetType();
	
			foreach (PropertyInfo property in type.GetProperties())
			{
				var isIgnoredProperty = Attribute.IsDefined(property, typeof(JsonIgnoreAttribute));
				if (property.CanRead && isIgnoredProperty == false)
				{
					var propertyValue = property.GetValue(value, null);
					if (propertyValue != null)
					{
						if (typeof(IDictionary).IsAssignableFrom(property.PropertyType))
						{
							var dictionary = propertyValue as IDictionary;
							if (dictionary is not null)
							{
								foreach (DictionaryEntry item in dictionary)
								{
									writer.WritePropertyName((string)item.Key);
									JsonSerializer.Serialize(writer, item.Value, options);
								}
							}
						}
						else
						{
							JsonPropertyNameAttribute? jsonProperty = (JsonPropertyNameAttribute?)Attribute.GetCustomAttribute(property, typeof(JsonPropertyNameAttribute));
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
}
