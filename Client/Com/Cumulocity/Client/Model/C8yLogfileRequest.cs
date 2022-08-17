///
/// C8yLogfileRequest.cs
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
	/// <summary>
	/// Request a device to send a log file and view it in Cumulocity IoT's log viewer.
	/// </summary>
	public class C8yLogfileRequest 
	{
	
		/// <summary>
		/// Indicates the log file to select.
		/// </summary>
		[JsonPropertyName("logFile")]
		public string? LogFile { get; set; }
	
		/// <summary>
		/// Start date and time of log entries in the log file to be sent.
		/// </summary>
		[JsonPropertyName("dateFrom")]
		public System.DateTime? DateFrom { get; set; }
	
		/// <summary>
		/// End date and time of log entries in the log file to be sent.
		/// </summary>
		[JsonPropertyName("dateTo")]
		public System.DateTime? DateTo { get; set; }
	
		/// <summary>
		/// Provide a text that needs to be present in the log entry.
		/// </summary>
		[JsonPropertyName("searchText")]
		public string? SearchText { get; set; }
	
		/// <summary>
		/// Upper limit of the number of lines that should be sent to Cumulocity IoT after filtering.
		/// </summary>
		[JsonPropertyName("maximumLines")]
		public int? MaximumLines { get; set; }
	
		/// <summary>
		/// A link to the log file request.
		/// </summary>
		[JsonPropertyName("file")]
		public string? File { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
