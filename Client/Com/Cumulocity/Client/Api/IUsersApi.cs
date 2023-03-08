///
/// IUsersApi.cs
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
	/// API methods to create, retrieve, update and delete users in Cumulocity IoT. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IUsersApi
	{
	
		/// <summary> 
		/// Retrieve all users for a specific tenant <br />
		/// Retrieve all users for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all users are sent in the response. <br /> <br />
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
		/// <param name="groups">Numeric group identifiers. The response will contain only users which belong to at least one of the specified groups. <br />ⓘ Info: If you query for multiple user groups at once, comma-separate the values. <br /></param>
		/// <param name="onlyDevices">If set to <c>true</c>, the response will only contain users created during bootstrap process (starting with “device_”).If the flag is absent or <c>false</c> the result will not contain “device_” users. <br /></param>
		/// <param name="owner">Exact username of the owner of the user <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="username">Prefix or full username <br /></param>
		/// <param name="withSubusersCount">If set to <c>true</c>, then each of returned user will contain an additional field “subusersCount”.It is the number of direct subusers (users with corresponding “owner”). <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		///
		Task<UserCollection<TCustomProperties>?> GetUsers<TCustomProperties>(string tenantId, int? currentPage = null, List<string>? groups = null, bool? onlyDevices = null, string? owner = null, int? pageSize = null, string? username = null, bool? withSubusersCount = null, bool? withTotalElements = null, bool? withTotalPages = null) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Create a user for a specific tenant <br />
		/// Create a user for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN OR ROLE_USER_MANAGEMENT_CREATE AND has access to roles, groups, device permissions and applications 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A user was created. <br /> <br />
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
		/// 		<description>HTTP 409 Duplicate – The userName or alias already exists. <br /> <br />
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
		///
		Task<User<TCustomProperties>?> CreateUser<TCustomProperties>(User<TCustomProperties> body, string tenantId) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Retrieve a specific user for a specific tenant <br />
		/// Retrieve a specific user (by a given user ID) for a specific tenant (by a given tenant ID). <br />
		/// Users in the response are sorted by username in ascending order.Only objects which the user is allowed to see are returned to the user.The user password is never returned in a GET response. Authentication mechanism is provided by another interface. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the user is sent in the response. <br /> <br />
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
		///
		Task<User<TCustomProperties>?> GetUser<TCustomProperties>(string tenantId, string userId) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Update a specific user for a specific tenant <br />
		/// Update a specific user (by a given user ID) for a specific tenant (by a given tenant ID). <br />
		/// Any change in user's roles, device permissions and groups creates corresponding audit records with type "User" and activity "User updated" with information which properties have been changed. <br />
		/// When the user is updated with changed permissions or groups, a corresponding audit record is created with type "User" and activity "User updated". <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN to update root users in a user hierarchy OR users that are not in any hierarchy<br />
		///  ROLE_USER_MANAGEMENT_ADMIN to update non-root users in a user hierarchy AND whose parents have access to roles, groups, device permissions and applications being assigned<br />
		///  ROLE_USER_MANAGEMENT_CREATE to update descendants of the current user in a user hierarchy AND whose parents have access to roles, groups, device permissions and applications being assigned 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A user was updated. <br /> <br />
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
		///
		Task<User<TCustomProperties>?> UpdateUser<TCustomProperties>(User<TCustomProperties> body, string tenantId, string userId) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Delete a specific user for a specific tenant <br />
		/// Delete a specific user (by a given user ID) for a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user AND not the current user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A user was removed. <br /> <br />
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
		///
		Task<System.IO.Stream> DeleteUser(string tenantId, string userId) ;
		
		/// <summary> 
		/// Update a specific user's password of a specific tenant <br />
		/// Update a specific user's password (by a given user ID) of a specific tenant (by a given tenant ID). <br />
		/// Changing the user's password creates a corresponding audit record of type "User" and activity "User updated", and specifying that the password has been changed. <br />
		/// ⚠️ Important: If the tenant uses OAI-Secure authentication, the target user will be logged out. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN to update root users in a user hierarchy OR users that are not in any hierarchy<br />
		///  ROLE_USER_MANAGEMENT_ADMIN to update non-root users in a user hierarchy AND whose parents have access to assigned roles, groups, device permissions and applications<br />
		///  ROLE_USER_MANAGEMENT_CREATE to update descendants of the current user in a user hierarchy AND whose parents have access to assigned roles, groups, device permissions and applications 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A user was updated. <br /> <br />
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
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		///
		Task<System.IO.Stream> UpdateUserPassword(PasswordChange body, string tenantId, string userId) ;
		
		/// <summary> 
		/// Retrieve the TFA settings of a specific user <br />
		/// Retrieve the two-factor authentication settings for the specified user. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR (ROLE_USER_MANAGEMENT_CREATE AND is parent of the user) OR is the current user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the TFA settings are sent in the response. <br /> <br />
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
		///
		Task<UserTfaData?> GetUserTfaSettings(string tenantId, string userId) ;
		
		/// <summary> 
		/// Retrieve a user by username in a specific tenant <br />
		/// Retrieve a user by username in a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the user is sent in the response. <br /> <br />
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
		/// <param name="username">The username of the a user. <br /></param>
		///
		Task<User<TCustomProperties>?> GetUserByUsername<TCustomProperties>(string tenantId, string username) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Retrieve the users of a specific user group of a specific tenant <br />
		/// Retrieve the users of a specific user group (by a given user group ID) of a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR (ROLE_USER_MANAGEMENT_CREATE AND has access to the user group) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the users are sent in the response. <br /> <br />
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
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		///
		Task<UserReferenceCollection<TCustomProperties>?> GetUsersFromUserGroup<TCustomProperties>(string tenantId, int groupId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Add a user to a specific user group of a specific tenant <br />
		/// Add a user to a specific user group (by a given user group ID) of a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN to assign root users in a user hierarchy OR users that are not in any hierarchy to any group<br />
		///  ROLE_USER_MANAGEMENT_ADMIN to assign non-root users in a user hierarchy to groups accessible by the parent of assigned user<br />
		///  ROLE_USER_MANAGEMENT_CREATE to assign descendants of the current user in a user hierarchy to groups accessible by current user AND accessible by the parent of assigned user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 The user was added to the group. <br /> <br />
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
		///
		Task<UserReference<TCustomProperties>?> AssignUserToUserGroup<TCustomProperties>(SubscribedUser body, string tenantId, int groupId) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Remove a specific user from a specific user group of a specific tenant <br />
		/// Remove a specific user (by a given user ID) from a specific user group (by a given user group ID) of a specific tenant (by a given tenant ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN OR ROLE_USER_MANAGEMENT_CREATE AND is parent of the user AND is not the current user 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A user was removed from a group. <br /> <br />
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
		/// <param name="groupId">Unique identifier of the user group. <br /></param>
		/// <param name="userId">Unique identifier of the a user. <br /></param>
		///
		Task<System.IO.Stream> RemoveUserFromUserGroup(string tenantId, int groupId, string userId) ;
		
		/// <summary> 
		/// Terminate a user's session <br />
		/// After logging out, a user has to enter valid credentials again to get access to the platform. <br />
		/// The request is responsible for removing cookies from the browser and invalidating internal platform access tokens. <br />
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the user is logged out. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="cookie">The authorization cookie storing the access token of the user. This parameter is specific to OAI-Secure authentication. <br /></param>
		/// <param name="xXSRFTOKEN">Prevents XRSF attack of the authenticated user. This parameter is specific to OAI-Secure authentication. <br /></param>
		///
		Task<System.IO.Stream> Logout(string? cookie = null, string? xXSRFTOKEN = null) ;
	}
	#nullable disable
}
