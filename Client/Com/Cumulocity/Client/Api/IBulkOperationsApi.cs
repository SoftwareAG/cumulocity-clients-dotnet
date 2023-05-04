///
/// IBulkOperationsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// The bulk operations API allows to schedule an operation on a group of devices to be executed at a specified time.It is required to specify the delay between the creation of subsequent operations.When the bulk operation is created, it has the status ACTIVE.When all operations are created, the bulk operation has the status COMPLETED.It is also possible to cancel an already created bulk operation by deleting it. <br />
	/// When you create a bulk operation, you can run it in two modes: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>If <c>groupId</c> is passed, it works the standard way, that means, it takes devices from a group and schedules operations on them. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>If <c>failedParentId</c> is passed, it takes the already processed bulk operation by that ID, and schedules operations on devices for which the previous operations failed. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// Note that passing both <c>groupId</c> and <c>failedParentId</c> will not work, and a bulk operation works with groups of type <c>static</c> and <c>dynamic</c>. <br />
	/// ⓘ Info: The bulk operations API requires different roles than the rest of the device control API: <c>BULK_OPERATION_READ</c> and <c>BULK_OPERATION_ADMIN</c>. <br />
	/// The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IBulkOperationsApi
	{
	
		/// <summary> 
		/// Retrieve a list of bulk operations <br />
		/// Retrieve a list of bulk operations. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_BULK_OPERATION_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the list of bulk operations sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BulkOperationCollection?> GetBulkOperations(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Create a bulk operation <br />
		/// Create a bulk operation. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_BULK_OPERATION_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A bulk operation was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BulkOperation?> CreateBulkOperation(BulkOperation body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific bulk operation <br />
		/// Retrieve a specific bulk operation (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_BULK_OPERATION_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the bulk operation is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Bulk operation not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the bulk operation. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BulkOperation?> GetBulkOperation(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update a specific bulk operation <br />
		/// Update a specific bulk operation (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_BULK_OPERATION_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A bulk operation was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Bulk operation not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the bulk operation. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BulkOperation?> UpdateBulkOperation(BulkOperation body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Delete a specific bulk operation <br />
		/// Delete a specific bulk operation (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_BULK_OPERATION_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A bulk operation was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Bulk operation not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the bulk operation. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteBulkOperation(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	}
	#nullable disable
}
