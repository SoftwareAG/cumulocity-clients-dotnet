///
/// InventoryRole.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// An inventory role. <br />
	/// </summary>
	///
	public class InventoryRole 
	{
	
		/// <summary> 
		/// A description for this inventory role. <br />
		/// </summary>
		///
		[JsonPropertyName("description")]
		public string? Description { get; set; }
	
		/// <summary> 
		/// A unique identifier for this inventory role. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public int? Id { get; set; }
	
		/// <summary> 
		/// The name of this inventory role. <br />
		/// </summary>
		///
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary> 
		/// A set of permissions for this inventory role. <br />
		/// </summary>
		///
		[JsonPropertyName("permissions")]
		public List<InventoryRolePermission> Permissions { get; set; } = new List<InventoryRolePermission>();
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		public override string ToString()
		{
			var jsonOptions = new JsonSerializerOptions() 
			{ 
				WriteIndented = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			};
			return JsonSerializer.Serialize(this, jsonOptions);
		}
	}
}
