///
/// ApplicationManifestProbe.cs
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
	public class ApplicationManifestProbe 
	{
	
		/// <summary>
		/// The probe failure threshold.
		/// </summary>
		[JsonPropertyName("failureThreshold")]
		public int? FailureThreshold { get; set; }
	
		/// <summary>
		/// The probe period in seconds.
		/// </summary>
		[JsonPropertyName("periodSeconds")]
		public int? PeriodSeconds { get; set; }
	
		/// <summary>
		/// The probe timeout in seconds.
		/// </summary>
		[JsonPropertyName("timeoutSeconds")]
		public int? TimeoutSeconds { get; set; }
	
		/// <summary>
		/// The probe success threshold.
		/// </summary>
		[JsonPropertyName("successThreshold")]
		public int? SuccessThreshold { get; set; }
	
		/// <summary>
		/// The probe's initial delay in seconds.
		/// </summary>
		[JsonPropertyName("initialDelaySeconds")]
		public int? InitialDelaySeconds { get; set; }
	
		/// <summary>
		/// The probe's HTTP GET method information.
		/// </summary>
		[JsonPropertyName("httpGet")]
		public HttpGet? PHttpGet { get; set; }
	
		/// <summary>
		/// The probe's HTTP GET method information.
		/// </summary>
		public class HttpGet 
		{
		
			/// <summary>
			/// The HTTP path.
			/// </summary>
			[JsonPropertyName("path")]
			public string? Path { get; set; }
		
			/// <summary>
			/// The HTTP port.
			/// </summary>
			[JsonPropertyName("port")]
			public int? Port { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
