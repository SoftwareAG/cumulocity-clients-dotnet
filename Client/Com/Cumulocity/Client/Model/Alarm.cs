///
/// Alarm.cs
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
	public class Alarm 
	{
	
		/// <summary>
		/// Number of times that this alarm has been triggered.
		/// </summary>
		[JsonPropertyName("count")]
		public int? Count { get; set; }
	
		/// <summary>
		/// The date and time when the alarm was created.
		/// </summary>
		[JsonPropertyName("creationTime")]
		public System.DateTime? CreationTime { get; set; }
	
		/// <summary>
		/// The time at which the alarm occurred for the first time. Only present when `count` is greater than 1.
		/// </summary>
		[JsonPropertyName("firstOccurrenceTime")]
		public System.DateTime? FirstOccurrenceTime { get; set; }
	
		/// <summary>
		/// Unique identifier of the alarm.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// The date and time when the alarm was last updated.
		/// </summary>
		[JsonPropertyName("lastUpdated")]
		public System.DateTime? LastUpdated { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The severity of the alarm.
		/// </summary>
		[JsonPropertyName("severity")]
		public Severity? PSeverity { get; set; }
	
		/// <summary>
		/// The managed object to which the alarm is associated.
		/// </summary>
		[JsonPropertyName("source")]
		public Source? PSource { get; set; }
	
		/// <summary>
		/// The status of the alarm. If not specified, a new alarm will be created as ACTIVE.
		/// </summary>
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		/// <summary>
		/// Description of the alarm.
		/// </summary>
		[JsonPropertyName("text")]
		public string? Text { get; set; }
	
		/// <summary>
		/// The date and time when the alarm is triggered.
		/// </summary>
		[JsonPropertyName("time")]
		public System.DateTime? Time { get; set; }
	
		/// <summary>
		/// Identifies the type of this alarm.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary>
		/// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, `"property1": {}`, `"property2": "value"`. These properties are known as custom fragments and can be of any type, for example, object or string. Each custom fragment is identified by a unique name.
		/// 
		/// Review the [Naming conventions of fragments](https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments) as there are characters that can not be used when naming custom fragments.
		/// 
		/// </summary>
		[JsonPropertyName("customFragments")]
		public Dictionary<string, object>? CustomFragments { get; set; }
	
		/// <summary>
		/// The severity of the alarm.
		/// [CRITICAL, MAJOR, MINOR, WARNING]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Severity 
		{
			[EnumMember(Value = "CRITICAL")]
			CRITICAL,
			[EnumMember(Value = "MAJOR")]
			MAJOR,
			[EnumMember(Value = "MINOR")]
			MINOR,
			[EnumMember(Value = "WARNING")]
			WARNING
		}
	
		/// <summary>
		/// The status of the alarm. If not specified, a new alarm will be created as ACTIVE.
		/// [ACTIVE, ACKNOWLEDGED, CLEARED]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Status 
		{
			[EnumMember(Value = "ACTIVE")]
			ACTIVE,
			[EnumMember(Value = "ACKNOWLEDGED")]
			ACKNOWLEDGED,
			[EnumMember(Value = "CLEARED")]
			CLEARED
		}
	
	
		/// <summary>
		/// The managed object to which the alarm is associated.
		/// </summary>
		public class Source 
		{
		
			/// <summary>
			/// Unique identifier of the object.
			/// </summary>
			[JsonPropertyName("id")]
			public string? Id { get; set; }
		
			/// <summary>
			/// Human-readable name that is used for representing the object in user interfaces.
			/// </summary>
			[JsonPropertyName("name")]
			public string? Name { get; set; }
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	
		private class JsonConverterAwareFragments : JsonConverter<Alarm>
		{
		
			public override Alarm? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
			{
				var instance = Activator.CreateInstance(typeToConvert) as Alarm;
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
				instance.CustomFragments = additionalObjects;
				return instance;
			}
		
			public override void Write(Utf8JsonWriter writer, Alarm value, JsonSerializerOptions options)
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
