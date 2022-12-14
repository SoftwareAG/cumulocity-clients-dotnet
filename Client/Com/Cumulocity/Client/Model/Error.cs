///
/// Error.cs
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
	public class Error 
	{
	
		/// <summary>
		/// The type of error returned.
		/// </summary>
		[JsonPropertyName("error")]
		public string? PError { get; set; }
	
		/// <summary>
		/// A human-readable message providing more details about the error.
		/// </summary>
		[JsonPropertyName("message")]
		public string? Message { get; set; }
	
		/// <summary>
		/// A URI reference [[RFC3986](https://tools.ietf.org/html/rfc3986)] that identifies the error code reported.
		/// </summary>
		[JsonPropertyName("info")]
		public string? Info { get; set; }
	
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
