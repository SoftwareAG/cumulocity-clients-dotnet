///
/// Binary.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class Binary 
	{
	
		/// <summary> 
		/// Fragment to identify this managed object as a file. <br />
		/// </summary>
		///
		[JsonPropertyName("c8y_IsBinary")]
		public C8yIsBinary? PC8yIsBinary { get; set; }
	
		/// <summary> 
		/// Media type of the file. <br />
		/// </summary>
		///
		[JsonPropertyName("contentType")]
		public string? ContentType { get; set; }
	
		/// <summary> 
		/// Unique identifier of the object. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// Date and time of the file's last update. <br />
		/// </summary>
		///
		[JsonPropertyName("lastUpdated")]
		public System.DateTime? LastUpdated { get; set; }
	
		/// <summary> 
		/// Size of the file in bytes. <br />
		/// </summary>
		///
		[JsonPropertyName("length")]
		public int? Length { get; set; }
	
		/// <summary> 
		/// Name of the managed object. It is set from the <c>object</c> contained in the payload. <br />
		/// </summary>
		///
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary> 
		/// Username of the owner of the file. <br />
		/// </summary>
		///
		[JsonPropertyName("owner")]
		public string? Owner { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// Type of the managed object. It is set from the <c>object</c> contained in the payload. <br />
		/// </summary>
		///
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary> 
		/// Fragment to identify this managed object as a file. <br />
		/// </summary>
		///
		public class C8yIsBinary 
		{
		
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
