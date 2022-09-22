///
/// IOperationsApi.cs
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
	/// API methods to create, retrieve, update and delete operations in Cumulocity IoT.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IOperationsApi
	{
	
		/// <summary>
		/// Retrieve a list of operations<br/>
		/// Retrieve a list of operations.  Notes about operation collections:  * The embedded operation object contains `deviceExternalIDs` only when queried with an `agentId` parameter. * The embedded operation object is filled with `deviceName`, but only when requesting resource: Get a collection of operations. * Operations are returned in the order of their ascending IDs.  <section><h5>Required roles</h5> ROLE_DEVICE_CONTROL_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the list of operations is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="agentId">An agent ID that may be part of the operation. If this parameter is set, the operation response objects contain the `deviceExternalIDs` object.</param>
		/// <param name="bulkOperationId">The bulk operation ID that this operation belongs to.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the operation.</param>
		/// <param name="dateTo">End date or date and time of the operation.</param>
		/// <param name="deviceId">The ID of the device the operation is performed for.</param>
		/// <param name="fragmentType">The type of fragment that must be part of the operation.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="revert">If you are using a range query (that is, at least one of the `dateFrom` or `dateTo` parameters is included in the request), then setting `revert=true` will sort the results by the newest operations first. By default, the results are sorted by the oldest operations first. </param>
		/// <param name="status">Status of the operation.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<OperationCollection?> GetOperations(string? agentId = null, string? bulkOperationId = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? fragmentType = null, int? pageSize = null, bool? revert = null, string? status = null, bool? withTotalElements = null, bool? withTotalPages = null);
		
		/// <summary>
		/// Create an operation<br/>
		/// Create an operation.  <section><h5>Required roles</h5> ROLE_DEVICE_CONTROL_ADMIN <b>OR</b> owner of the device <b>OR</b> ADMIN permissions on the device </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An operation was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		Task<Operation?> CreateOperation(Operation body);
		
		/// <summary>
		/// Delete a list of operations<br/>
		/// Delete a list of operations.  The DELETE method allows for deletion of operation collections.  <section><h5>Required roles</h5> ROLE_DEVICE_CONTROL_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A list of operations was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="agentId">An agent ID that may be part of the operation.</param>
		/// <param name="dateFrom">Start date or date and time of the operation.</param>
		/// <param name="dateTo">End date or date and time of the operation.</param>
		/// <param name="deviceId">The ID of the device the operation is performed for.</param>
		/// <param name="status">Status of the operation.</param>
		Task<System.IO.Stream> DeleteOperations(string? agentId = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? status = null);
		
		/// <summary>
		/// Retrieve a specific operation<br/>
		/// Retrieve a specific operation (by a given ID).  <section><h5>Required roles</h5> ROLE_DEVICE_CONTROL_READ <b>OR</b> owner of the resource <b>OR</b> ADMIN permission on the device </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the operation is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Operation not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the operation.</param>
		/// <returns></returns>
		Task<Operation?> GetOperation(string id);
		
		/// <summary>
		/// Update a specific operation status<br/>
		/// Update a specific operation (by a given ID). You can only update its status.  <section><h5>Required roles</h5> ROLE_DEVICE_CONTROL_ADMIN <b>OR</b> owner of the resource <b>OR</b> ADMIN permission on the device </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An operation was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Operation not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Validation error.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the operation.</param>
		/// <returns></returns>
		Task<Operation?> UpdateOperation(Operation body, string id);
	}
	#nullable disable
}
