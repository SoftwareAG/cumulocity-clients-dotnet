///
/// NotificationSubscription.cs
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
	public class NotificationSubscription 
	{
	
		/// <summary> 
		/// The context within which the subscription is to be processed. <br />
		/// ⓘ Info: If the value is <c>mo</c>, then <c>source</c> must also be provided in the request body. <br />
		/// </summary>
		///
		[JsonPropertyName("context")]
		public Context? PContext { get; set; }
	
		/// <summary> 
		/// Transforms the data to only include specified custom fragments. Each custom fragment is identified by a unique name. If nothing is specified here, the data is forwarded as-is. <br />
		/// </summary>
		///
		[JsonPropertyName("fragmentsToCopy")]
		public List<string>? FragmentsToCopy { get; set; }
	
		/// <summary> 
		/// Unique identifier of the subscription. <br />
		/// </summary>
		///
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary> 
		/// The managed object to which the subscription is associated. <br />
		/// </summary>
		///
		[JsonPropertyName("source")]
		public Source? PSource { get; set; }
	
		/// <summary> 
		/// The subscription name. Each subscription is identified by a unique name within a specific context. <br />
		/// </summary>
		///
		[JsonPropertyName("subscription")]
		public string? Subscription { get; set; }
	
		/// <summary> 
		/// Applicable filters to the subscription. <br />
		/// </summary>
		///
		[JsonPropertyName("subscriptionFilter")]
		public SubscriptionFilter? PSubscriptionFilter { get; set; }
	
		public NotificationSubscription() 
		{
		}
	
		public NotificationSubscription(Context context, string subscription)
		{
			this.PContext = context;
			this.Subscription = subscription;
		}
	
		/// <summary> 
		/// The context within which the subscription is to be processed. <br />
		/// ⓘ Info: If the value is <c>mo</c>, then <c>source</c> must also be provided in the request body. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Context 
		{
			[EnumMember(Value = "mo")]
			MO,
			[EnumMember(Value = "tenant")]
			TENANT
		}
	
	
		/// <summary> 
		/// The managed object to which the subscription is associated. <br />
		/// </summary>
		///
		public class Source 
		{
		
			/// <summary> 
			/// Unique identifier of the object. <br />
			/// </summary>
			///
			[JsonPropertyName("id")]
			public string? Id { get; set; }
		
			/// <summary> 
			/// Human-readable name that is used for representing the object in user interfaces. <br />
			/// </summary>
			///
			[JsonPropertyName("name")]
			public string? Name { get; set; }
		
			/// <summary> 
			/// A URL linking to this resource. <br />
			/// </summary>
			///
			[JsonPropertyName("self")]
			public string? Self { get; set; }
		
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
		/// Applicable filters to the subscription. <br />
		/// </summary>
		///
		public class SubscriptionFilter 
		{
		
			/// <summary> 
			/// The Notifications are available for Alarms, Alarms with children, Device control, Events, Events with children, Inventory and Measurements for the <c>mo</c> context and for Alarms and Inventory for the <c>tenant</c> context. Alternatively, the wildcard <c>*</c> can be used to match all the permissible APIs within the bound context. <br />
			/// ⓘ Info: the wildcard <c>*</c> cannot be used in conjunction with other values. <br />
			/// </summary>
			///
			[JsonPropertyName("apis")]
			public List<string>? Apis { get; set; }
		
			/// <summary> 
			/// The data needs to have the specified value in its <c>type</c> property to meet the filter criteria. <br />
			/// </summary>
			///
			[JsonPropertyName("typeFilter")]
			public string? TypeFilter { get; set; }
		
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
