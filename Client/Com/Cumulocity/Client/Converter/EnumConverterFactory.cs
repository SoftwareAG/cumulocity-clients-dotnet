//
// EnumConverterFactory.cs
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
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Converter;

public class EnumConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		return typeToConvert.IsEnum;
	}

	public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		var findEnumMembers = typeToConvert
			.GetFields(BindingFlags.Public | BindingFlags.Static)
			.Select(static info => (info.Name, Attribute: info.GetCustomAttribute<EnumMemberAttribute>()))
			.Where(static tuple => tuple.Attribute != null)
			.Select(static tuple => (tuple.Name, tuple.Attribute.Value));
		var dictionary = findEnumMembers.ToDictionary(static p => p.Name, static p => p.Value);
		var converter = new JsonStringEnumConverter(namingPolicy: new DictionaryLookupNamingPolicy(literalNames: dictionary), allowIntegerValues: false);
		return converter.CreateConverter(typeToConvert, options);
	}
}
