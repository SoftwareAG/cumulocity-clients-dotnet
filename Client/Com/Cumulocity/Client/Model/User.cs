///
/// User.cs
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
	public class User<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary>
		/// A list of applications for this user.
		/// </summary>
		[JsonPropertyName("applications")]
		public List<Application>? Applications { get; set; }
	
		/// <summary>
		/// An object with a list of custom properties.
		/// </summary>
		[JsonPropertyName("customProperties")]
		public TCustomProperties? PCustomProperties { get; set; }
	
		/// <summary>
		/// The user's display name in Cumulocity IoT.
		/// </summary>
		[JsonPropertyName("displayName")]
		public string? DisplayName { get; set; }
	
		/// <summary>
		/// The user's email address.
		/// </summary>
		[JsonPropertyName("email")]
		public string? Email { get; set; }
	
		/// <summary>
		/// Indicates whether the user is enabled or not. Disabled users cannot log in or perform API requests.
		/// </summary>
		[JsonPropertyName("enabled")]
		public bool? Enabled { get; set; }
	
		/// <summary>
		/// The user's first name.
		/// </summary>
		[JsonPropertyName("firstName")]
		public string? FirstName { get; set; }
	
		/// <summary>
		/// An object with a list of user groups.
		/// </summary>
		[JsonPropertyName("groups")]
		public Groups<TCustomProperties>? PGroups { get; set; }
	
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
		/// Indicates whether the user is subscribed to the newsletter or not.
		/// </summary>
		[JsonPropertyName("newsletter")]
		public bool? Newsletter { get; set; }
	
		/// <summary>
		/// The user's password. Only Latin1 characters are allowed.
		/// 
		/// If you do not specify a password when creating a new user with a POST request, it must contain the property `sendPasswordResetEmail` with a value of `true`.
		/// 
		/// </summary>
		[JsonPropertyName("password")]
		public string? Password { get; set; }
	
		/// <summary>
		/// Indicates the password strength. The value can be GREEN, YELLOW or RED for decreasing password strengths.
		/// </summary>
		[JsonPropertyName("passwordStrength")]
		public PasswordStrength? PPasswordStrength { get; set; }
	
		/// <summary>
		/// The user's phone number.
		/// </summary>
		[JsonPropertyName("phone")]
		public string? Phone { get; set; }
	
		/// <summary>
		/// An object with a list of user roles.
		/// </summary>
		[JsonPropertyName("roles")]
		public Roles? PRoles { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// When set to `true`, this field will cause Cumulocity IoT to send a password reset email to the email address specified.
		/// 
		/// If there is no password specified when creating a new user with a POST request, this must be specified and it must be set to `true`.
		/// 
		/// </summary>
		[JsonPropertyName("sendPasswordResetEmail")]
		public bool? SendPasswordResetEmail { get; set; }
	
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
	
		/// <summary>
		/// Indicates the password strength. The value can be GREEN, YELLOW or RED for decreasing password strengths.
		/// [GREEN, YELLOW, RED]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
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
		/// An object with a list of user groups.
		/// </summary>
		public class Groups<TCustomProperties> where TCustomProperties : CustomProperties
		{
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			/// <summary>
			/// A list of user group references.
			/// </summary>
			[JsonPropertyName("references")]
			public List<GroupReference<TCustomProperties>>? References { get; set; }
		
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
		/// An object with a list of user roles.
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
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
