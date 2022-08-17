///
/// LoginForm.cs
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
	public class LoginForm 
	{
	
		/// <summary>
		/// Used in case of SSO login. A code received from the external authentication server is exchanged to an internal access token.
		/// </summary>
		[JsonPropertyName("code")]
		public string? Code { get; set; }
	
		/// <summary>
		/// Dependent on the authentication type. PASSWORD is used for OAI-Secure.
		/// </summary>
		[JsonPropertyName("grant_type")]
		public GrantType? PGrantType { get; set; }
	
		/// <summary>
		/// Used in cases of basic or OAI-Secure authentication.
		/// </summary>
		[JsonPropertyName("password")]
		public string? Password { get; set; }
	
		/// <summary>
		/// Used if TFA code is required.
		/// </summary>
		[JsonPropertyName("tfa_code")]
		public string? TfaCode { get; set; }
	
		/// <summary>
		/// Used in cases of basic or OAI-Secure authentication.
		/// </summary>
		[JsonPropertyName("username")]
		public string? Username { get; set; }
	
		/// <summary>
		/// Dependent on the authentication type. PASSWORD is used for OAI-Secure.
		/// [PASSWORD, AUTHORIZATION_CODE, REFRESH_TOKEN]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum GrantType 
		{
			[EnumMember(Value = "PASSWORD")]
			PASSWORD,
			[EnumMember(Value = "AUTHORIZATION_CODE")]
			AUTHORIZATIONCODE,
			[EnumMember(Value = "REFRESH_TOKEN")]
			REFRESHTOKEN
		}
	
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
