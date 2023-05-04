///
/// UsageStatisticsApiTest.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Cumulocity.Client.Supplementary;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	#nullable enable
	[TestClass]
	public class UsageStatisticsApiTest
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
			UsageStatisticsApiTest.HttpClient = new HttpClient(httpClientHandler)
			{
				BaseAddress = new Uri(configuration.Hostname)
			};
		}
	
		[TestMethod]
		public async void TestGetTenantUsageStatisticsCollectionResource()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = await api.GetTenantUsageStatisticsCollectionResource();
			Debug.Assert(response != null);
		}
		
		[TestMethod]
		public async void TestGetTenantUsageStatistics()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = await api.GetTenantUsageStatistics();
			Debug.Assert(response != null);
		}
		
		[TestMethod]
		public async void TestGetTenantsUsageStatistics()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = await api.GetTenantsUsageStatistics<CustomProperties>();
			Debug.Assert(response != null);
		}
		
		[TestMethod]
		public async void TestGetMetadata()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = await api.GetMetadata();
			Debug.Assert(response != null);
		}
	}
	#nullable disable
}
