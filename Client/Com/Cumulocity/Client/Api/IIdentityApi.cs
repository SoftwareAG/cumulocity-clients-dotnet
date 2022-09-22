///
/// IIdentityApi.cs
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
	/// Cumulocity IoT can associate devices and assets with multiple external identities.
	/// For instance, devices can often be identified by the IMEI of their modem, by a micro-controller serial number or by an asset tag.
	/// This is useful, for example, when you have non-functional hardware and must replace the hardware without losing the data that was recorded.
	/// 
	/// The identity API resource returns URIs and URI templates for associating external identifiers with unique identifiers.
	/// 
	/// </summary>
	#nullable enable
	public interface IIdentityApi
	{
	
		/// <summary>
		/// Retrieve URIs to collections of external IDs<br/>
		/// Retrieve URIs and URI templates for associating external identifiers with unique identifiers.  <section><h5>Required roles</h5> ROLE_IDENTITY_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the URIs are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<IdentityApiResource?> GetIdentityApiResource();
	}
	#nullable disable
}
