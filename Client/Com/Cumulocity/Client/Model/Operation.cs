///
/// Operation.cs
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
	public class Operation 
	{
	
		/// <summary>
		/// Reference to a bulk operation ID if this operation was scheduled from a bulk operation.
		/// </summary>
		[JsonPropertyName("bulkOperationId")]
		public string? BulkOperationId { get; set; }
	
		/// <summary>
		/// Date and time when the operation was created in the database.
		/// </summary>
		[JsonPropertyName("creationTime")]
		public System.DateTime? CreationTime { get; set; }
	
		/// <summary>
		/// Identifier of the target device where the operation should be performed.
		/// </summary>
		[JsonPropertyName("deviceId")]
		public string? DeviceId { get; set; }
	
		[JsonPropertyName("deviceExternalIDs")]
		public ExternalIds? DeviceExternalIDs { get; set; }
	
		/// <summary>
		/// Reason for the failure.
		/// </summary>
		[JsonPropertyName("failureReason")]
		public string? FailureReason { get; set; }
	
		/// <summary>
		/// Unique identifier of this operation.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The status of the operation.
		/// </summary>
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		/// <summary>
		/// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, `"property1": {}`, `"property2": "value"`. These properties are known as custom fragments and can be of any type, for example, object or string. Each custom fragment is identified by a unique name.
		/// 
		/// Review the [Naming conventions of fragments](https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments) as there are characters that can not be used when naming custom fragments.
		/// 
		/// </summary>
		[JsonPropertyName("customFragments")]
		public Dictionary<string, object> CustomFragments { get; set; } = new Dictionary<string, object>();
		
		public object this[string key]
		{
			get => CustomFragments[key];
			set => CustomFragments[key] = value;
		}
	
		/// <summary>
		/// The status of the operation.
		/// [SUCCESSFUL, FAILED, EXECUTING, PENDING]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Status 
		{
			[EnumMember(Value = "SUCCESSFUL")]
			SUCCESSFUL,
			[EnumMember(Value = "FAILED")]
			FAILED,
			[EnumMember(Value = "EXECUTING")]
			EXECUTING,
			[EnumMember(Value = "PENDING")]
			PENDING
		}
	
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	
		private class JsonConverterAwareFragments : JsonConverter<Operation>
		{
		
			public override Operation? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
			{
				var instance = Activator.CreateInstance(typeToConvert) as Operation;
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
		
			public override void Write(Utf8JsonWriter writer, Operation value, JsonSerializerOptions options)
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
