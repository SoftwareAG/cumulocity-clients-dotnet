///
/// BasicAuthenticationRestrictions.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// For basic authentication case only. <br />
	/// </summary>
	///
	public class BasicAuthenticationRestrictions 
	{
	
		/// <summary> 
		/// List of types of clients which are not allowed to use basic authentication. Currently the only supported option is WEB_BROWSERS. <br />
		/// </summary>
		///
		[JsonPropertyName("forbiddenClients")]
		public List<string> ForbiddenClients { get; set; } = new List<string>();
	
		/// <summary> 
		/// List of user agents, passed in <c>User-Agent</c> HTTP header, which are blocked if basic authentication is used. <br />
		/// </summary>
		///
		[JsonPropertyName("forbiddenUserAgents")]
		public List<string> ForbiddenUserAgents { get; set; } = new List<string>();
	
		/// <summary> 
		/// List of user agents, passed in <c>User-Agent</c> HTTP header, which are allowed to use basic authentication. <br />
		/// </summary>
		///
		[JsonPropertyName("trustedUserAgents")]
		public List<string> TrustedUserAgents { get; set; } = new List<string>();
	
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
