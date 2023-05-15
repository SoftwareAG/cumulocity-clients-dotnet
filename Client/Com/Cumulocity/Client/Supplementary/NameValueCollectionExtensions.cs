//
// NameValueCollectionExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class NameValueCollectionExtensions
{
	public static string GetStringValue(this object input)
	{
		if (input is System.DateTime dateTime)
		{
			return dateTime.ToString("O");
		}
		return input.ToString() ?? string.Empty;
	}

	public static void TryAdd(this NameValueCollection collection, string key, object? value)
	{
		if (value != null)
		{
			collection.Add(key, value.GetStringValue());
		}
	}

	public static void TryAdd<T>(this NameValueCollection collection, string key, List<T>? value, bool explode = true)
	{
		if (value != null)
		{
			if (explode)
			{
				foreach (var item in value.Where(e => e != null))
				{
					collection.Add(key, item!.GetStringValue());
				}
			}
			else
			{
				collection.Add(key, string.Join(',', value.Where(static e => e != null)));
			}
		}
	}

	public static void TryAdd(this NameValueCollection collection, string key, object[]? value, bool explode = true)
	{
		if (value != null)
		{
			collection.TryAdd<object>(key, value.ToList(), explode);
		}
	}
}
