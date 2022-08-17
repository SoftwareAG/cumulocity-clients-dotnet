///
/// NotificationTokenClaims.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class NotificationTokenClaims 
	{
	
		/// <summary>
		/// The token expiration duration.
		/// </summary>
		[JsonPropertyName("expiresInMinutes")]
		public int? ExpiresInMinutes { get; set; }
	
		/// <summary>
		/// The subscriber name which the client wishes to be identified with.
		/// </summary>
		[JsonPropertyName("subscriber")]
		public string? Subscriber { get; set; }
	
		/// <summary>
		/// The subscription name. This value must match the same that was used when the subscription was created.
		/// </summary>
		[JsonPropertyName("subscription")]
		public string? Subscription { get; set; }
	
		public NotificationTokenClaims() 
		{
		}
	
		public NotificationTokenClaims(string subscriber, string subscription)
		{
			this.Subscriber = subscriber;
			this.Subscription = subscription;
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
