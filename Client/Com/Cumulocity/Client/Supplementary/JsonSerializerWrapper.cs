//
// JsonSerializerWrapper.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Converter;

namespace Client.Com.Cumulocity.Client.Supplementary;

internal static class JsonSerializerWrapper
{
    public static readonly JsonSerializerOptions ToStringJsonSerializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
    	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

	public static string Serialize<T>(T value, JsonSerializerOptions? options = null)
	{
		return JsonSerializer.Serialize(value, options ?? JsonSerializerOptions);
	}

	public static void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}

	public static ValueTask<T?> DeserializeAsync<T>(Stream utf8Stream, CancellationToken cancellationToken = default)
	{
	    return utf8Stream.Length == 0 ? default : JsonSerializer.DeserializeAsync<T>(utf8Stream, JsonSerializerOptions, cancellationToken: cancellationToken);
	}

	public static T? Deserialize<T>(string jsonString, JsonSerializerOptions? options = null)
	{
		return JsonSerializer.Deserialize<T>(jsonString, options ?? JsonSerializerOptions);
	}
}
