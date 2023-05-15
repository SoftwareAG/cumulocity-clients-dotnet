//
// CurrentUser.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The current user. <br />
/// </summary>
///
public sealed class CurrentUser 
{

	/// <summary> 
	/// A list of user roles. <br />
	/// </summary>
	///
	[JsonPropertyName("effectiveRoles")]
	public List<Role> EffectiveRoles { get; set; } = new List<Role>();

	/// <summary> 
	/// The user's email address. <br />
	/// </summary>
	///
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary> 
	/// The user's first name. <br />
	/// </summary>
	///
	[JsonPropertyName("firstName")]
	public string? FirstName { get; set; }

	/// <summary> 
	/// A unique identifier for this user. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary> 
	/// The user's last name. <br />
	/// </summary>
	///
	[JsonPropertyName("lastName")]
	public string? LastName { get; set; }

	/// <summary> 
	/// The date and time when the user's password was last changed, in <see href="https://www.w3.org/TR/NOTE-datetime" langword="ISO 8601 datetime format" />. <br />
	/// </summary>
	///
	[JsonPropertyName("lastPasswordChange")]
	public System.DateTime? LastPasswordChange { get; set; }

	/// <summary> 
	/// The user's password. Only Latin1 characters are allowed. <br />
	/// </summary>
	///
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary> 
	/// The user's phone number. <br />
	/// </summary>
	///
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// Indicates if the user should reset the password on the next login. <br />
	/// </summary>
	///
	[JsonPropertyName("shouldResetPassword")]
	public bool? ShouldResetPassword { get; set; }

	/// <summary> 
	/// Indicates if the user has to use two-factor authentication to log in. <br />
	/// </summary>
	///
	[JsonPropertyName("twoFactorAuthenticationEnabled")]
	public bool? TwoFactorAuthenticationEnabled { get; set; }

	/// <summary> 
	/// The user's username. It can have a maximum of 1000 characters. <br />
	/// </summary>
	///
	[JsonPropertyName("userName")]
	public string? UserName { get; set; }

	/// <summary> 
	/// An object with a list of the user's device permissions. <br />
	/// </summary>
	///
	[System.Obsolete("This property might be removed in future releases.", false)]
	[JsonPropertyName("devicePermissions")]
	public DeprecatedDevicePermissions? DevicePermissions { get; set; }

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
