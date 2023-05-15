//
// UploadedTrustedCertSignedVerificationCode.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The signed verification code to prove the user's possession of the certificate. <br />
/// </summary>
///
public sealed class UploadedTrustedCertSignedVerificationCode 
{

	/// <summary> 
	/// A signed verification code that proves the right to use the certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("proofOfPossessionSignedVerificationCode")]
	public string? ProofOfPossessionSignedVerificationCode { get; set; }

	public UploadedTrustedCertSignedVerificationCode() 
	{
	}

	public UploadedTrustedCertSignedVerificationCode(string proofOfPossessionSignedVerificationCode)
	{
		this.ProofOfPossessionSignedVerificationCode = proofOfPossessionSignedVerificationCode;
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
