//
// JsonNodeExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class JsonNodeExtensions
{
	public static void RemoveFromNode(this JsonNode node, params string[] pathItem)
	{
		if (pathItem.Length > 0)
		{
			var currentNode = node;
			string nodeName = pathItem[0];
			int index = 0;
			while (index < (pathItem.Length - 1))
			{
				currentNode = node[nodeName];
				index++;
				nodeName = pathItem[index];
			}
			if (currentNode?.GetType() == typeof(JsonObject))
			{
				var objectNode = (JsonObject) currentNode;
				objectNode.Remove(nodeName);
			}
		}
	}
}
