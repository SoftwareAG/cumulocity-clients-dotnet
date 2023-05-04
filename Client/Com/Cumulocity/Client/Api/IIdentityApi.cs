///
/// IIdentityApi.cs
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
	/// Cumulocity IoT can associate devices and assets with multiple external identities.For instance, devices can often be identified by the IMEI of their modem, by a micro-controller serial number or by an asset tag.This is useful, for example, when you have non-functional hardware and must replace the hardware without losing the data that was recorded. <br />
	/// The identity API resource returns URIs and URI templates for associating external identifiers with unique identifiers. <br />
	/// </summary>
	///
	#nullable enable
	public interface IIdentityApi
	{
	
		/// <summary> 
		/// Retrieve URIs to collections of external IDs <br />
		/// Retrieve URIs and URI templates for associating external identifiers with unique identifiers. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_IDENTITY_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the URIs are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<IdentityApiResource?> GetIdentityApiResource(CancellationToken cToken = default) ;
	}
	#nullable disable
}
