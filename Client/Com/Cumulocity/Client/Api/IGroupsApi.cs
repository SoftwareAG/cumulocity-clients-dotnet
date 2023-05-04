///
/// IGroupsApi.cs
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
	/// API methods to create, retrieve, update and delete user groups. <br />
	/// ⚠️ Important: In the Cumulocity IoT user interface, user groups are referred to as "global roles". Global roles are not to be confused with user roles. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IGroupsApi
	{
	
		/// <summary> 
		/// Retrieve all user groups of a specific tenant <br />
		/// Retrieve all user groups of a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all user groups are sent in the response. <br /> <br />
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
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<UserGroupCollection<TCustomProperties>?> GetTenantUserGroups<TCustomProperties>(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Create a user group for a specific tenant <br />
		/// Create a user group for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A user group was created. <br /> <br />
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
		/// 		<description>HTTP 409 Duplicate – Group name already exists. <br /> <br />
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
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Group<TCustomProperties>?> CreateUserGroup<TCustomProperties>(Group<TCustomProperties> body, string tenantId, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Retrieve a specific user group for a specific tenant <br />
		/// Retrieve a specific user group (by a given user group ID) for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user AND is not the current user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request succeeded and the user group is sent in the response. <br /> <br />
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
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Group<TCustomProperties>?> GetUserGroup<TCustomProperties>(string tenantId, int groupId, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Update a specific user group for a specific tenant <br />
		/// Update a specific user group (by a given user group ID) for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A user group was updated. <br /> <br />
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
		Task<Group<TCustomProperties>?> UpdateUserGroup<TCustomProperties>(Group<TCustomProperties> body, string tenantId, int groupId, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Delete a specific user group for a specific tenant <br />
		/// Delete a specific user group (by a given user group ID) for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A user group was removed. <br /> <br />
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
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="groupId">Unique identifier of the user group. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteUserGroup(string tenantId, int groupId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a user group by group name for a specific tenant <br />
		/// Retrieve a user group by group name for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND has access to groups 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request succeeded and the user group is sent in the response. <br /> <br />
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
		/// <param name="groupName">The name of the user group. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Group<TCustomProperties>?> GetUserGroupByName<TCustomProperties>(string tenantId, string groupName, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Get all user groups for specific user in a specific tenant <br />
		/// Get all user groups for a specific user (by a given user ID) in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request succeeded and all groups for the user are sent in the response. <br /> <br />
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
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<GroupReferenceCollection<TCustomProperties>?> GetUserGroups<TCustomProperties>(string tenantId, string userId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
	}
	#nullable disable
}
