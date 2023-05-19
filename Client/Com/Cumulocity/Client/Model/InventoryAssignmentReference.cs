//
// InventoryAssignmentReference.cs
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
/// An inventory role reference. <br />
/// </summary>
///
public sealed class InventoryAssignmentReference 
{

	/// <summary> 
	/// An array of roles that are assigned to the managed object for the user. <br />
	/// </summary>
	///
	[JsonPropertyName("roles")]
	public List<Roles> PRoles { get; set; } = new List<Roles>();

	public sealed class Roles 
	{
	
		/// <summary> 
		/// A unique identifier for this inventory role. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public int? Id { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
