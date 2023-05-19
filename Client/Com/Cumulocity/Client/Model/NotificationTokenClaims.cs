//
// NotificationTokenClaims.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class NotificationTokenClaims 
{

	/// <summary> 
	/// The token expiration duration. <br />
	/// </summary>
	///
	[JsonPropertyName("expiresInMinutes")]
	public int? ExpiresInMinutes { get; set; }

	/// <summary> 
	/// The subscriber name which the client wishes to be identified with. <br />
	/// </summary>
	///
	[JsonPropertyName("subscriber")]
	public string? Subscriber { get; set; }

	/// <summary> 
	/// The subscription name. This value must match the same that was used when the subscription was created. <br />
	/// </summary>
	///
	[JsonPropertyName("subscription")]
	public string? Subscription { get; set; }

	/// <summary> 
	/// The subscription type. Currently the only supported type is <c>notification</c> .Other types may be added in future. <br />
	/// </summary>
	///
	[JsonPropertyName("type")]
	public Type? PType { get; set; }

	/// <summary> 
	/// If <c>true</c>, the token will be securely signed by the Cumulocity IoT platform. <br />
	/// </summary>
	///
	[JsonPropertyName("signed")]
	public bool? Signed { get; set; }

	/// <summary> 
	/// If <c>true</c>, indicates that the token is used to create a shared consumer on the subscription. <br />
	/// </summary>
	///
	[JsonPropertyName("shared")]
	public bool? Shared { get; set; }

	/// <summary> 
	/// If <c>true</c>, indicates that the created token refers to the non-persistent variant of the named subscription. <br />
	/// </summary>
	///
	[JsonPropertyName("nonPersistent")]
	public bool? NonPersistent { get; set; }

	public NotificationTokenClaims() 
	{
	}

	public NotificationTokenClaims(string subscriber, string subscription)
	{
		this.Subscriber = subscriber;
		this.Subscription = subscription;
	}

	/// <summary> 
	/// The subscription type. Currently the only supported type is <c>notification</c> .Other types may be added in future. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Type 
	{
		[EnumMember(Value = "notification")]
		NOTIFICATION
	}


	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
