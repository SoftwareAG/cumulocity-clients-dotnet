//
// User.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class User<TCustomProperties> where TCustomProperties : CustomProperties
{

	/// <summary> 
	/// A list of applications for this user. <br />
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
	/// The user's display name in Cumulocity IoT. <br />
	/// </summary>
	///
	[JsonPropertyName("displayName")]
	public string? DisplayName { get; set; }

	/// <summary> 
	/// The user's email address. <br />
	/// </summary>
	///
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary> 
	/// Indicates whether the user is enabled or not. Disabled users cannot log in or perform API requests. <br />
	/// </summary>
	///
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }

	/// <summary> 
	/// The user's first name. <br />
	/// </summary>
	///
	[JsonPropertyName("firstName")]
	public string? FirstName { get; set; }

	/// <summary> 
	/// An object with a list of user groups. <br />
	/// </summary>
	///
	[JsonPropertyName("groups")]
	public Groups<TCustomProperties>? PGroups { get; set; }

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
	/// Indicates whether the user is subscribed to the newsletter or not. <br />
	/// </summary>
	///
	[JsonPropertyName("newsletter")]
	public bool? Newsletter { get; set; }

	/// <summary> 
	/// Identifier of the parent user. If present, indicates that a user belongs to a user hierarchy by pointing to its direct ancestor. Can only be set by users with role USER_MANAGEMENT_ADMIN during user creation. Otherwise it's assigned automatically. <br />
	/// </summary>
	///
	[JsonPropertyName("owner")]
	public string? Owner { get; set; }

	/// <summary> 
	/// The user's password. Only Latin1 characters are allowed. <br />
	/// If you do not specify a password when creating a new user with a POST request, it must contain the property <c>sendPasswordResetEmail</c> with a value of <c>true</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary> 
	/// Indicates the password strength. The value can be GREEN, YELLOW or RED for decreasing password strengths. <br />
	/// </summary>
	///
	[JsonPropertyName("passwordStrength")]
	public PasswordStrength? PPasswordStrength { get; set; }

	/// <summary> 
	/// The user's phone number. <br />
	/// </summary>
	///
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary> 
	/// An object with a list of user roles. <br />
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
	/// When set to <c>true</c>, this field will cause Cumulocity IoT to send a password reset email to the email address specified. <br />
	/// If there is no password specified when creating a new user with a POST request, this must be specified and it must be set to <c>true</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("sendPasswordResetEmail")]
	public bool? SendPasswordResetEmail { get; set; }

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
	public DevicePermissions? PDevicePermissions { get; set; }

	/// <summary> 
	/// Indicates the password strength. The value can be GREEN, YELLOW or RED for decreasing password strengths. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum PasswordStrength 
	{
		[EnumMember(Value = "GREEN")]
		GREEN,
		[EnumMember(Value = "YELLOW")]
		YELLOW,
		[EnumMember(Value = "RED")]
		RED
	}

	/// <summary> 
	/// An object with a list of user groups. <br />
	/// </summary>
	///
	public sealed class Groups<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// A list of user group references. <br />
		/// </summary>
		///
		[JsonPropertyName("references")]
		public List<GroupReference<TCustomProperties>> References { get; set; } = new List<GroupReference<TCustomProperties>>();
	
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
	/// An object with a list of user roles. <br />
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

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
