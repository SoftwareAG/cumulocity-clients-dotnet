//
// IExternalIDsApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// The external ID resource represents an individual external ID that can be queried and deleted. <br />
/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public interface IExternalIDsApi
{

	/// <summary> 
	/// Retrieve all external IDs of a specific managed object <br />
	/// Retrieve all external IDs of a existing managed object (identified by ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_IDENTITY_READ OR owner of the resource OR MANAGED_OBJECT_READ permission on the resource 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and all the external IDs are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the managed object. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<ExternalIds?> GetExternalIds(string id, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Create an external ID <br />
	/// Create an external ID for an existing managed object (identified by ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_IDENTITY_ADMIN OR owner of the resource OR MANAGED_OBJECT_ADMIN permission on the resource 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 An external ID was created. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Global ID not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 409 Duplicate – Identity already bound to a different Global ID. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="id">Unique identifier of the managed object. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<ExternalId?> CreateExternalId(ExternalId body, string id, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve a specific external ID <br />
	/// Retrieve a specific external ID of a particular type. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_IDENTITY_READ OR owner of the resource OR MANAGED_OBJECT_READ permission on the resource 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the external ID is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 External ID not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="type">The identifier used in the external system that Cumulocity IoT interfaces with. <br /></param>
	/// <param name="externalId">The type of the external identifier. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<ExternalId?> GetExternalId(string type, string externalId, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Remove a specific external ID <br />
	/// Remove a specific external ID of a particular type. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_IDENTITY_ADMIN OR owner of the resource OR MANAGED_OBJECT_ADMIN permission on the resource 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 An external ID was deleted. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 External ID not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="type">The identifier used in the external system that Cumulocity IoT interfaces with. <br /></param>
	/// <param name="externalId">The type of the external identifier. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> DeleteExternalId(string type, string externalId, CancellationToken cToken = default) ;
}
