//
// ObjectExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class ObjectExtensions
{
    public static JsonNode? ToJsonNode<T>(this T body)
    {
        return JsonSerializerWrapper.ToJsonNode(body);
    }
}
