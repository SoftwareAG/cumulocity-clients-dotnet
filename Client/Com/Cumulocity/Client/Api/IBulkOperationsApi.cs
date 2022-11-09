///
/// IBulkOperationsApi.cs
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
	/// The bulk operations API allows to schedule an operation on a group of devices to be executed at a specified time.
	/// It is required to specify the delay between the creation of subsequent operations.
	/// When the bulk operation is created, it has the status ACTIVE.
	/// When all operations are created, the bulk operation has the status COMPLETED.
	/// It is also possible to cancel an already created bulk operation by deleting it.
	/// 
	/// When you create a bulk operation, you can run it in two modes:
	/// 
	/// * If `groupId` is passed, it works the standard way, that means, it takes devices from a group and schedules operations on them.
	/// * If `failedParentId` is passed, it takes the already processed bulk operation by that ID, and schedules operations on devices for which the previous operations failed.
	/// 
	/// Note that passing both `groupId` and `failedParentId` will not work, and a bulk operation works with groups of type `static` and `dynamic`.
	/// 
	/// > **&#9432; Info:** The bulk operations API requires different roles than the rest of the device control API: `BULK_OPERATION_READ` and `BULK_OPERATION_ADMIN`.
	/// >
	/// > The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IBulkOperationsApi
	{
	
		/// <summary>
		/// Retrieve a list of bulk operations<br/>
		/// Retrieve a list of bulk operations.  <section><h5>Required roles</h5> ROLE_BULK_OPERATION_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the list of bulk operations sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<BulkOperationCollection?> GetBulkOperations(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null) ;
		
		/// <summary>
		/// Create a bulk operation<br/>
		/// Create a bulk operation.  <section><h5>Required roles</h5> ROLE_BULK_OPERATION_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>A bulk operation was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		Task<BulkOperation?> CreateBulkOperation(BulkOperation body) ;
		
		/// <summary>
		/// Retrieve a specific bulk operation<br/>
		/// Retrieve a specific bulk operation (by a given ID).  <section><h5>Required roles</h5> ROLE_BULK_OPERATION_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the bulk operation is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Bulk operation not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the bulk operation.</param>
		/// <returns></returns>
		Task<BulkOperation?> GetBulkOperation(string id) ;
		
		/// <summary>
		/// Update a specific bulk operation<br/>
		/// Update a specific bulk operation (by a given ID).  <section><h5>Required roles</h5> ROLE_BULK_OPERATION_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>A bulk operation was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Bulk operation not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the bulk operation.</param>
		/// <returns></returns>
		Task<BulkOperation?> UpdateBulkOperation(BulkOperation body, string id) ;
		
		/// <summary>
		/// Delete a specific bulk operation<br/>
		/// Delete a specific bulk operation (by a given ID).  <section><h5>Required roles</h5> ROLE_BULK_OPERATION_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A bulk operation was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Bulk operation not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the bulk operation.</param>
		Task<System.IO.Stream> DeleteBulkOperation(string id) ;
	}
	#nullable disable
}
