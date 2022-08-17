///
/// BasicAuthenticationRestrictions.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// For basic authentication case only.
	/// </summary>
	public class BasicAuthenticationRestrictions 
	{
	
		/// <summary>
		/// List of types of clients which are not allowed to use basic authentication. Currently the only supported option is WEB_BROWSERS.
		/// </summary>
		[JsonPropertyName("forbiddenClients")]
		public List<string>? ForbiddenClients { get; set; }
	
		/// <summary>
		/// List of user agents, passed in `User-Agent` HTTP header, which are blocked if basic authentication is used.
		/// </summary>
		[JsonPropertyName("forbiddenUserAgents")]
		public List<string>? ForbiddenUserAgents { get; set; }
	
		/// <summary>
		/// List of user agents, passed in `User-Agent` HTTP header, which are allowed to use basic authentication.
		/// </summary>
		[JsonPropertyName("trustedUserAgents")]
		public List<string>? TrustedUserAgents { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
