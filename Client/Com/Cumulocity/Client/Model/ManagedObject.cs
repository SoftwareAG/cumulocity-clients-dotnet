///
/// ManagedObject.cs
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
	public class ManagedObject 
	{
	
		/// <summary>
		/// The date and time when the object was created.
		/// </summary>
		[JsonPropertyName("creationTime")]
		public System.DateTime? CreationTime { get; set; }
	
		/// <summary>
		/// Unique identifier of the object.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// The date and time when the object was updated for the last time.
		/// </summary>
		[JsonPropertyName("lastUpdated")]
		public System.DateTime? LastUpdated { get; set; }
	
		/// <summary>
		/// Human-readable name that is used for representing the object in user interfaces.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary>
		/// Username of the device's owner.
		/// </summary>
		[JsonPropertyName("owner")]
		public string? Owner { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The fragment type can be interpreted as _device class_, this means, devices with the same type can receive the same types of configuration, software, firmware and operations. The type value is indexed and is therefore used for queries.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary>
		/// A collection of references to child additions.
		/// </summary>
		[JsonPropertyName("childAdditions")]
		public ObjectChildAdditions? ChildAdditions { get; set; }
	
		/// <summary>
		/// A collection of references to child assets.
		/// </summary>
		[JsonPropertyName("childAssets")]
		public ObjectChildAssets? ChildAssets { get; set; }
	
		/// <summary>
		/// A collection of references to child devices.
		/// </summary>
		[JsonPropertyName("childDevices")]
		public ObjectChildDevices? ChildDevices { get; set; }
	
		/// <summary>
		/// A collection of references to addition parent objects.
		/// </summary>
		[JsonPropertyName("additionParents")]
		public ObjectAdditionParents? AdditionParents { get; set; }
	
		/// <summary>
		/// A collection of references to asset parent objects.
		/// </summary>
		[JsonPropertyName("assetParents")]
		public ObjectAssetParents? AssetParents { get; set; }
	
		/// <summary>
		/// A collection of references to device parent objects.
		/// </summary>
		[JsonPropertyName("deviceParents")]
		public ObjectDeviceParents? DeviceParents { get; set; }
	
		/// <summary>
		/// A fragment which identifies this managed object as a device.
		/// </summary>
		[JsonPropertyName("c8y_IsDevice")]
		public C8yIsDevice? PC8yIsDevice { get; set; }
	
		/// <summary>
		/// This fragment must be added in order to publish sample commands for a subset of devices sharing the same device type. If the fragment is present, the list of sample commands for a device type will be extended with the sample commands for the `c8y_DeviceTypes`. New sample commands created from the user interface will be created in the context of the `c8y_DeviceTypes`.
		/// </summary>
		[JsonPropertyName("c8y_DeviceTypes")]
		public List<string>? C8yDeviceTypes { get; set; }
	
		/// <summary>
		/// Lists the operations that are available for a particular device, so that applications can trigger the operations.
		/// </summary>
		[JsonPropertyName("c8y_SupportedOperations")]
		public List<string>? C8ySupportedOperations { get; set; }
	
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
		/// A fragment which identifies this managed object as a device.
		/// </summary>
		public class C8yIsDevice 
		{
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	
		private class JsonConverterAwareFragments : JsonConverter<ManagedObject>
		{
		
			public override ManagedObject? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
			{
				var instance = Activator.CreateInstance(typeToConvert) as ManagedObject;
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
		
			public override void Write(Utf8JsonWriter writer, ManagedObject value, JsonSerializerOptions options)
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
