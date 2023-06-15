//
// JSONPredicateRepresentation.cs
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

/// <summary> 
/// Represents a predicate for verification. It acts as a condition which is necessary to assign a user to the given groups, permit access to the specified applications or to assign specific inventory roles to device groups. <br />
/// </summary>
///
public sealed class JSONPredicateRepresentation 
{

	/// <summary> 
	/// Nested predicates. <br />
	/// </summary>
	///
	[JsonPropertyName("childPredicates")]
	public List<JSONPredicateRepresentation> ChildPredicates { get; set; } = new List<JSONPredicateRepresentation>();

	/// <summary> 
	/// Operator executed on the parameter from the JWT access token claim pointed by <c>parameterPath</c> and the provided parameter <c>value</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("operator")]
	public Operator? POperator { get; set; }

	/// <summary> 
	/// Path to the claim from the JWT access token from the external authorization server. <br />
	/// </summary>
	///
	[JsonPropertyName("parameterPath")]
	public string? ParameterPath { get; set; }

	/// <summary> 
	/// Given value used for parameter verification. <br />
	/// </summary>
	///
	[JsonPropertyName("value")]
	public string? Value { get; set; }

	/// <summary> 
	/// Operator executed on the parameter from the JWT access token claim pointed by <c>parameterPath</c> and the provided parameter <c>value</c>. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Operator 
	{
		[EnumMember(Value = "EQ")]
		EQ,
		[EnumMember(Value = "NEQ")]
		NEQ,
		[EnumMember(Value = "GT")]
		GT,
		[EnumMember(Value = "LT")]
		LT,
		[EnumMember(Value = "GTE")]
		GTE,
		[EnumMember(Value = "LTE")]
		LTE,
		[EnumMember(Value = "IN")]
		IN,
		[EnumMember(Value = "AND")]
		AND,
		[EnumMember(Value = "OR")]
		OR
	}


	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
