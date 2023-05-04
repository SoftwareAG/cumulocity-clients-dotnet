///
/// IApplicationBinariesApi.cs
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
	/// An API method to upload an application binary. It is a deployable microservice or web application. <br />
	/// </summary>
	///
	#nullable enable
	public interface IApplicationBinariesApi
	{
	
		/// <summary> 
		/// Retrieve all application attachments <br />
		/// Retrieve all application attachments.This method is not supported by microservice applications. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the application attachments are sent in the response. <br /> <br />
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
		Task<ApplicationBinaries?> GetApplicationAttachments(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Upload an application attachment <br />
		/// Upload an application attachment (by a given application ID). <br />
		/// For the applications of type “microservice” and “web application” to be available for Cumulocity IoT platform users, an attachment ZIP file must be uploaded. <br />
		/// For a microservice application, the ZIP file must consist of: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>cumulocity.json - file describing the deployment <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>image.tar - executable Docker image <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// For a web application, the ZIP file must include an index.html file in the root directory. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN AND tenant is the owner of the application 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 The application attachments have been uploaded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="file">The ZIP file to be uploaded. <br /></param>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Application?> UploadApplicationAttachment(byte[] file, string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific application attachment <br />
		/// Retrieve a specific application attachment (by a given application ID and a given binary ID).This method is not supported by microservice applications. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the application attachment is sent as a ZIP file in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="binaryId">Unique identifier of the binary. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> GetApplicationAttachment(string id, string binaryId, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Delete a specific application attachment <br />
		/// Delete  a specific application attachment (by a given application ID and a given binary ID).This method is not supported by microservice applications. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_APPLICATION_MANAGEMENT_ADMIN AND tenant is the owner of the application 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 An application binary was removed. <br /> <br />
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
		/// <param name="id">Unique identifier of the application. <br /></param>
		/// <param name="binaryId">Unique identifier of the binary. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteApplicationAttachment(string id, string binaryId, CancellationToken cToken = default) ;
	}
	#nullable disable
}
