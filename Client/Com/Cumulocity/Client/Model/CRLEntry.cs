//
// CRLEntry.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class CRLEntry 
{

	/// <summary> 
	/// Revoked certificate serial number in hexadecimal. <br />
	/// </summary>
	///
	[JsonPropertyName("serialNumberInHex")]
	public string? SerialNumberInHex { get; set; }

	/// <summary> 
	/// Date and time when the certificate is revoked. <br />
	/// </summary>
	///
	[JsonPropertyName("revocationDate")]
	public System.DateTime? RevocationDate { get; set; }

	public CRLEntry() 
	{
	}

	public CRLEntry(string serialNumberInHex)
	{
		this.SerialNumberInHex = serialNumberInHex;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
