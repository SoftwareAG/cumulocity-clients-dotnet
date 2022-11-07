///
/// ApplicationUserCollection.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class ApplicationUserCollection 
	{
	
		/// <summary>
		/// A list of users who are subscribed to the current application.
		/// </summary>
		[JsonPropertyName("users")]
		public List<Users>? PUsers { get; set; }
	
		/// <summary>
		/// A user who is subscribed to the current application.
		/// </summary>
		public class Users 
		{
		
			/// <summary>
			/// The username.
			/// </summary>
			[JsonPropertyName("name")]
			public string? Name { get; set; }
		
			/// <summary>
			/// The user password.
			/// </summary>
			[JsonPropertyName("password")]
			public string? Password { get; set; }
		
			/// <summary>
			/// The user tenant.
			/// </summary>
			[JsonPropertyName("tenant")]
			public string? Tenant { get; set; }
		
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
