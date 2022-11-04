///
/// CurrentUser.cs
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
	/// <summary>
	/// The current user.
	/// </summary>
	public class CurrentUser 
	{
	
		/// <summary>
		/// A list of user roles.
		/// </summary>
		[JsonPropertyName("effectiveRoles")]
		public List<Role>? EffectiveRoles { get; set; }
	
		/// <summary>
		/// The user's email address.
		/// </summary>
		[JsonPropertyName("email")]
		public string? Email { get; set; }
	
		/// <summary>
		/// The user's first name.
		/// </summary>
		[JsonPropertyName("firstName")]
		public string? FirstName { get; set; }
	
		/// <summary>
		/// A unique identifier for this user.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// The user's last name.
		/// </summary>
		[JsonPropertyName("lastName")]
		public string? LastName { get; set; }
	
		/// <summary>
		/// The date and time when the user's password was last changed, in [ISO 8601 datetime format](https://www.w3.org/TR/NOTE-datetime).
		/// </summary>
		[JsonPropertyName("lastPasswordChange")]
		public System.DateTime? LastPasswordChange { get; set; }
	
		/// <summary>
		/// The user's password. Only Latin1 characters are allowed.
		/// </summary>
		[JsonPropertyName("password")]
		public string? Password { get; set; }
	
		/// <summary>
		/// The user's phone number.
		/// </summary>
		[JsonPropertyName("phone")]
		public string? Phone { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Indicates if the user should reset the password on the next login.
		/// </summary>
		[JsonPropertyName("shouldResetPassword")]
		public bool? ShouldResetPassword { get; set; }
	
		/// <summary>
		/// Indicates if the user has to use two-factor authentication to log in.
		/// </summary>
		[JsonPropertyName("twoFactorAuthenticationEnabled")]
		public bool? TwoFactorAuthenticationEnabled { get; set; }
	
		/// <summary>
		/// The user's username. It can have a maximum of 1000 characters.
		/// </summary>
		[JsonPropertyName("userName")]
		public string? UserName { get; set; }
	
		/// <summary>
		/// An object with a list of the user's device permissions.
		/// </summary>
		[ObsoleteAttribute("This property might be removed in future releases.", false)]
		[JsonPropertyName("devicePermissions")]
		public DevicePermissions? PDevicePermissions { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
