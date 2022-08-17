///
/// TestConfiguration.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.IO;
using Microsoft.Extensions.Configuration;

namespace Com.Cumulocity.Client.Supplementary 
{
	public class TestConfiguration
	{
		public string Hostname { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
	
	public static class TestConfigurationExtensions
	{
	
		public static void Load(this TestConfiguration configuration)
		{
			var configurationRoot = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.test.json", false, false)
				.Build();
			var section = configurationRoot.GetSection("Configuration");
			section.Bind(configuration);
		}
	}
}
