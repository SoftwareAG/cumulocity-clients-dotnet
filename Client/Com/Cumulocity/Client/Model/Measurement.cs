///
/// Measurement.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	[JsonConverter(typeof(MeasurementJsonConverter<Measurement>))]
	public class Measurement 
	{
	
		/// <summary>
		/// Unique identifier of the measurement.
		/// </summary>
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// The managed object to which the measurement is associated.
		/// </summary>
		[JsonPropertyName("source")]
		public Source? PSource { get; set; }
	
		/// <summary>
		/// The date and time when the measurement is created.
		/// </summary>
		[JsonPropertyName("time")]
		public System.DateTime? Time { get; set; }
	
		/// <summary>
		/// Identifies the type of this measurement.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary>
		/// A type of measurement fragment.
		/// </summary>
		[JsonPropertyName("c8y_Steam")]
		public C8ySteam? PC8ySteam { get; set; }
	
		/// <summary>
		/// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, `"property1": {}`, `"property2": "value"`. These properties are known as custom fragments and can be of any type, for example, object or string. Each custom fragment is identified by a unique name.
		/// 
		/// Review the [Naming conventions of fragments](https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments) as there are characters that can not be used when naming custom fragments.
		/// 
		/// </summary>
		[JsonPropertyName("customFragments")]
		public Dictionary<string, object> CustomFragments { get; set; } = new Dictionary<string, object>();
		
		[JsonIgnore]
		public object this[string key]
		{
			get => CustomFragments[key];
			set => CustomFragments[key] = value;
		}
	
		public Measurement() 
		{
		}
	
		public Measurement(Source source, System.DateTime time, string type)
		{
			this.PSource = source;
			this.Time = time;
			this.Type = type;
		}
	
		/// <summary>
		/// The managed object to which the measurement is associated.
		/// </summary>
		public class Source 
		{
		
			/// <summary>
			/// Unique identifier of the object.
			/// </summary>
			[JsonPropertyName("id")]
			public string? Id { get; set; }
		
			/// <summary>
			/// A URL linking to this resource.
			/// </summary>
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			public Source() 
			{
			}
		
			public Source(string id)
			{
				this.Id = id;
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
	
		public override string ToString()
		{
			var jsonOptions = new JsonSerializerOptions() 
			{ 
				WriteIndented = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			};
			return JsonSerializer.Serialize(this, jsonOptions);
		}
	
		public class Serialization
		{
			public static readonly IDictionary<string, System.Type> AdditionalPropertyClasses = new Dictionary<string, System.Type>();
		
			public static void RegisterAdditionalProperty(string typeName, System.Type type)
			{
				AdditionalPropertyClasses[typeName] = type;
			}
		}
	}
}
