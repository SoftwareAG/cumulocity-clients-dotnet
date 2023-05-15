//
// VerifyCertificateChain.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class VerifyCertificateChain 
{

	/// <summary> 
	/// The result of validating the certificate chain. <br />
	/// </summary>
	///
	[JsonPropertyName("successfullyValidated")]
	public bool? SuccessfullyValidated { get; set; }

	/// <summary> 
	/// The tenant ID used for validation. <br />
	/// </summary>
	///
	[JsonPropertyName("tenantId")]
	public string? TenantId { get; set; }

	/// <summary> 
	/// The name of the organization which signed the certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("issuer")]
	public string? Issuer { get; set; }

	/// <summary> 
	/// The name of the organization to which the certificate belongs. <br />
	/// </summary>
	///
	[JsonPropertyName("subject")]
	public string? Subject { get; set; }

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
