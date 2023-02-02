///
/// IApplicationVersionsApi.cs
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
	/// API methods to retrieve, create, update and delete application versions.
	/// </summary>
	#nullable enable
	public interface IApplicationVersionsApi
	{
	
		/// <summary>
		/// Retrieve a specific version of an application<br/>
		/// Retrieve the selected version of an application in your tenant. To select the version, use only the version or only the tag query parameter. <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section>
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the application version is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>both parameters (version and tag) are present.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="version">The version field of the application version.</param>
		/// <param name="tag">The tag of the application version.</param>
		/// <returns></returns>
		Task<ApplicationVersion?> GetApplicationVersion(string id, string? version = null, string? tag = null) ;
		
		/// <summary>
		/// Retrieve all versions of an application<br/>
		/// Retrieve all versions of an application in your tenant.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the list of application versions is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application version not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>This application doesn't support versioning.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <returns></returns>
		Task<ApplicationVersionCollection?> GetApplicationVersions(string id) ;
		
		/// <summary>
		/// Create an application version<br/>
		/// Create an application version in your tenant.  Uploaded version and tags can only contain upper and lower case letters, integers and `.`,` + `,` -`. Other characters are prohibited.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An application version was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application version not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate version/tag or versions limit exceeded.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>tag or version contains unacceptable characters.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="applicationBinary">The ZIP file to be uploaded.</param>
		/// <param name="applicationVersion">The JSON file with version information.</param>
		/// <param name="id">Unique identifier of the application.</param>
		/// <returns></returns>
		Task<ApplicationVersion?> CreateApplicationVersion(byte[] applicationBinary, string applicationVersion, string id) ;
		
		/// <summary>
		/// Delete a specific version of an application<br/>
		/// Delete a specific version of an application in your tenant, by a given tag or version.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A version was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application version not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Version with tag latest cannot be removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>both parameters (version and tag) are present.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="version">The version field of the application version.</param>
		/// <param name="tag">The tag of the application version.</param>
		Task<System.IO.Stream> DeleteApplicationVersion(string id, string? version = null, string? tag = null) ;
		
		/// <summary>
		/// Replace an application version's tags<br/>
		/// Replaces the tags of a given application version in your tenant.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An application version was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Application version not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate version/tag or versions limit exceeded.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>tag contains unacceptable characters.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="version">Version of the application.</param>
		/// <returns></returns>
		Task<ApplicationVersion?> UpdateApplicationVersion(ApplicationVersionTag body, string id, string version) ;
	}
	#nullable disable
}
