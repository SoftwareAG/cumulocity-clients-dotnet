///
/// CurrentUserTotpCode.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class CurrentUserTotpCode 
	{
	
		/// <summary> 
		/// Two-factor authentication code entered by the user to log in to the platform. <br />
		/// </summary>
		///
		[JsonPropertyName("code")]
		public string? Code { get; set; }
	
		public CurrentUserTotpCode() 
		{
		}
	
		public CurrentUserTotpCode(string code)
		{
			this.Code = code;
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
}
