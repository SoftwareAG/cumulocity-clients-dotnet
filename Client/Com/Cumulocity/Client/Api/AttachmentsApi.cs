///
/// AttachmentsApi.cs
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
	/// It is possible to store, retrieve and delete binaries for events. Each event can have one binary attached.
	/// </summary>
	#nullable enable
	public class AttachmentsApi : AdaptableApi 
	{
		public AttachmentsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve the attached file of a specific event<br/>
		/// Retrieve the attached file (binary) of a specific event by a given ID.  <section><h5>Required roles</h5> ROLE_EVENT_READ <b>OR</b> EVENT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the file is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Attachment not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the event.</param>
		public async Task<System.IO.Stream> GetEventAttachment(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}event/events/{id}/binaries"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/octet-stream");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <summary>
		/// Replace the attached file of a specific event<br/>
		/// Upload and replace the attached file (binary) of a specific event by a given ID.<br> The size of the attachment is configurable, and the default size is 50 MiB. The default chunk size is 5MiB.  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A file was uploaded.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Event not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the event.</param>
		/// <returns></returns>
		public async Task<EventBinary?> ReplaceEventAttachment(byte[] body, string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}event/events/{id}/binaries"));
			var request = new HttpRequestMessage 
			{
				Content = new ByteArrayContent(body),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "text/plain");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.event+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<EventBinary?>(responseStream);
		}
		
		/// <summary>
		/// Attach a file to a specific event<br/>
		/// Upload a file (binary) as an attachment of a specific event by a given ID.<br> The size of the attachment is configurable, and the default size is 50 MiB. The default chunk size is 5MiB.  After the file has been uploaded, the corresponding event will contain the fragment `c8y_IsBinary` similar to:  ```json "c8y_IsBinary": {     "name": "hello.txt",     "length": 365,     "type": "text/plain" } ```  When using `multipart/form-data` each value is sent as a block of data (body part), with a user agent-defined delimiter (`boundary`) separating each part. The keys are given in the `Content-Disposition` header of each part.  ```http POST /event/events/{id}/binaries Host: https://<TENANT_DOMAIN> Authorization: <AUTHORIZATION> Accept: application/json Content-Type: multipart/form-data;boundary="boundary"  --boundary Content-Disposition: form-data; name="object"  { "name": "hello.txt", "type": "text/plain" } --boundary Content-Disposition: form-data; name="file"; filename="hello.txt" Content-Type: text/plain  <FILE_CONTENTS> --boundary-- ```  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A file was uploaded.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Event not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>An attachment exists already.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the event.</param>
		/// <returns></returns>
		public async Task<EventBinary?> UploadEventAttachment(byte[] body, string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}event/events/{id}/binaries"));
			var request = new HttpRequestMessage 
			{
				Content = new ByteArrayContent(body),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "text/plain");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.event+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<EventBinary?>(responseStream);
		}
		
		/// <summary>
		/// Attach a file to a specific event<br/>
		/// Upload a file (binary) as an attachment of a specific event by a given ID.<br> The size of the attachment is configurable, and the default size is 50 MiB. The default chunk size is 5MiB.  After the file has been uploaded, the corresponding event will contain the fragment `c8y_IsBinary` similar to:  ```json "c8y_IsBinary": {     "name": "hello.txt",     "length": 365,     "type": "text/plain" } ```  When using `multipart/form-data` each value is sent as a block of data (body part), with a user agent-defined delimiter (`boundary`) separating each part. The keys are given in the `Content-Disposition` header of each part.  ```http POST /event/events/{id}/binaries Host: https://<TENANT_DOMAIN> Authorization: <AUTHORIZATION> Accept: application/json Content-Type: multipart/form-data;boundary="boundary"  --boundary Content-Disposition: form-data; name="object"  { "name": "hello.txt", "type": "text/plain" } --boundary Content-Disposition: form-data; name="file"; filename="hello.txt" Content-Type: text/plain  <FILE_CONTENTS> --boundary-- ```  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A file was uploaded.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Event not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>An attachment exists already.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="pObject"></param>
		/// <param name="file">Path of the file to be uploaded.</param>
		/// <param name="id">Unique identifier of the event.</param>
		/// <returns></returns>
		public async Task<EventBinary?> UploadEventAttachment(BinaryInfo pObject, byte[] file, string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}event/events/{id}/binaries"));
			var requestContent = new MultipartFormDataContent();
			var fileContentObject = new StringContent(JsonSerializer.Serialize(pObject));
			fileContentObject.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
			requestContent.Add(fileContentObject, "object");
			var fileContentFile = new ByteArrayContent(file);
			fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
			requestContent.Add(fileContentFile, "file");
			var request = new HttpRequestMessage 
			{
				Content = requestContent,
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.event+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<EventBinary?>(responseStream);
		}
		
		/// <summary>
		/// Remove the attached file from a specific event<br/>
		/// Remove the attached file (binary) from a specific event by a given ID.  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A file was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Event not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the event.</param>
		public async Task<System.IO.Stream> DeleteEventAttachment(string id)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}event/events/{id}/binaries"));
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
