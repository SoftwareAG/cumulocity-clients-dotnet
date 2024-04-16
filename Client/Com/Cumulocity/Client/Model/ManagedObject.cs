//
// ManagedObject.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

[JsonConverter(typeof(ManagedObjectJsonConverter<ManagedObject>))]
public class ManagedObject 
{

	/// <summary> 
	/// The date and time when the object was created. <br />
	/// </summary>
	///
	[JsonPropertyName("creationTime")]
	public System.DateTime? CreationTime { get; set; }

	/// <summary> 
	/// Unique identifier of the object. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary> 
	/// The date and time when the object was updated for the last time. <br />
	/// </summary>
	///
	[JsonPropertyName("lastUpdated")]
	public System.DateTime? LastUpdated { get; set; }

	/// <summary> 
	/// Human-readable name that is used for representing the object in user interfaces. <br />
	/// </summary>
	///
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary> 
	/// Username of the device's owner. <br />
	/// </summary>
	///
	[JsonPropertyName("owner")]
	public string? Owner { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// The fragment type can be interpreted as device class, this means, devices with the same type can receive the same types of configuration, software, firmware and operations. The type value is indexed and is therefore used for queries. <br />
	/// </summary>
	///
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary> 
	/// A collection of references to child additions. <br />
	/// </summary>
	///
	[JsonPropertyName("childAdditions")]
	public ObjectChildAdditions? ChildAdditions { get; set; }

	/// <summary> 
	/// A collection of references to child assets. <br />
	/// </summary>
	///
	[JsonPropertyName("childAssets")]
	public ObjectChildAssets? ChildAssets { get; set; }

	/// <summary> 
	/// A collection of references to child devices. <br />
	/// </summary>
	///
	[JsonPropertyName("childDevices")]
	public ObjectChildDevices? ChildDevices { get; set; }

	/// <summary> 
	/// A collection of references to addition parent objects. <br />
	/// </summary>
	///
	[JsonPropertyName("additionParents")]
	public ObjectAdditionParents? AdditionParents { get; set; }

	/// <summary> 
	/// A collection of references to asset parent objects. <br />
	/// </summary>
	///
	[JsonPropertyName("assetParents")]
	public ObjectAssetParents? AssetParents { get; set; }

	/// <summary> 
	/// A collection of references to device parent objects. <br />
	/// </summary>
	///
	[JsonPropertyName("deviceParents")]
	public ObjectDeviceParents? DeviceParents { get; set; }

	/// <summary> 
	/// A fragment which identifies this managed object as a device. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_IsDevice")]
	public C8yIsDevice? PC8yIsDevice { get; set; }

	/// <summary> 
	/// The read only fragment which contains the latest measurements reported by the device.The returned optionally only if the query parameter <c>withLatestValues=true</c> is used. <br />
	/// ⚠️ Feature Preview: The feature is part of the Latest Measurement feature which is still under public feature preview. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_LatestMeasurements")]
	public C8yLatestMeasurements? PC8yLatestMeasurements { get; set; }

	/// <summary> 
	/// A fragment which identifies this managed object as a device group. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_IsDeviceGroup")]
	public C8yIsDeviceGroup? PC8yIsDeviceGroup { get; set; }

	/// <summary> 
	/// This fragment must be added in order to publish sample commands for a subset of devices sharing the same device type. If the fragment is present, the list of sample commands for a device type will be extended with the sample commands for the <c>c8y_DeviceTypes</c>. New sample commands created from the user interface will be created in the context of the <c>c8y_DeviceTypes</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_DeviceTypes")]
	public List<string> C8yDeviceTypes { get; set; } = new List<string>();

	/// <summary> 
	/// Lists the operations that are available for a particular device, so that applications can trigger the operations. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_SupportedOperations")]
	public List<string> C8ySupportedOperations { get; set; } = new List<string>();

	/// <summary> 
	/// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, <c>"property1": {}</c>, <c>"property2": "value"</c>. These properties are known as custom fragments and can be of any type, for example, object or string. Each custom fragment is identified by a unique name. <br />
	/// Review <see href="https://cumulocity.com/docs/concepts/domain-model/#naming-conventions-of-fragments" langword="Getting started > Technical concepts > Cumulocity IoT's domain model > Inventory > Fragments > Naming conventions of fragments" /> in the Cumulocity IoT user documentation as there are characters that can not be used when naming custom fragments. <br />
	/// </summary>
	///
	[JsonPropertyName("customFragments")]
	public IDictionary<string, object?> CustomFragments { get; set; } = new Dictionary<string, object?>();
	
	[JsonIgnore]
	public object? this[string key]
	{
		get => CustomFragments[key];
		set => CustomFragments[key] = value;
	}

	/// <summary> 
	/// A fragment which identifies this managed object as a device. <br />
	/// </summary>
	///
	public sealed class C8yIsDevice 
	{
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	/// <summary> 
	/// A fragment which identifies this managed object as a device group. <br />
	/// </summary>
	///
	public sealed class C8yIsDeviceGroup 
	{
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
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
