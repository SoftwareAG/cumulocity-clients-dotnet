///
/// ApplicationBinariesApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// An API method to upload an application binary. It is a deployable microservice or web application.
	/// </summary>
	#nullable enable
	public class ApplicationBinariesApi : AdaptableApi 
	{
		public ApplicationBinariesApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
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
		public async Task<ApplicationBinaries?> GetApplicationAttachments(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/application/applications/{id}/binaries"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.applicationbinaries+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<ApplicationBinaries?>(responseStream);
		}
		
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
		/// <returns></returns>
		public async Task<Application?> UploadApplicationAttachment(byte[] file, string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/application/applications/{id}/binaries"));
			var requestContent = new MultipartFormDataContent();
			var fileContentFile = new ByteArrayContent(file);
			fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("application/zip");
			requestContent.Add(fileContentFile, "file");
			var request = new HttpRequestMessage 
			{
				Content = requestContent,
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.application+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Application?>(responseStream);
		}
		
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
		public async Task<System.IO.Stream> GetApplicationAttachment(string id, string binaryId)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/application/applications/{id}/binaries/{binaryId}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/zip");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
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
		public async Task<System.IO.Stream> DeleteApplicationAttachment(string id, string binaryId)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/application/applications/{id}/binaries/{binaryId}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
	}
	#nullable disable
}
