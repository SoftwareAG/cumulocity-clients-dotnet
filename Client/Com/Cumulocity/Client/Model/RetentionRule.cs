///
/// RetentionRule.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class RetentionRule 
	{
	
		/// <summary> 
		/// The data type(s) to which the rule is applied. <br />
		/// </summary>
		///
		[JsonPropertyName("dataType")]
		public DataType? PDataType { get; set; }
	
		/// <summary> 
		/// Indicates whether the rule is editable or not. It can be updated only by the Management tenant. <br />
		/// </summary>
		///
		[JsonPropertyName("editable")]
		public bool? Editable { get; set; }
	
		/// <summary> 
		/// The fragment type(s) to which the rule is applied. Used by the data types EVENT, MEASUREMENT, OPERATION and BULK_OPERATION. <br />
		/// </summary>
		///
		[JsonPropertyName("fragmentType")]
		public string? FragmentType { get; set; }
	
		/// <summary> 
		/// Unique identifier of the retention rule. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// Maximum age expressed in number of days. <br />
		/// </summary>
		///
		[JsonPropertyName("maximumAge")]
		public int? MaximumAge { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// The source(s) to which the rule is applied. Used by all data types. <br />
		/// </summary>
		///
		[JsonPropertyName("source")]
		public string? Source { get; set; }
	
		/// <summary> 
		/// The type(s) to which the rule is applied. Used by the data types ALARM, AUDIT, EVENT and MEASUREMENT. <br />
		/// </summary>
		///
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	
		/// <summary> 
		/// The data type(s) to which the rule is applied. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum DataType 
		{
			[EnumMember(Value = "ALARM")]
			ALARM,
			[EnumMember(Value = "AUDIT")]
			AUDIT,
			[EnumMember(Value = "BULK_OPERATION")]
			BULKOPERATION,
			[EnumMember(Value = "EVENT")]
			EVENT,
			[EnumMember(Value = "MEASUREMENT")]
			MEASUREMENT,
			[EnumMember(Value = "OPERATION")]
			OPERATION,
			[EnumMember(Value = "*")]
			ALL
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
