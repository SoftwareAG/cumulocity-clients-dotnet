///
/// UsageStatisticsApiTest.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Cumulocity.Client.Supplementary;

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
		public void TestGetTenantUsageStatisticsCollectionResource()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = api.GetTenantUsageStatisticsCollectionResource();
			Debug.Assert(response != null);
		}
		
		[TestMethod]
		public void TestGetTenantUsageStatistics()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = api.GetTenantUsageStatistics();
			Debug.Assert(response != null);
		}
		
		[TestMethod]
		public void TestGetTenantsUsageStatistics()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = api.GetTenantsUsageStatistics();
			Debug.Assert(response != null);
		}
		
		[TestMethod]
		public void TestGetMetadata()
		{
			var api = new UsageStatisticsApi(HttpClient!);
			var response = api.GetMetadata();
			Debug.Assert(response != null);
		}
	}
	#nullable disable
}
