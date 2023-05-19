//
// NotificationSubscription.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class NotificationSubscription 
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
	public List<string> FragmentsToCopy { get; set; } = new List<string>();

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

	/// <summary> 
	/// Indicates whether the messages for this subscription are persistent or non-persistent, meaning they can be lost if consumer is not connected. <br />
	/// </summary>
	///
	[JsonPropertyName("nonPersistent")]
	public bool? NonPersistent { get; set; }

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
	public sealed class Source 
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
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	/// <summary> 
	/// Applicable filters to the subscription. <br />
	/// </summary>
	///
	public sealed class SubscriptionFilter 
	{
	
		/// <summary> 
		/// The Notifications are available for Alarms, Alarms with children, Device control, Events, Events with children, Inventory and Measurements for the <c>mo</c> context and for Alarms, Events and Inventory for the <c>tenant</c> context. Alternatively, the wildcard <c>*</c> can be used to match all the permissible APIs within the bound context. <br />
		/// ⓘ Info: The wildcard <c>*</c> cannot be used in conjunction with other values. <br />
		/// ⓘ Info: When filtering Events in the <c>tenant</c> context it is required to also specify the <c>typeFilter</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("apis")]
		public List<string> Apis { get; set; } = new List<string>();
	
		/// <summary> 
		/// Used to match the <c>type</c> property of the data. An OData expression must be provided. <br />
		/// ⓘ Info: The use of a <c>type</c> attribute is assumed, for example when using only a string literal <c>'c8y_Temperature'</c> it is equivalent to a <c>type eq 'c8y_Temperature'</c> OData expression. <br />
		/// ⓘ Info: Currently only the <c>or</c> operator is allowed in the expression mode. Example usage is <c>'c8y_Temperature' or 'c8y_Pressure'</c> which will match all the data with types <c>c8y_Temperature</c> or <c>c8y_Pressure</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("typeFilter")]
		public string? TypeFilter { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
