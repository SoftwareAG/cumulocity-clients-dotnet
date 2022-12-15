///
/// RequestRepresentation.cs
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
	public class RequestRepresentation 
	{
	
		/// <summary>
		/// Body of the request.
		/// </summary>
		[JsonPropertyName("body")]
		public string? Body { get; set; }
	
		/// <summary>
		/// Headers of the request.
		/// </summary>
		[JsonPropertyName("headers")]
		public Headers? PHeaders { get; set; }
	
		/// <summary>
		/// HTTP request method.
		/// </summary>
		[JsonPropertyName("method")]
		public Method? PMethod { get; set; }
	
		/// <summary>
		/// Requested operation.
		/// </summary>
		[JsonPropertyName("operation")]
		public Operation? POperation { get; set; }
	
		/// <summary>
		/// Parameters of the request.
		/// </summary>
		[JsonPropertyName("requestParams")]
		public RequestParams? PRequestParams { get; set; }
	
		/// <summary>
		/// Target of the request described as a URL.
		/// </summary>
		[JsonPropertyName("url")]
		public string? Url { get; set; }
	
		/// <summary>
		/// HTTP request method.
		/// [GET, POST]
		/// </summary>
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Method 
		{
			[EnumMember(Value = "GET")]
			GET,
			[EnumMember(Value = "POST")]
			POST
		}
	
		/// <summary>
		/// Requested operation.
		/// [EXECUTE, REDIRECT]
		/// </summary>
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Operation 
		{
			[EnumMember(Value = "EXECUTE")]
			EXECUTE,
			[EnumMember(Value = "REDIRECT")]
			REDIRECT
		}
	
		/// <summary>
		/// Headers of the request.
		/// </summary>
		public class Headers 
		{
		
			/// <summary>
			/// It is possible to add an arbitrary number of headers as a list of key-value string pairs, for example, `"header": "value"`.
			/// 
			/// </summary>
			[JsonPropertyName("requestHeaders")]
			public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();
			
			[JsonIgnore]
			public string this[string key]
			{
				get => RequestHeaders[key];
				set => RequestHeaders[key] = value;
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
	
	
	
		/// <summary>
		/// Parameters of the request.
		/// </summary>
		public class RequestParams 
		{
		
			/// <summary>
			/// It is possible to add an arbitrary number of parameters as a list of key-value string pairs, for example, `"parameter": "value"`.
			/// 
			/// </summary>
			[JsonPropertyName("requestParameters")]
			public Dictionary<string, string> RequestParameters { get; set; } = new Dictionary<string, string>();
			
			[JsonIgnore]
			public string this[string key]
			{
				get => RequestParameters[key];
				set => RequestParameters[key] = value;
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
	}
}
