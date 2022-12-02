///
/// ICurrentApplicationApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// API methods to retrieve and update the current application and to retrieve its subscribers.
	/// It is the authenticated microservice user's application.
	/// 
	/// </summary>
	#nullable enable
	public interface ICurrentApplicationApi
	{
	
		/// <summary>
		/// Retrieve the current application<br/>
		/// Retrieve the current application. This only works inside an application, for example, a microservice.  <section><h5>Required roles</h5> Microservice bootstrap user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the current application sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not enough permissions/roles to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<Application?> GetCurrentApplication() ;
		
		/// <summary>
		/// Update the current application<br/>
		/// Update the current application. This only works inside an application, for example, a microservice. This method is deprecated as it is only used by legacy microservices that are not running on Kubernetes.  <section><h5>Required roles</h5> Microservice bootstrap user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The current application was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not enough permissions/roles to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		[Obsolete]
		Task<Application?> UpdateCurrentApplication(Application body, string? xCumulocityProcessingMode = null) ;
		
		/// <summary>
		/// Retrieve the current application settings<br/>
		/// Retrieve the current application settings. This only works inside an application, for example, a microservice.  <section><h5>Required roles</h5> Microservice bootstrap user <b>OR</b> microservice service user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the current application settings are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not enough permissions/roles to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<List<ApplicationSettings>?> GetCurrentApplicationSettings() ;
		
		/// <summary>
		/// Retrieve the subscribed users of the current application<br/>
		/// Retrieve the subscribed users of the current application.  <section><h5>Required roles</h5> Microservice bootstrap user required. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the list of subscribed users for the current application is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<ApplicationUserCollection?> GetSubscribedUsers() ;
	}
	#nullable disable
}
