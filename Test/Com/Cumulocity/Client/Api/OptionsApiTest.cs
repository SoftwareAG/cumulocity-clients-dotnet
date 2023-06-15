//
// OptionsApiTest.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client.Com.Cumulocity.Client.Api;
using Client.Com.Cumulocity.Client.Model;
using Test.Com.Cumulocity.Client.Supplementary;

namespace Test.Com.Cumulocity.Client.Api;

[TestClass]
public sealed class OptionsApiTest
{

	private static HttpClient? HttpClient { get; set; }

	[ClassInitialize]
	public static void SetupHttpClient(TestContext context)
	{
		var configuration = new TestConfiguration();
		configuration.Load();

		var httpClientHandler = new HttpClientHandler()
		{
			Credentials = new NetworkCredential(configuration.Username, configuration.Password)
		};
		OptionsApiTest.HttpClient = new HttpClient(httpClientHandler)
		{
			BaseAddress = new Uri(configuration.Hostname)
		};
	}

	[TestMethod]
	public async void TestGetOptions()
	{
		var api = new OptionsApi(HttpClient!);
		var response = await api.GetOptions();
		Debug.Assert(response != null);
	}
}
