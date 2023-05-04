///
/// ApplicationVersionTag.cs
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
	public class ApplicationVersionTag 
	{
	
		/// <summary> 
		/// Tag assigned to the version. Version tags must be unique across all versions and version fields of application versions. <br />
		/// </summary>
		///
		[JsonPropertyName("tag")]
		public List<string> Tag { get; set; } = new List<string>();
	
		public ApplicationVersionTag() 
		{
		}
	
		public ApplicationVersionTag(List<string> tag)
		{
			this.Tag = tag;
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
