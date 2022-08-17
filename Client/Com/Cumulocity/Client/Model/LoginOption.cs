///
/// LoginOption.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// Login option properties.
	/// </summary>
	public class LoginOption 
	{
	
		/// <summary>
		/// For basic authentication case only.
		/// </summary>
		[JsonPropertyName("authenticationRestrictions")]
		public BasicAuthenticationRestrictions? AuthenticationRestrictions { get; set; }
	
		/// <summary>
		/// Indicates if password strength is enforced.
		/// </summary>
		[JsonPropertyName("enforceStrength")]
		public bool? EnforceStrength { get; set; }
	
		/// <summary>
		/// The grant type of the OAuth configuration.
		/// </summary>
		[JsonPropertyName("grantType")]
		public GrantType? PGrantType { get; set; }
	
		/// <summary>
		/// Minimum length for the password when the strength validation is enforced.
		/// </summary>
		[JsonPropertyName("greenMinLength")]
		public int? GreenMinLength { get; set; }
	
		/// <summary>
		/// Unique identifier of this login option.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// A URL linking to the token generating endpoint.
		/// </summary>
		[JsonPropertyName("initRequest")]
		public string? InitRequest { get; set; }
	
		/// <summary>
		/// The tenant domain.
		/// </summary>
		[JsonPropertyName("loginRedirectDomain")]
		public string? LoginRedirectDomain { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The session configuration properties are only available for OAuth internal. See [Changing settings > OAuth internal](https://cumulocity.com/guides/users-guide/administration/#oauth-internal) for more details.
		/// </summary>
		[JsonPropertyName("sessionConfiguration")]
		public OAuthSessionConfiguration? SessionConfiguration { get; set; }
	
		/// <summary>
		/// Enforce password strength validation on subtenant level. `enforceStrength` enforces it on all tenants in the platform.
		/// </summary>
		[JsonPropertyName("strengthValidity")]
		public bool? StrengthValidity { get; set; }
	
		/// <summary>
		/// Two-factor authentication being used by this login option. TFA supported: SMS and TOTP.
		/// </summary>
		[JsonPropertyName("tfaStrategy")]
		public string? TfaStrategy { get; set; }
	
		/// <summary>
		/// The type of authentication. See [Authentication](#section/Authentication) for more details.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary>
		/// Specifies if the users are managed internally by Cumulocity IoT (`INTERNAL`) or if the users data are managed by a external system (`REMOTE`).
		/// </summary>
		[JsonPropertyName("userManagementSource")]
		public string? UserManagementSource { get; set; }
	
		/// <summary>
		/// Indicates if this login option is available in the login page (only for SSO).
		/// </summary>
		[JsonPropertyName("visibleOnLoginPage")]
		public bool? VisibleOnLoginPage { get; set; }
	
		/// <summary>
		/// The type of authentication.
		/// </summary>
		[ObsoleteAttribute("This property might be removed in future releases.", false)]
		[JsonPropertyName("_type")]
		public string? PType { get; set; }
	
		/// <summary>
		/// The grant type of the OAuth configuration.
		/// [PASSWORD, AUTHORIZATION_CODE]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum GrantType 
		{
			[EnumMember(Value = "PASSWORD")]
			PASSWORD,
			[EnumMember(Value = "AUTHORIZATION_CODE")]
			AUTHORIZATIONCODE
		}
	
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
