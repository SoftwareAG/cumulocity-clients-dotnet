//
// BaseJsonConverter.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Converter;

public abstract class BaseJsonConverter<T> : JsonConverter<T> where T : class
{
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
					if (typeof(IDictionary<string, object>).IsAssignableFrom(property.PropertyType))
					{
						var dictionary = propertyValue as IDictionary;
						if (dictionary is not null)
						{
							foreach (DictionaryEntry item in dictionary)
							{
								writer.WritePropertyName((string)item.Key);
								JsonSerializerWrapper.Serialize(writer, item.Value, options);
							}
						}
					}
					else
					{
						var jsonProperty = GetJsonPropertyNameAttribute(property);
						var jsonPropertyName = jsonProperty?.Name ?? property.Name;
						writer.WritePropertyName(jsonPropertyName);
						JsonSerializerWrapper.Serialize(writer, propertyValue, options);
					}
				}
			}
		}
		writer.WriteEndObject();
	}

	protected PropertyInfo? FindProperty(List<PropertyInfo> instanceProperties, JsonProperty current)
	{
		return instanceProperties.Find(propertyInfo =>
		{
			var attribute = GetJsonPropertyNameAttribute(propertyInfo);
			return current.NameEquals(attribute?.Name ?? propertyInfo.Name);
		});
	}

	protected JsonPropertyNameAttribute? GetJsonPropertyNameAttribute(MemberInfo propertyInfo)
	{
		return (JsonPropertyNameAttribute?)Attribute.GetCustomAttribute(propertyInfo, typeof(JsonPropertyNameAttribute));
	}
}
