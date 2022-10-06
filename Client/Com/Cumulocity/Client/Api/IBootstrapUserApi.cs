///
/// IBootstrapUserApi.cs
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
	/// API methods to retrieve the bootstrap user of an application.
	/// </summary>
	#nullable enable
	public interface IBootstrapUserApi
	{
	
		/// <summary>
		/// Retrieve the bootstrap user for a specific application<br/>
		/// Retrieve the bootstrap user for a specific application (by a given ID).  This only works for microservice applications.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the bootstrap user of the application is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 400</term>
		/// <description>Bad request.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <returns></returns>
		Task<BootstrapUser?> GetBootstrapUser(string id) ;
	}
	#nullable disable
}
