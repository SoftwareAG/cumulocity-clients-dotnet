///
/// InventoryRolePermission.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// A permission object of an inventory role.
	/// </summary>
	public class InventoryRolePermission 
	{
	
		/// <summary>
		/// A unique identifier for this permission.
		/// </summary>
		[JsonPropertyName("id")]
		public int? Id { get; set; }
	
		/// <summary>
		/// The permission level.
		/// </summary>
		[JsonPropertyName("permission")]
		public Permission? PPermission { get; set; }
	
		/// <summary>
		/// The scope of this permission.
		/// </summary>
		[JsonPropertyName("scope")]
		public Scope? PScope { get; set; }
	
		/// <summary>
		/// The type of this permission. It can be the name of a fragment, for example, `c8y_Restart`.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary>
		/// The permission level.
		/// [ADMIN, READ, *]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Permission 
		{
			[EnumMember(Value = "ADMIN")]
			ADMIN,
			[EnumMember(Value = "READ")]
			READ,
			[EnumMember(Value = "*")]
			ALL
		}
	
		/// <summary>
		/// The scope of this permission.
		/// [ALARM, AUDIT, EVENT, MANAGED_OBJECT, MEASUREMENT, OPERATION, *]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Scope 
		{
			[EnumMember(Value = "ALARM")]
			ALARM,
			[EnumMember(Value = "AUDIT")]
			AUDIT,
			[EnumMember(Value = "EVENT")]
			EVENT,
			[EnumMember(Value = "MANAGED_OBJECT")]
			MANAGEDOBJECT,
			[EnumMember(Value = "MEASUREMENT")]
			MEASUREMENT,
			[EnumMember(Value = "OPERATION")]
			OPERATION,
			[EnumMember(Value = "*")]
			ALL
		}
	
	
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
