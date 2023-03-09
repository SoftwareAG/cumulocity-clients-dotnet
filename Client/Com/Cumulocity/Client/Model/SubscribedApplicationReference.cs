///
/// SubscribedApplicationReference.cs
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
	public class SubscribedApplicationReference 
	{
	
		/// <summary> 
		/// The application to be subscribed to. <br />
		/// </summary>
		///
		[JsonPropertyName("application")]
		public Application? PApplication { get; set; }
	
		public SubscribedApplicationReference() 
		{
		}
	
		public SubscribedApplicationReference(Application application)
		{
			this.PApplication = application;
		}
	
		/// <summary> 
		/// The application to be subscribed to. <br />
		/// </summary>
		///
		public class Application 
		{
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
			public Application() 
			{
			}
		
			public Application(string self)
			{
				this.Self = self;
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
