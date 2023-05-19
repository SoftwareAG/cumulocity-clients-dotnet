//
// TrustedCertificate.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class TrustedCertificate 
{

	/// <summary> 
	/// Algorithm used to decode/encode the certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("algorithmName")]
	public string? AlgorithmName { get; set; }

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
	/// Unique identifier of the trusted certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("fingerprint")]
	public string? Fingerprint { get; set; }

	/// <summary> 
	/// The name of the organization which signed the certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("issuer")]
	public string? Issuer { get; set; }

	/// <summary> 
	/// Name of the certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary> 
	/// The end date and time of the certificate's validity. <br />
	/// </summary>
	///
	[JsonPropertyName("notAfter")]
	public System.DateTime? NotAfter { get; set; }

	/// <summary> 
	/// The start date and time of the certificate's validity. <br />
	/// </summary>
	///
	[JsonPropertyName("notBefore")]
	public System.DateTime? NotBefore { get; set; }

	/// <summary> 
	/// Indicates whether the proof of possession for the certificate was provided. <br />
	/// </summary>
	///
	[JsonPropertyName("proofOfPossessionValid")]
	public bool? ProofOfPossessionValid { get; set; }

	/// <summary> 
	/// An unsigned verification code that provides proof of possession for the certificate after signing. <br />
	/// </summary>
	///
	[JsonPropertyName("proofOfPossessionUnsignedVerificationCode")]
	public string? ProofOfPossessionUnsignedVerificationCode { get; set; }

	/// <summary> 
	/// Validity of the verification code. <br />
	/// </summary>
	///
	[JsonPropertyName("proofOfPossessionVerificationCodeUsableUntil")]
	public System.DateTime? ProofOfPossessionVerificationCodeUsableUntil { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// The certificate's serial number. <br />
	/// </summary>
	///
	[JsonPropertyName("serialNumber")]
	public string? SerialNumber { get; set; }

	/// <summary> 
	/// Indicates if the certificate is active and can be used by the device to establish a connection to the Cumulocity IoT platform. <br />
	/// </summary>
	///
	[JsonPropertyName("status")]
	public Status? PStatus { get; set; }

	/// <summary> 
	/// Name of the organization to which the certificate belongs. <br />
	/// </summary>
	///
	[JsonPropertyName("subject")]
	public string? Subject { get; set; }

	/// <summary> 
	/// Version of the X.509 certificate standard. <br />
	/// </summary>
	///
	[JsonPropertyName("version")]
	public int? Version { get; set; }

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
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
