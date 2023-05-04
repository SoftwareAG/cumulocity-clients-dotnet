///
/// ApplicationBinaries.cs
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
	public class ApplicationBinaries 
	{
	
		/// <summary> 
		/// An array of attachments. <br />
		/// </summary>
		///
		[JsonPropertyName("attachments")]
		public List<Attachments> PAttachments { get; set; } = new List<Attachments>();
	
		public class Attachments 
		{
		
			/// <summary> 
			/// The application context path. <br />
			/// </summary>
			///
			[JsonPropertyName("contextPath")]
			public string? ContextPath { get; set; }
		
			/// <summary> 
			/// The date and time when the attachment was created. <br />
			/// </summary>
			///
			[JsonPropertyName("created")]
			public System.DateTime? Created { get; set; }
		
			/// <summary> 
			/// A description for the attachment. <br />
			/// </summary>
			///
			[JsonPropertyName("description")]
			public string? Description { get; set; }
		
			/// <summary> 
			/// A download URL for the attachment. <br />
			/// </summary>
			///
			[JsonPropertyName("downloadUrl")]
			public string? DownloadUrl { get; set; }
		
			/// <summary> 
			/// The ID of the attachment. <br />
			/// </summary>
			///
			[JsonPropertyName("id")]
			public string? Id { get; set; }
		
			/// <summary> 
			/// The length of the attachment, in bytes. <br />
			/// </summary>
			///
			[JsonPropertyName("length")]
			public int? Length { get; set; }
		
			/// <summary> 
			/// The name of the attachment. <br />
			/// </summary>
			///
			[JsonPropertyName("name")]
			public string? Name { get; set; }
		
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
