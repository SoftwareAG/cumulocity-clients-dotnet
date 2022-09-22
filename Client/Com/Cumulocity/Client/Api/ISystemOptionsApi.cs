///
/// ISystemOptionsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// API methods to retrieve the read-only properties predefined in the platform's configuration.
	/// </summary>
	#nullable enable
	public interface ISystemOptionsApi
	{
	
		/// <summary>
		/// Retrieve all system options<br/>
		/// Retrieve all the system options available on the tenant.
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the system options are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<SystemOptionCollection?> GetSystemOptions();
		
		/// <summary>
		/// Retrieve a specific system option<br/>
		/// Retrieve a specific system option (by a given category and key) on your tenant.
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the system option is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the system options.</param>
		/// <param name="key">The key of a system option.</param>
		/// <returns></returns>
		Task<SystemOption?> GetSystemOption(string category, string key);
	}
	#nullable disable
}
