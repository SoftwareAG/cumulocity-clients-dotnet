//
// C8yLogfileRequest.cs
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

/// <summary> 
/// Request a device to send a log file and view it in Cumulocity IoT's log viewer. <br />
/// </summary>
///
public sealed class C8yLogfileRequest 
{

	/// <summary> 
	/// Indicates the log file to select. <br />
	/// </summary>
	///
	[JsonPropertyName("logFile")]
	public string? LogFile { get; set; }

	/// <summary> 
	/// Start date and time of log entries in the log file to be sent. <br />
	/// </summary>
	///
	[JsonPropertyName("dateFrom")]
	public System.DateTime? DateFrom { get; set; }

	/// <summary> 
	/// End date and time of log entries in the log file to be sent. <br />
	/// </summary>
	///
	[JsonPropertyName("dateTo")]
	public System.DateTime? DateTo { get; set; }

	/// <summary> 
	/// Provide a text that needs to be present in the log entry. <br />
	/// </summary>
	///
	[JsonPropertyName("searchText")]
	public string? SearchText { get; set; }

	/// <summary> 
	/// Upper limit of the number of lines that should be sent to Cumulocity IoT after filtering. <br />
	/// </summary>
	///
	[JsonPropertyName("maximumLines")]
	public int? MaximumLines { get; set; }

	/// <summary> 
	/// A link to the log file request. <br />
	/// </summary>
	///
	[JsonPropertyName("file")]
	public string? File { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
