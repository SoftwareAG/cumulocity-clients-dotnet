///
/// IApplicationBinariesApi.cs
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
	/// An API method to upload an application binary. It is a deployable microservice or web application.
	/// </summary>
	#nullable enable
	public interface IApplicationBinariesApi
	{
	
		/// <summary>
		/// Retrieve all application attachments<br/>
		/// Retrieve all application attachments. This method is not supported by microservice applications.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the application attachments are sent in the response.</description>
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
		Task<ApplicationBinaries?> GetApplicationAttachments(string id) ;
		
		/// <summary>
		/// Upload an application attachment<br/>
		/// Upload an application attachment (by a given application ID).  For the applications of type “microservice” and “web application” to be available for Cumulocity IoT platform users, an attachment ZIP file must be uploaded.  For a microservice application, the ZIP file must consist of:  * cumulocity.json - file describing the deployment * image.tar - executable Docker image  For a web application, the ZIP file must include an index.html file in the root directory.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN <b>AND</b> tenant is the owner of the application </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>The application attachments have been uploaded.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="file">The ZIP file to be uploaded.</param>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<Application?> UploadApplicationAttachment(byte[] file, string id, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Retrieve a specific application attachment<br/>
		/// Retrieve a specific application attachment (by a given application ID and a given binary ID). This method is not supported by microservice applications.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the application attachment is sent as a ZIP file in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="binaryId">Unique identifier of the binary.</param>
		Task<System.IO.Stream> GetApplicationAttachment(string id, string binaryId) ;
		
		/// <summary>
		/// Delete a specific application attachment<br/>
		/// Delete  a specific application attachment (by a given application ID and a given binary ID). This method is not supported by microservice applications.  <section><h5>Required roles</h5> ROLE_APPLICATION_MANAGEMENT_ADMIN <b>AND</b> tenant is the owner of the application </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>An application binary was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application.</param>
		/// <param name="binaryId">Unique identifier of the binary.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> DeleteApplicationAttachment(string id, string binaryId, string xCumulocityProcessingMode) ;
	}
	#nullable disable
}
