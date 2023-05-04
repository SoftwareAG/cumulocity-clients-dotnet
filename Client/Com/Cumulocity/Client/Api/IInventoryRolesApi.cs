///
/// IInventoryRolesApi.cs
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
	/// API methods to create, retrieve, update and delete inventory roles. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IInventoryRolesApi
	{
	
		/// <summary> 
		/// Retrieve all inventory roles <br />
		/// Retrieve all inventory roles. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request succeeded and all inventory roles are sent in the response. <br /> <br />
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
		Task<InventoryRoleCollection?> GetInventoryRoles(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Create an inventory role <br />
		/// Create an inventory role. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 An inventory role was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 Duplicate – The inventory role already exists. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryRole?> CreateInventoryRole(InventoryRole body, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific inventory role <br />
		/// Retrieve a specific inventory role (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND has access to the inventory role 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request succeeded and the inventory role is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Role not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the inventory role. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryRole?> GetInventoryRole(int id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update a specific inventory role <br />
		/// Update a specific inventory role (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An inventory role was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Role not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the inventory role. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryRole?> UpdateInventoryRole(InventoryRole body, int id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Remove a specific inventory role <br />
		/// Remove a specific inventory role (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 An inventory role was removed. <br /> <br />
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
		/// 		<description>HTTP 404 Role not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the inventory role. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteInventoryRole(int id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all inventory roles assigned to a user <br />
		/// Retrieve all inventory roles assigned to a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND is the parent of the user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the inventory roles are sent in the response. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 User not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryAssignmentCollection?> GetUserInventoryRoles(string tenantId, string userId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign an inventory role to a user <br />
		/// Assign an existing inventory role to a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN to assign any inventory role to root users in a user hierarchy OR users that are not in any hierarchy<br />
		///  ROLE_USER_MANAGEMENT_ADMIN to assign inventory roles accessible by the parent of the assigned user to non-root users in a user hierarchy<br />
		///  ROLE_USER_MANAGEMENT_CREATE to assign inventory roles accessible by the current user AND accessible by the parent of the assigned user to the descendants of the current user in a user hierarchy 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An inventory role was assigned to a user. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 User not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryAssignment?> AssignUserInventoryRole(InventoryAssignment body, string tenantId, string userId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific inventory role assigned to a user <br />
		/// Retrieve a specific inventory role (by a given ID) assigned to a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND is the parent of the user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the inventory role is sent in the response. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 Role not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		/// <param name="id">Unique identifier of the inventory assignment. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryAssignment?> GetUserInventoryRole(string tenantId, string userId, int id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update a specific inventory role assigned to a user <br />
		/// Update a specific inventory role (by a given ID) assigned to a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN to update the assignment of any inventory roles to root users in a user hierarchy OR users that are not in any hierarchy<br />
		///  ROLE_USER_MANAGEMENT_ADMIN to update the assignment of inventory roles accessible by the assigned user parent, to non-root users in a user hierarchy<br />
		///  ROLE_USER_MANAGEMENT_CREATE to update the assignment of inventory roles accessible by the current user AND the parent of the assigned user to the descendants of the current user in the user hierarchy 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An inventory assignment was updated. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 Role not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		/// <param name="id">Unique identifier of the inventory assignment. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<InventoryAssignment?> UpdateUserInventoryRole(InventoryAssignmentReference body, string tenantId, string userId, int id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Remove a specific inventory role assigned to a user <br />
		/// Remove a specific inventory role (by a given ID) assigned to a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN AND (is not in user hierarchy OR is root in the user hierarchy) OR ROLE_USER_MANAGEMENT_ADMIN AND is in user hiararchy AND has parent access to inventory assignments OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user AND is not the current user AND has current user access to inventory assignments AND has parent access to inventory assignments 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 An inventory assignment was removed. <br /> <br />
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
		/// 		<description>HTTP 404 Role not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		/// <param name="id">Unique identifier of the inventory assignment. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignUserInventoryRole(string tenantId, string userId, int id, CancellationToken cToken = default) ;
	}
	#nullable disable
}
