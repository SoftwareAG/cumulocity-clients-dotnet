//
// HttpRequestExceptionExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Net;
using System.Net.Http;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class HttpRequestExceptionExtensions
{
	private const string StatusCodeKeyName = "StatusCode";

	internal static void SetStatusCode(this HttpRequestException httpRequestException, HttpStatusCode httpStatusCode)
		=> httpRequestException.Data[StatusCodeKeyName] = httpStatusCode;

	public static HttpStatusCode? GetStatusCode(this HttpRequestException httpRequestException) 
		=> httpRequestException.Data.Contains(StatusCodeKeyName) && httpRequestException.Data[StatusCodeKeyName] is HttpStatusCode
			? (HttpStatusCode)httpRequestException.Data[StatusCodeKeyName]
			: null;
}
