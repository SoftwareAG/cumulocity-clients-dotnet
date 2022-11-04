///
/// UserTfaData.cs
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
	public class UserTfaData 
	{
	
		/// <summary>
		/// Latest date and time when the user has used two-factor authentication to log in.
		/// </summary>
		[JsonPropertyName("lastTfaRequestTime")]
		public System.DateTime? LastTfaRequestTime { get; set; }
	
		/// <summary>
		/// Two-factor authentication strategy.
		/// </summary>
		[JsonPropertyName("strategy")]
		public Strategy? PStrategy { get; set; }
	
		/// <summary>
		/// Indicates whether the user has enabled two-factor authentication or not.
		/// </summary>
		[JsonPropertyName("tfaEnabled")]
		public bool? TfaEnabled { get; set; }
	
		/// <summary>
		/// Indicates whether two-factor authentication is enforced by the tenant admin or not.
		/// </summary>
		[JsonPropertyName("tfaEnforced")]
		public bool? TfaEnforced { get; set; }
	
		/// <summary>
		/// Two-factor authentication strategy.
		/// [SMS, TOTP]
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum Strategy 
		{
			[EnumMember(Value = "SMS")]
			SMS,
			[EnumMember(Value = "TOTP")]
			TOTP
		}
	
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
