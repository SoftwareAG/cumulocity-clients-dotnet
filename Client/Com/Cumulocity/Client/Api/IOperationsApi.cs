///
/// IOperationsApi.cs
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
	/// API methods to create, retrieve, update and delete operations in Cumulocity IoT. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IOperationsApi
	{
	
		/// <summary> 
		/// Retrieve a list of operations <br />
		/// Retrieve a list of operations. <br />
		/// Notes about operation collections: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>The embedded operation object contains <c>deviceExternalIDs</c> only when queried with an <c>agentId</c> parameter. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>The embedded operation object is filled with <c>deviceName</c>, but only when requesting resource: Get a collection of operations. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Operations are returned in the order of their ascending IDs. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_CONTROL_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the list of operations is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="agentId">An agent ID that may be part of the operation. If this parameter is set, the operation response objects contain the <c>deviceExternalIDs</c> object. <br /></param>
		/// <param name="bulkOperationId">The bulk operation ID that this operation belongs to. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="dateFrom">Start date or date and time of the operation. <br /></param>
		/// <param name="dateTo">End date or date and time of the operation. <br /></param>
		/// <param name="deviceId">The ID of the device the operation is performed for. <br /></param>
		/// <param name="fragmentType">The type of fragment that must be part of the operation. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="revert">If you are using a range query (that is, at least one of the <c>dateFrom</c> or <c>dateTo</c> parameters is included in the request), then setting <c>revert=true</c> will sort the results by the newest operations first.By default, the results are sorted by the oldest operations first. <br /></param>
		/// <param name="status">Status of the operation. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<OperationCollection<TOperation>?> GetOperations<TOperation>(string? agentId = null, string? bulkOperationId = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? fragmentType = null, int? pageSize = null, bool? revert = null, string? status = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TOperation : Operation;
		
		/// <summary> 
		/// Create an operation <br />
		/// Create an operation. <br />
		/// It is possible to add custom fragments to operations, for example <c>com_cumulocity_model_WebCamDevice</c> is a custom object of the webcam operation. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_CONTROL_ADMIN OR owner of the device OR ADMIN permissions on the device 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 An operation was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TOperation?> CreateOperation<TOperation>(TOperation body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TOperation : Operation;
		
		/// <summary> 
		/// Delete a list of operations <br />
		/// Delete a list of operations. <br />
		/// The DELETE method allows for deletion of operation collections. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_CONTROL_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A list of operations was removed. <br /> <br />
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
		/// </list>
		/// </summary>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="agentId">An agent ID that may be part of the operation. <br /></param>
		/// <param name="dateFrom">Start date or date and time of the operation. <br /></param>
		/// <param name="dateTo">End date or date and time of the operation. <br /></param>
		/// <param name="deviceId">The ID of the device the operation is performed for. <br /></param>
		/// <param name="status">Status of the operation. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteOperations(string? xCumulocityProcessingMode = null, string? agentId = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? deviceId = null, string? status = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific operation <br />
		/// Retrieve a specific operation (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_CONTROL_READ OR owner of the resource OR ADMIN permission on the device 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the operation is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Operation not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the operation. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TOperation?> GetOperation<TOperation>(string id, CancellationToken cToken = default) where TOperation : Operation;
		
		/// <summary> 
		/// Update a specific operation status <br />
		/// Update a specific operation (by a given ID).You can only update its status. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_CONTROL_ADMIN OR owner of the resource OR ADMIN permission on the device 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An operation was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Operation not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Validation error. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the operation. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TOperation?> UpdateOperation<TOperation>(TOperation body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TOperation : Operation;
	}
	#nullable disable
}
