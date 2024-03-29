//
// Group.cs
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

public sealed class Group<TCustomProperties> where TCustomProperties : CustomProperties
{

	/// <summary> 
	/// A list of applications. <br />
	/// </summary>
	///
	[JsonPropertyName("applications")]
	public List<Application> Applications { get; set; } = new List<Application>();

	/// <summary> 
	/// An object with a list of custom properties. <br />
	/// </summary>
	///
	[JsonPropertyName("customProperties")]
	public TCustomProperties? PCustomProperties { get; set; }

	/// <summary> 
	/// A description of the group. <br />
	/// </summary>
	///
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary> 
	/// An object with a list of the user's device permissions. <br />
	/// </summary>
	///
	[System.Obsolete("This property might be removed in future releases.", false)]
	[JsonPropertyName("devicePermissions")]
	public DevicePermissions? PDevicePermissions { get; set; }

	/// <summary> 
	/// A unique identifier for this group. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public int? Id { get; set; }

	/// <summary> 
	/// The name of the group. <br />
	/// </summary>
	///
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary> 
	/// An object containing user roles for this group. <br />
	/// </summary>
	///
	[JsonPropertyName("roles")]
	public Roles? PRoles { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// The list of users in this group. <br />
	/// </summary>
	///
	[JsonPropertyName("users")]
	public Users<TCustomProperties>? PUsers { get; set; }

	public Group() 
	{
	}

	public Group(string name)
	{
		this.Name = name;
	}

	/// <summary> 
	/// An object containing user roles for this group. <br />
	/// </summary>
	///
	public sealed class Roles 
	{
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// A list of user role references. <br />
		/// </summary>
		///
		[JsonPropertyName("references")]
		public List<RoleReference> References { get; set; } = new List<RoleReference>();
	
		/// <summary> 
		/// Information about paging statistics. <br />
		/// </summary>
		///
		[JsonPropertyName("statistics")]
		public PageStatistics? Statistics { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	/// <summary> 
	/// The list of users in this group. <br />
	/// </summary>
	///
	public sealed class Users<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// The list of users in this group. <br />
		/// </summary>
		///
		[JsonPropertyName("references")]
		public List<User<TCustomProperties>> References { get; set; } = new List<User<TCustomProperties>>();
	
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
