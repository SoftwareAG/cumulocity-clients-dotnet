///
/// OAuthSessionConfiguration.cs
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
	/// <summary> 
	/// The session configuration properties are only available for OAuth internal. See <see href="https://cumulocity.com/guides/users-guide/administration/#oauth-internal" langword="Changing settings > OAuth internal" /> for more details. <br />
	/// </summary>
	///
	public class OAuthSessionConfiguration 
	{
	
		/// <summary> 
		/// Maximum session duration (in milliseconds) during which a user does not have to login again. <br />
		/// </summary>
		///
		[JsonPropertyName("absoluteTimeoutMillis")]
		public int? AbsoluteTimeoutMillis { get; set; }
	
		/// <summary> 
		/// Maximum number of parallel sessions for one user. <br />
		/// </summary>
		///
		[JsonPropertyName("maximumNumberOfParallelSessions")]
		public int? MaximumNumberOfParallelSessions { get; set; }
	
		/// <summary> 
		/// Amount of time before a token expires (in milliseconds) during which the token may be renewed. <br />
		/// </summary>
		///
		[JsonPropertyName("renewalTimeoutMillis")]
		public int? RenewalTimeoutMillis { get; set; }
	
		/// <summary> 
		/// Switch to turn additional user agent verification on or off during the session. <br />
		/// </summary>
		///
		[JsonPropertyName("userAgentValidationRequired")]
		public bool? UserAgentValidationRequired { get; set; }
	
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
