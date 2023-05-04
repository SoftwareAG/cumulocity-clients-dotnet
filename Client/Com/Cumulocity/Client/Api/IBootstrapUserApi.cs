///
/// IBootstrapUserApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to retrieve the bootstrap user of an application. <br />
	/// </summary>
	///
	#nullable enable
	public interface IBootstrapUserApi
	{
	
		/// <summary> 
		/// Retrieve the bootstrap user for a specific application <br />
		/// Retrieve the bootstrap user for a specific application (by a given ID). <br />
		/// This only works for microservice applications. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the bootstrap user of the application is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 400 Bad request. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BootstrapUser?> GetBootstrapUser(string id, CancellationToken cToken = default) ;
	}
	#nullable disable
}
