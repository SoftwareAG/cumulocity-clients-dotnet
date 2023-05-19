//
// SubscribedUser.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class SubscribedUser 
{

	/// <summary> 
	/// An object with a user reference URL. <br />
	/// </summary>
	///
	[JsonPropertyName("user")]
	public User? PUser { get; set; }

	/// <summary> 
	/// An object with a user reference URL. <br />
	/// </summary>
	///
	public sealed class User 
	{
	
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

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
