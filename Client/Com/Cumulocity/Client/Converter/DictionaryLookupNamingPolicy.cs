//
// DictionaryLookupNamingPolicy.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;

namespace Client.Com.Cumulocity.Client.Converter;

internal sealed class DictionaryLookupNamingPolicy : JsonNamingPolicy
{
    private readonly Dictionary<string, string> _literalNames;

    public DictionaryLookupNamingPolicy(Dictionary<string, string> literalNames) => _literalNames = literalNames;

    public override string ConvertName(string name)
    {
        return _literalNames.TryGetValue(name, out var value) ? value : name;
    }
}
