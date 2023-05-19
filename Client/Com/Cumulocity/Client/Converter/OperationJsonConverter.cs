//
// OperationJsonConverter.cs
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
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Converter;

public class OperationJsonConverter<T> : BaseJsonConverter<T> where T : Operation
{
	public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var instance = (T) Activator.CreateInstance(typeToConvert);
        var additionalObjects = new Dictionary<string, object?>();
		var instanceProperties = typeToConvert.GetTypeInfo().DeclaredProperties.ToList();
		using (var jsonDocument = JsonDocument.ParseValue(ref reader))
		{
			var objectEnumerator = jsonDocument.RootElement.EnumerateObject();
			while (objectEnumerator.MoveNext())
			{
				var current = objectEnumerator.Current;
				var property = FindProperty(instanceProperties, current);

                if (property != null)
				{
					var value = current.Value.Deserialize(property.PropertyType, options);
					property.SetValue(instance, value);
				}
				else
				{
                    additionalObjects.Add(current.Name,
						Operation.Serialization.AdditionalPropertyClasses.TryGetValue(current.Name, out var type)
						? current.Value.Deserialize(type, options)
						: current.Value.Deserialize<object>(options));
                }
			}
		}
		instance.CustomFragments = additionalObjects;
		return instance;
	}
}
