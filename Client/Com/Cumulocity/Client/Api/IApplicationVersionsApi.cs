///
/// IApplicationVersionsApi.cs
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
	/// API methods to retrieve, create, update and delete application versions. <br />
	/// </summary>
	///
	#nullable enable
	public interface IApplicationVersionsApi
	{
	
		/// <summary> 
		/// Retrieve a specific version of an application <br />
		/// Retrieve the selected version of an application in your tenant. To select the version, use only the version or only the tag query parameter. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the application version is sent in the response. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 422 both parameters (version and tag) are present. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="version">The version field of the application version. <br /></param>
		/// <param name="tag">The tag of the application version. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ApplicationVersion?> GetApplicationVersion(string id, string? version = null, string? tag = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all versions of an application <br />
		/// Retrieve all versions of an application in your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the list of application versions is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Application version not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 This application doesn't support versioning. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ApplicationVersionCollection?> GetApplicationVersions(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Create an application version <br />
		/// Create an application version in your tenant. <br />
		/// Uploaded version and tags can only contain upper and lower case letters, integers and <c>.</c>,<c>+</c>,<c> -</c>. Other characters are prohibited. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 An application version was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Application version not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 Duplicate version/tag or versions limit exceeded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 tag or version contains unacceptable characters. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="applicationBinary">The ZIP file to be uploaded. <br /></param>
		/// <param name="applicationVersion">The JSON file with version information. <br /></param>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ApplicationVersion?> CreateApplicationVersion(byte[] applicationBinary, string applicationVersion, string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Delete a specific version of an application <br />
		/// Delete a specific version of an application in your tenant, by a given tag or version. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A version was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Application version not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 Version with tag latest cannot be removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 both parameters (version and tag) are present. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="version">The version field of the application version. <br /></param>
		/// <param name="tag">The tag of the application version. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteApplicationVersion(string id, string? version = null, string? tag = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Replace an application version's tags <br />
		/// Replaces the tags of a given application version in your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 An application version was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Application version not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 Duplicate version/tag or versions limit exceeded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 tag contains unacceptable characters. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="version">Version of the application. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ApplicationVersion?> UpdateApplicationVersion(ApplicationVersionTag body, string id, string version, CancellationToken cToken = default) ;
	}
	#nullable disable
}
