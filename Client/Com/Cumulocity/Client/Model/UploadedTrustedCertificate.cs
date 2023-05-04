///
/// UploadedTrustedCertificate.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class UploadedTrustedCertificate 
	{
	
		/// <summary> 
		/// Indicates whether the automatic device registration is enabled or not. <br />
		/// </summary>
		///
		[JsonPropertyName("autoRegistrationEnabled")]
		public bool? AutoRegistrationEnabled { get; set; }
	
		/// <summary> 
		/// Trusted certificate in PEM format. <br />
		/// </summary>
		///
		[JsonPropertyName("certInPemFormat")]
		public string? CertInPemFormat { get; set; }
	
		/// <summary> 
		/// Name of the certificate. <br />
		/// </summary>
		///
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary> 
		/// Indicates if the certificate is active and can be used by the device to establish a connection to the Cumulocity IoT platform. <br />
		/// </summary>
		///
		[JsonPropertyName("status")]
		public Status? PStatus { get; set; }
	
		public UploadedTrustedCertificate() 
		{
		}
	
		public UploadedTrustedCertificate(string certInPemFormat, Status status)
		{
			this.CertInPemFormat = certInPemFormat;
			this.PStatus = status;
		}
	
		/// <summary> 
		/// Indicates if the certificate is active and can be used by the device to establish a connection to the Cumulocity IoT platform. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Status 
		{
			[EnumMember(Value = "ENABLED")]
			ENABLED,
			[EnumMember(Value = "DISABLED")]
			DISABLED
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
