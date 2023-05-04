///
/// UserGroupCollection.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class UserGroupCollection<TCustomProperties> where TCustomProperties : CustomProperties
	{
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// An array of user groups. <br />
		/// </summary>
		///
		[JsonPropertyName("groups")]
		public List<Group<TCustomProperties>> Groups { get; set; } = new List<Group<TCustomProperties>>();
	
		/// <summary> 
		/// A URI reference [<see href="https://tools.ietf.org/html/rfc3986" langword="RFC3986" />] to a potential previous page of managed objects. <br />
		/// </summary>
		///
		[JsonPropertyName("prev")]
		public string? Prev { get; set; }
	
		/// <summary> 
		/// A URI reference [<see href="https://tools.ietf.org/html/rfc3986" langword="RFC3986" />] to a potential next page of managed objects. <br />
		/// </summary>
		///
		[JsonPropertyName("next")]
		public string? Next { get; set; }
	
		/// <summary> 
		/// Information about paging statistics. <br />
		/// </summary>
		///
		[JsonPropertyName("statistics")]
		public PageStatistics? Statistics { get; set; }
	
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
