///
/// IExternalIDsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// The external ID resource represents an individual external ID that can be queried and deleted.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IExternalIDsApi
	{
	
		/// <summary>
		/// Retrieve all external IDs of a specific managed object<br/>
		/// Retrieve all external IDs of a existing managed object (identified by ID).  <section><h5>Required roles</h5> ROLE_IDENTITY_READ <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_READ permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all the external IDs are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		Task<ExternalIds?> GetExternalIds(string id) ;
		
		/// <summary>
		/// Create an external ID<br/>
		/// Create an external ID for an existing managed object (identified by ID).  <section><h5>Required roles</h5> ROLE_IDENTITY_ADMIN <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_ADMIN permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An external ID was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate – Identity already bound to a different Global ID.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<ExternalId?> CreateExternalId(ExternalId body, string id, string? xCumulocityProcessingMode = null) ;
		
		/// <summary>
		/// Retrieve a specific external ID<br/>
		/// Retrieve a specific external ID of a particular type.  <section><h5>Required roles</h5> ROLE_IDENTITY_READ <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_READ permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the external ID is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>External ID not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="type">The identifier used in the external system that Cumulocity IoT interfaces with.</param>
		/// <param name="externalId">The type of the external identifier.</param>
		/// <returns></returns>
		Task<ExternalId?> GetExternalId(string type, string externalId) ;
		
		/// <summary>
		/// Remove a specific external ID<br/>
		/// Remove a specific external ID of a particular type.  <section><h5>Required roles</h5> ROLE_IDENTITY_ADMIN <b>OR</b> owner of the resource <b>OR</b> MANAGED_OBJECT_ADMIN permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>An external ID was deleted.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>External ID not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="type">The identifier used in the external system that Cumulocity IoT interfaces with.</param>
		/// <param name="externalId">The type of the external identifier.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> DeleteExternalId(string type, string externalId, string? xCumulocityProcessingMode = null) ;
	}
	#nullable disable
}
