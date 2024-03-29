//
// InventoryAssignment.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// An inventory assignment. <br />
/// </summary>
///
public sealed class InventoryAssignment 
{

	/// <summary> 
	/// A unique identifier for this inventory assignment. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public int? Id { get; set; }

	/// <summary> 
	/// A unique identifier for the managed object for which the roles are assigned. <br />
	/// </summary>
	///
	[JsonPropertyName("managedObject")]
	public string? ManagedObject { get; set; }

	/// <summary> 
	/// An array of roles that are assigned to the managed object for the user. <br />
	/// </summary>
	///
	[JsonPropertyName("roles")]
	public List<InventoryRole> Roles { get; set; } = new List<InventoryRole>();

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
