///
/// IRolesApi.cs
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
	/// API methods to create, retrieve, update and delete user roles. <br />
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IRolesApi
	{
	
		/// <summary> 
		/// Retrieve all user roles <br />
		/// Retrieve all user roles. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND has access to the user role 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all user roles are sent in the response. <br /> <br />
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
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<UserRoleCollection?> GetUserRoles(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a user role by name <br />
		/// Retrieve a user role by name. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND current user has access to the role with this name 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the user role is sent in the response. <br /> <br />
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
		/// <param name="name">The name of the user role. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Role?> GetUserRole(string name, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all roles assigned to a specific user group in a specific tenant <br />
		/// Retrieve all roles assigned to a specific user group (by a given user group ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request succeeded and the roles are sent in the response. <br /> <br />
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
		/// 		<description>HTTP 404 Group not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="groupId">Unique identifier of the user group. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<RoleReferenceCollection?> GetGroupRoles(string tenantId, int groupId, int? currentPage = null, int? pageSize = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a role to a specific user group in a specific tenant <br />
		/// Assign a role to a specific user group (by a given user group ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A user role was assigned to a user group. <br /> <br />
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
		/// 		<description>HTTP 404 Group not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 Conflict – Role already assigned to the user group. <br /> <br />
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
		/// <param name="groupId">Unique identifier of the user group. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<RoleReference?> AssignGroupRole(SubscribedRole body, string tenantId, int groupId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Unassign a specific role for a specific user group in a specific tenant <br />
		/// Unassign a specific role (given by a role ID) for a specific user group (by a given user group ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A role was unassigned from a user group. <br /> <br />
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
		/// <param name="groupId">Unique identifier of the user group. <br /></param>
		/// <param name="roleId">Unique identifier of the user role. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignGroupRole(string tenantId, int groupId, string roleId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a role to specific user in a specific tenant <br />
		/// Assign a role to a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// When a role is assigned to a user, a corresponding audit record is created with type "User" and activity "User updated". <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN to assign any role to root users in a user hierarchy OR users that are not in any hierarchy<br />
		///  ROLE_USER_MANAGEMENT_ADMIN to assign roles accessible by the parent of assigned user to non-root users in a user hierarchy<br />
		///  ROLE_USER_MANAGEMENT_CREATE to assign roles accessible by the current user AND accessible by the parent of the assigned user to the descendants of the current user in a user hierarchy 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A user role was assigned to a user. <br /> <br />
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
		Task<RoleReference?> AssignUserRole(SubscribedRole body, string tenantId, string userId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Unassign a specific role from a specific user in a specific tenant <br />
		/// Unassign a specific role (by a given role ID) from a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user AND has access to roles 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A user role was unassigned from a user. <br /> <br />
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
		/// 		<description>HTTP 404 User not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		/// <param name="roleId">Unique identifier of the user role. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignUserRole(string tenantId, string userId, string roleId, CancellationToken cToken = default) ;
	}
	#nullable disable
}
