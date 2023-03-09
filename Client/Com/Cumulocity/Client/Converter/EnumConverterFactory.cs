///
/// EnumConverterFactory.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Com.Cumulocity.Client.Converter 
{
	public class EnumConverterFactory : JsonConverterFactory
	{
	
		public EnumConverterFactory()
		{
		}
	
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert.IsEnum;
		}
	
		public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
	 		var findEnumMembers = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
				let attr = field.GetCustomAttribute<EnumMemberAttribute>()
				where attr != null
				select (field.Name, attr.Value);
	 		var dictionary = findEnumMembers.ToDictionary(p => p.Item1, p => p.Item2);
			var converter = new JsonStringEnumConverter(namingPolicy: new DictionaryLookupNamingPolicy(literalNames: dictionary), allowIntegerValues: false);
			return converter.CreateConverter(typeToConvert, options);
		}
	}
	
	internal class DictionaryLookupNamingPolicy : JsonNamingPolicy
	{
	
		readonly Dictionary<string, string> literalNames;
	
		public DictionaryLookupNamingPolicy(Dictionary<string, string> literalNames) : base() => this.literalNames = literalNames;
	
		public override string ConvertName(string name)
		{
			return literalNames.TryGetValue(name, out var value) ? value : name;
		}
	}
}
