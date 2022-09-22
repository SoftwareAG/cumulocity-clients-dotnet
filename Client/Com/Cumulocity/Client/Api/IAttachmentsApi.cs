///
/// IAttachmentsApi.cs
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
	/// It is possible to store, retrieve and delete binaries for events. Each event can have one binary attached.
	/// </summary>
	#nullable enable
	public interface IAttachmentsApi
	{
	
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
		Task<System.IO.Stream> GetEventAttachment(string id);
		
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
		Task<EventBinary?> ReplaceEventAttachment(byte[] body, string id);
		
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
		Task<EventBinary?> UploadEventAttachment(byte[] body, string id);
		
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
		Task<EventBinary?> UploadEventAttachment(BinaryInfo pObject, byte[] file, string id);
		
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
		Task<System.IO.Stream> DeleteEventAttachment(string id);
	}
	#nullable disable
}
