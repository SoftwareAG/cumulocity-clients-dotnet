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
	/// API methods to retrieve and update the current application and to retrieve its subscribers.It is the authenticated microservice user's application. <br />
	/// </summary>
	///
	#nullable enable
	public interface ICurrentApplicationApi
	{
	
		/// <summary> 
		/// Retrieve the current application <br />
		/// Retrieve the current application.This only works inside an application, for example, a microservice. <br />
		/// 
		/// <br /> Required roles <br />
		///  Microservice bootstrap user required. 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the current application sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		///
		Task<Application?> GetCurrentApplication() ;
		
		/// <summary> 
		/// Update the current application <br />
		/// Update the current application.This only works inside an application, for example, a microservice. This method is deprecated as it is only used by legacy microservices that are not running on Kubernetes. <br />
		/// 
		/// <br /> Required roles <br />
		///  Microservice bootstrap user required. 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The current application was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		///
		[Obsolete]
		Task<Application?> UpdateCurrentApplication(Application body) ;
		
		/// <summary> 
		/// Retrieve the current application settings <br />
		/// Retrieve the current application settings.This only works inside an application, for example, a microservice. <br />
		/// 
		/// <br /> Required roles <br />
		///  Microservice bootstrap user OR microservice service user required. 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the current application settings are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		///
		Task<List<ApplicationSettings>?> GetCurrentApplicationSettings() ;
		
		/// <summary> 
		/// Retrieve the subscribed users of the current application <br />
		/// Retrieve the subscribed users of the current application. <br />
		/// 
		/// <br /> Required roles <br />
		///  Microservice bootstrap user required. 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the list of subscribed users for the current application is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		///
		Task<ApplicationUserCollection?> GetSubscribedUsers() ;
	}
	#nullable disable
}
