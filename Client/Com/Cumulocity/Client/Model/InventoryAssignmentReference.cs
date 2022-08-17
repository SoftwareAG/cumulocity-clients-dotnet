///
/// InventoryAssignmentReference.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// An inventory role reference.
	/// </summary>
	public class InventoryAssignmentReference 
	{
	
		/// <summary>
		/// An array of roles that are assigned to the managed object for the user.
		/// </summary>
		[JsonPropertyName("roles")]
		public List<Roles>? PRoles { get; set; }
	
		public class Roles 
		{
		
			/// <summary>
			/// A unique identifier for this inventory role.
			/// </summary>
			[JsonPropertyName("id")]
			public int? Id { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
