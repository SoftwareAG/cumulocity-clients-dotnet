//
// IApplicationsApi.cs
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
/// API methods to retrieve, create, update and delete applications. <br />
/// ### Application names <br />
/// For each tenant, Cumulocity IoT manages the subscribed applications and provides a number of applications of various types.In case you want to subscribe a tenant to an application using an API, you must use the application name in the argument (as name). <br />
/// Refer to the tables in <see href="https://cumulocity.com/docs/standard-tenant/ecosystem/#managing-applications" langword="Platform administration > Standard tenant administration > Managing the ecosystem > Managing applications" /> in the Cumulocity IoT user documentation for the respective application name to be used. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public interface IApplicationsApi
{

	/// <summary> 
	/// Retrieve all applications <br />
	/// Retrieve all applications on your tenant. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_READ 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the list of applications is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="currentPage">The current page of the paginated results. <br /></param>
	/// <param name="name">The name of the application. <br /></param>
	/// <param name="owner">The ID of the tenant that owns the applications. <br /></param>
	/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
	/// <param name="providedFor">The ID of a tenant that is subscribed to the applications but doesn't own them. <br /></param>
	/// <param name="subscriber">The ID of a tenant that is subscribed to the applications. <br /></param>
	/// <param name="tenant">The ID of a tenant that either owns the application or is subscribed to the applications. <br /></param>
	/// <param name="type">The type of the application. It is possible to use multiple values separated by a comma. For example, <c>EXTERNAL,HOSTED</c> will return only applications with type <c>EXTERNAL</c> or <c>HOSTED</c>. <br /></param>
	/// <param name="user">The ID of a user that has access to the applications. <br /></param>
	/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="hasVersions">When set to <c>true</c>, the returned result contains applications with an <c>applicationVersions</c> field that is not empty. When set to <c>false</c>, the result will contain applications with an empty <c>applicationVersions</c> field. <br /></param>
	///
	Task<ApplicationCollection?> GetApplications(int? currentPage = null, string? name = null, string? owner = null, int? pageSize = null, string? providedFor = null, string? subscriber = null, string? tenant = null, string? type = null, string? user = null, bool? withTotalElements = null, bool? withTotalPages = null, bool? hasVersions = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Create an application <br />
	/// Create an application on your tenant. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 An application was created. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 409 Duplicate key/name. <br /> <br />
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
	Task<Application?> CreateApplication(Application body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve a specific application <br />
	/// Retrieve a specific application (by a given ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_READ OR current user has explicit access to the application 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the application is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Application not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the application. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<Application?> GetApplication(string id, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Update a specific application <br />
	/// Update a specific application (by a given ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_USER_MANAGEMENT_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 An application was updated. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Application not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="id">Unique identifier of the application. <br /></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<Application?> UpdateApplication(Application body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Delete an application <br />
	/// Delete an application (by a given ID).This method is not supported by microservice applications. <br />
	/// ⓘ Info: With regards to a hosted application, there is a caching mechanism in place that keeps the information about the placement of application files (html, javascript, css, fonts, etc.). Removing a hosted application, in normal circumstances, will cause the subsequent requests for application files to fail with an HTTP 404 error because the application is removed synchronously, its files are immediately removed on the node serving the request and at the same time the information is propagated to other nodes – but in rare cases there might be a delay with this propagation. In such situations, the files of the removed application can be served from those nodes up until the aforementioned cache expires. For the same reason, the cache can also cause HTTP 404 errors when the application is updated as it will keep the path to the files of the old version of the application. The cache is filled on demand, so there should not be issues if application files were not accessed prior to the delete request. The expiration delay of the cache can differ, but should not take more than one minute. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_ADMIN AND tenant is the owner of the application 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 An application was removed. <br /> <br />
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
	/// 		<description>HTTP 404 Application not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the application. <br /></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="force">Force deletion by unsubscribing all tenants from the application first and then deleting the application itself. <br /></param>
	///
	Task<string?> DeleteApplication(string id, bool? force = null, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Copy an application <br />
	/// Copy an application (by a given ID). <br />
	/// This method is not supported by microservice applications. <br />
	/// A request to the "clone" resource creates a new application based on an already existing one. <br />
	/// The properties are copied to the newly created application and the prefix "clone" is added to the properties <c>name</c>, <c>key</c> and <c>contextPath</c> in order to be unique. <br />
	/// If the target application is hosted and has an active version, the new application will have the active version with the same content. <br />
	/// If the original application is hosted with versions, then only one binary version is cloned. By default it is a version with the "latest" tag. You can also specify a target version directly by using exactly one of the query parameters <c>version</c> or <c>tag</c>. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 An application was copied. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – method not supported <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the application. <br /></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="version">The version field of the application version. <br /></param>
	/// <param name="tag">The tag of the application version. <br /></param>
	///
	Task<Application?> CopyApplication(string id, string? version = null, string? tag = null, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve applications by name <br />
	/// Retrieve applications by name. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_READ 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the applications are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="name">The name of the application. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<ApplicationCollection?> GetApplicationsByName(string name, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve applications by tenant <br />
	/// Retrieve applications subscribed or owned by a particular tenant (by a given tenant ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_READ 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the applications are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<ApplicationCollection?> GetApplicationsByTenant(string tenantId, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve applications by owner <br />
	/// Retrieve all applications owned by a particular tenant (by a given tenant ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_APPLICATION_MANAGEMENT_READ 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the applications are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="currentPage">The current page of the paginated results. <br /></param>
	/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
	/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	///
	Task<ApplicationCollection?> GetApplicationsByOwner(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve applications by user <br />
	/// Retrieve all applications for a particular user (by a given username). <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_USER_MANAGEMENT_OWN_READ AND is the current user) OR (ROLE_USER_MANAGEMENT_READ AND ROLE_APPLICATION_MANAGEMENT_READ) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the applications are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="username">The username of the a user. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="currentPage">The current page of the paginated results. <br /></param>
	/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
	/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	///
	Task<ApplicationCollection?> GetApplicationsByUser(string username, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
}
