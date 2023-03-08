///
/// ApplicationManifestProbe.cs
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
	public class ApplicationManifestProbe 
	{
	
		/// <summary> 
		/// The probe failure threshold. <br />
		/// </summary>
		///
		[JsonPropertyName("failureThreshold")]
		public int? FailureThreshold { get; set; }
	
		/// <summary> 
		/// The probe period in seconds. <br />
		/// </summary>
		///
		[JsonPropertyName("periodSeconds")]
		public int? PeriodSeconds { get; set; }
	
		/// <summary> 
		/// The probe timeout in seconds. <br />
		/// </summary>
		///
		[JsonPropertyName("timeoutSeconds")]
		public int? TimeoutSeconds { get; set; }
	
		/// <summary> 
		/// The probe success threshold. <br />
		/// </summary>
		///
		[JsonPropertyName("successThreshold")]
		public int? SuccessThreshold { get; set; }
	
		/// <summary> 
		/// The probe's initial delay in seconds. <br />
		/// </summary>
		///
		[JsonPropertyName("initialDelaySeconds")]
		public int? InitialDelaySeconds { get; set; }
	
		/// <summary> 
		/// The probe's HTTP GET method information. <br />
		/// </summary>
		///
		[JsonPropertyName("httpGet")]
		public HttpGet? PHttpGet { get; set; }
	
		/// <summary> 
		/// The probe's HTTP GET method information. <br />
		/// </summary>
		///
		public class HttpGet 
		{
		
			/// <summary> 
			/// The HTTP path. <br />
			/// </summary>
			///
			[JsonPropertyName("path")]
			public string? Path { get; set; }
		
			/// <summary> 
			/// The HTTP port. <br />
			/// </summary>
			///
			[JsonPropertyName("port")]
			public int? Port { get; set; }
		
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
