///
/// IApplicationsApi.cs
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
	/// API methods to retrieve, create, update and delete applications.
	/// 
	/// ### Application names
	/// 
	/// For each tenant, Cumulocity IoT manages the subscribed applications and provides a number of applications of various types.
	/// In case you want to subscribe a tenant to an application using an API, you must use the application name in the argument (as name).
	/// 
	/// Refer to the tables in [Administration > Managing applications](https://cumulocity.com/guides/10.7.0/users-guide/administration#managing-applications) in the User guide for the respective application name to be used.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IApplicationsApi
	{
	
		/// <summary>
		/// Retrieve all applications<br/>
		/// Retrieve all applications on your tenant.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the list of applications is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="name">The name of the application.</param>
		/// <param name="owner">The ID of the tenant that owns the applications.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="providedFor">The ID of a tenant that is subscribed to the applications but doesn't own them.</param>
		/// <param name="subscriber">The ID of a tenant that is subscribed to the applications.</param>
		/// <param name="tenant">The ID of a tenant that either owns the application or is subscribed to the applications.</param>
		/// <param name="type">The type of the application.</param>
		/// <param name="user">The ID of a user that has access to the applications.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ApplicationCollection?> GetApplications(int? currentPage = null, string? name = null, string? owner = null, int? pageSize = null, string? providedFor = null, string? subscriber = null, string? tenant = null, string? type = null, string? user = null, bool? withTotalElements = null, bool? withTotalPages = null) ;
		
		/// <summary>
		/// Create an application<br/>
		/// Create an application on your tenant.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An application was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate key/name.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<Application?> CreateApplication(Application body, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Retrieve a specific application<br/>
		/// Retrieve a specific application (by a given ID).  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ <b>OR</b> current user has explicit access to the application </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the application is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <returns></returns>
		Task<Application?> GetApplication(string id) ;
		
		/// <summary>
		/// Update a specific application<br/>
		/// Update a specific application (by a given ID).  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An application was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<Application?> UpdateApplication(Application body, string id, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Delete an application<br/>
		/// Delete an application (by a given ID). This method is not supported by microservice applications.  > **&#9432; Info:** With regards to a hosted application, there is a caching mechanism in place that keeps the information about the placement of application files (html, javascript, css, fonts, etc.). Removing a hosted application, in normal circumstances, will cause the subsequent requests for application files to fail with an HTTP 404 error because the application is removed synchronously, its files are immediately removed on the node serving the request and at the same time the information is propagated to other nodes – but in rare cases there might be a delay with this propagation. In such situations, the files of the removed application can be served from those nodes up until the aforementioned cache expires. For the same reason, the cache can also cause HTTP 404 errors when the application is updated as it will keep the path to the files of the old version of the application. The cache is filled on demand, so there should not be issues if application files were not accessed prior to the delete request. The expiration delay of the cache can differ, but should not take more than one minute.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN <b>AND</b> tenant is the owner of the application </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>An application was removed.</description>
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
		/// <description>Application not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="force">Force deletion by unsubscribing all tenants from the application first and then deleting the application itself.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> DeleteApplication(string id, bool? force = null, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Copy an application<br/>
		/// Copy an application (by a given ID).  This method is not supported by microservice applications.  A request to the "clone" resource creates a new application based on an already existing one.  The properties are copied to the newly created application and the prefix "clone" is added to the properties `name`, `key` and `contextPath` in order to be unique.  If the target application is hosted and has an active version, the new application will have the active version with the same content. <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An application was copied.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – method not supported</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<Application?> CopyApplication(string id, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Retrieve applications by name<br/>
		/// Retrieve applications by name.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the applications are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="name">The name of the application.</param>
		/// <returns></returns>
		Task<ApplicationCollection?> GetApplicationsByName(string name) ;
		
		/// <summary>
		/// Retrieve applications by tenant<br/>
		/// Retrieve applications subscribed or owned by a particular tenant (by a given tenant ID).  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the applications are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <returns></returns>
		Task<ApplicationCollection?> GetApplicationsByTenant(string tenantId) ;
		
		/// <summary>
		/// Retrieve applications by owner<br/>
		/// Retrieve all applications owned by a particular tenant (by a given tenant ID).  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the applications are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ApplicationCollection?> GetApplicationsByOwner(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null) ;
		
		/// <summary>
		/// Retrieve applications by user<br/>
		/// Retrieve all applications for a particular user (by a given username).  <section><h5>Required roles</h5> (ROLE_USER_MANAGEMENT_OWN_READ <b>AND</b> is the current user) <b>OR</b> (ROLE_USER_MANAGEMENT_READ <b>AND</b> ROLE_APPLICATION_MANAGEMENT_READ) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the applications are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="username">The username of the a user.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ApplicationCollection?> GetApplicationsByUser(string username, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null) ;
	}
	#nullable disable
}
