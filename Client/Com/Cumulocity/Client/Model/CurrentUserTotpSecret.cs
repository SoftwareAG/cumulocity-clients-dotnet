///
/// CurrentUserTotpSecret.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class CurrentUserTotpSecret 
	{
	
		/// <summary> 
		/// Secret used by two-factor authentication applications to generate the TFA codes. <br />
		/// </summary>
		///
		[JsonPropertyName("rawSecret")]
		public string? RawSecret { get; set; }
	
		/// <summary> 
		/// URL used to set the two-factor authentication secret for the TFA application. <br />
		/// </summary>
		///
		[JsonPropertyName("secretQrUrl")]
		public string? SecretQrUrl { get; set; }
	
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
