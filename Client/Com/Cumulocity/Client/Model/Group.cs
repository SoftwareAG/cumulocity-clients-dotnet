///
/// Group.cs
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
	public class Group 
	{
	
		/// <summary>
		/// A list of applications.
		/// </summary>
		[JsonPropertyName("applications")]
		public List<Application>? Applications { get; set; }
	
		/// <summary>
		/// An object with a list of custom properties.
		/// </summary>
		[JsonPropertyName("customProperties")]
		public CustomProperties? PCustomProperties { get; set; }
	
		/// <summary>
		/// A description of the group.
		/// </summary>
		[JsonPropertyName("description")]
		public string? Description { get; set; }
	
		/// <summary>
		/// An object with a list of the user's device permissions.
		/// </summary>
		[ObsoleteAttribute("This property might be removed in future releases.", false)]
		[JsonPropertyName("devicePermissions")]
		public DevicePermissions? PDevicePermissions { get; set; }
	
		/// <summary>
		/// A unique identifier for this group.
		/// </summary>
		[JsonPropertyName("id")]
		public int? Id { get; set; }
	
		/// <summary>
		/// The name of the group.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary>
		/// An object containing user roles for this group.
		/// </summary>
		[JsonPropertyName("roles")]
		public Roles? PRoles { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The list of users in this group.
		/// </summary>
		[JsonPropertyName("users")]
		public Users? PUsers { get; set; }
	
		public Group() 
		{
		}
	
		public Group(string name)
		{
			this.Name = name;
		}
	
		/// <summary>
		/// An object containing user roles for this group.
		/// </summary>
		public class Roles 
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			/// <summary>
			/// A list of user role references.
			/// </summary>
			[JsonPropertyName("references")]
			public List<RoleReference>? References { get; set; }
		
			/// <summary>
			/// Information about paging statistics.
			/// </summary>
			[JsonPropertyName("statistics")]
			public PageStatistics? Statistics { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		/// <summary>
		/// The list of users in this group.
		/// </summary>
		public class Users 
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			/// <summary>
			/// The list of users in this group.
			/// </summary>
			[JsonPropertyName("references")]
			public List<User>? References { get; set; }
		
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
