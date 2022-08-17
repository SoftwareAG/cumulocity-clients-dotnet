///
/// ApplicationCollection.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class ApplicationCollection 
	{
	
		/// <summary>
		/// An array of applications.
		/// </summary>
		[JsonPropertyName("applications")]
		public List<Application>? Applications { get; set; }
	
		/// <summary>
		/// A URI reference [[RFC3986](https://tools.ietf.org/html/rfc3986)] to a potential next page of managed objects.
		/// </summary>
		[JsonPropertyName("next")]
		public string? Next { get; set; }
	
		/// <summary>
		/// A URI reference [[RFC3986](https://tools.ietf.org/html/rfc3986)] to a potential previous page of managed objects.
		/// </summary>
		[JsonPropertyName("prev")]
		public string? Prev { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Information about paging statistics.
		/// </summary>
		[JsonPropertyName("statistics")]
		public PageStatistics? Statistics { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
