//
// LoginOption.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using Client.Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Login option properties. <br />
/// </summary>
///
public sealed class LoginOption 
{

	/// <summary> 
	/// For basic authentication case only. <br />
	/// </summary>
	///
	[JsonPropertyName("authenticationRestrictions")]
	public BasicAuthenticationRestrictions? AuthenticationRestrictions { get; set; }

	/// <summary> 
	/// Indicates if password strength is enforced. <br />
	/// </summary>
	///
	[JsonPropertyName("enforceStrength")]
	public bool? EnforceStrength { get; set; }

	/// <summary> 
	/// The grant type of the OAuth configuration. <br />
	/// </summary>
	///
	[JsonPropertyName("grantType")]
	public GrantType? PGrantType { get; set; }

	/// <summary> 
	/// Minimum length for the password when the strength validation is enforced. <br />
	/// </summary>
	///
	[JsonPropertyName("greenMinLength")]
	public int? GreenMinLength { get; set; }

	/// <summary> 
	/// Unique identifier of this login option. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary> 
	/// A URL linking to the token generating endpoint. <br />
	/// </summary>
	///
	[JsonPropertyName("initRequest")]
	public string? InitRequest { get; set; }

	/// <summary> 
	/// The tenant domain. <br />
	/// </summary>
	///
	[JsonPropertyName("loginRedirectDomain")]
	public string? LoginRedirectDomain { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// The session configuration properties are only available for OAuth internal. See <see href="https://cumulocity.com/guides/users-guide/administration/#oauth-internal" langword="Changing settings > OAuth internal" /> for more details. <br />
	/// </summary>
	///
	[JsonPropertyName("sessionConfiguration")]
	public OAuthSessionConfiguration? SessionConfiguration { get; set; }

	/// <summary> 
	/// Enforce password strength validation on subtenant level. <c>enforceStrength</c> enforces it on all tenants in the platform. <br />
	/// </summary>
	///
	[JsonPropertyName("strengthValidity")]
	public bool? StrengthValidity { get; set; }

	/// <summary> 
	/// Two-factor authentication being used by this login option. TFA supported: SMS and TOTP. <br />
	/// </summary>
	///
	[JsonPropertyName("tfaStrategy")]
	public string? TfaStrategy { get; set; }

	/// <summary> 
	/// The type of authentication. See <see href="#section/Authentication" langword="Authentication" /> for more details. <br />
	/// </summary>
	///
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary> 
	/// Specifies if the users are managed internally by Cumulocity IoT (<c>INTERNAL</c>) or if the users data are managed by a external system (<c>REMOTE</c>). <br />
	/// </summary>
	///
	[JsonPropertyName("userManagementSource")]
	public string? UserManagementSource { get; set; }

	/// <summary> 
	/// Indicates if this login option is available in the login page (only for SSO). <br />
	/// </summary>
	///
	[JsonPropertyName("visibleOnLoginPage")]
	public bool? VisibleOnLoginPage { get; set; }

	/// <summary> 
	/// The type of authentication. <br />
	/// </summary>
	///
	[System.Obsolete("This property might be removed in future releases.", false)]
	[JsonPropertyName("_type")]
	public string? PType { get; set; }

	/// <summary> 
	/// The grant type of the OAuth configuration. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum GrantType 
	{
		[EnumMember(Value = "PASSWORD")]
		PASSWORD,
		[EnumMember(Value = "AUTHORIZATION_CODE")]
		AUTHORIZATIONCODE
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
