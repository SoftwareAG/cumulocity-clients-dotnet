///
/// InventoryAssignmentReference.cs
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
	/// An inventory role reference. <br />
	/// </summary>
	///
	public class InventoryAssignmentReference 
	{
	
		/// <summary> 
		/// An array of roles that are assigned to the managed object for the user. <br />
		/// </summary>
		///
		[JsonPropertyName("roles")]
		public List<Roles> PRoles { get; set; } = new List<Roles>();
	
		public class Roles 
		{
		
			/// <summary> 
			/// A unique identifier for this inventory role. <br />
			/// </summary>
			///
			[JsonPropertyName("id")]
			public int? Id { get; set; }
		
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
