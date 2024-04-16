//
// LoginForm.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class LoginForm 
{

	/// <summary> 
	/// Used in case of SSO login. A code received from the external authentication server is exchanged to an internal access token. <br />
	/// </summary>
	///
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary> 
	/// Dependent on the authentication type. PASSWORD is used for OAI-Secure. <br />
	/// </summary>
	///
	[JsonPropertyName("grant_type")]
	public GrantType? PGrantType { get; set; }

	/// <summary> 
	/// Used in case of OAI-Secure authentication. <br />
	/// </summary>
	///
	[JsonPropertyName("password")]
	public string? Password { get; set; }

	/// <summary> 
	/// Current TFA code, sent by the user, if a TFA code is required to log in. Used in case of OAI-Secure authentication. <br />
	/// </summary>
	///
	[JsonPropertyName("tfa_code")]
	public string? TfaCode { get; set; }

	/// <summary> 
	/// Used in case of OAI-Secure authentication. <br />
	/// </summary>
	///
	[JsonPropertyName("username")]
	public string? Username { get; set; }

	/// <summary> 
	/// Dependent on the authentication type. PASSWORD is used for OAI-Secure. <br />
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
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
