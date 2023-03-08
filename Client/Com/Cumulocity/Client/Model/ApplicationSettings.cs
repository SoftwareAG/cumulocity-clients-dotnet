///
/// ApplicationSettings.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class ApplicationSettings 
	{
	
		/// <summary> 
		/// The name of the setting. <br />
		/// </summary>
		///
		[JsonPropertyName("key")]
		public string? Key { get; set; }
	
		/// <summary> 
		/// The value schema determines the values that the microservice can process. <br />
		/// </summary>
		///
		[JsonPropertyName("valueSchema")]
		public ValueSchema? PValueSchema { get; set; }
	
		/// <summary> 
		/// The default value. <br />
		/// </summary>
		///
		[JsonPropertyName("defaultValue")]
		public string? DefaultValue { get; set; }
	
		/// <summary> 
		/// Indicates if the value is editable. <br />
		/// </summary>
		///
		[JsonPropertyName("editable")]
		public bool? Editable { get; set; }
	
		/// <summary> 
		/// Indicated wether this setting is inherited. <br />
		/// </summary>
		///
		[JsonPropertyName("inheritFromOwner")]
		public bool? InheritFromOwner { get; set; }
	
		/// <summary> 
		/// The value schema determines the values that the microservice can process. <br />
		/// </summary>
		///
		public class ValueSchema 
		{
		
			/// <summary> 
			/// The value schema type. <br />
			/// </summary>
			///
			[JsonPropertyName("type")]
			public string? Type { get; set; }
		
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
