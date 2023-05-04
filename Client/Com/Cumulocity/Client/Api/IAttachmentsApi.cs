///
/// IAttachmentsApi.cs
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
	/// It is possible to store, retrieve and delete binaries for events. Each event can have one binary attached. <br />
	/// </summary>
	///
	#nullable enable
	public interface IAttachmentsApi
	{
	
		/// <summary> 
		/// Retrieve the attached file of a specific event <br />
		/// Retrieve the attached file (binary) of a specific event by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_READ OR EVENT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the file is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Attachment not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> GetEventAttachment(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Replace the attached file of a specific event <br />
		/// Upload and replace the attached file (binary) of a specific event by a given ID.<br />
		/// The size of the attachment is configurable, and the default size is 50 MiB. The default chunk size is 5MiB. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A file was uploaded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Event not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<EventBinary?> ReplaceEventAttachment(byte[] body, string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Attach a file to a specific event <br />
		/// Upload a file (binary) as an attachment of a specific event by a given ID.<br />
		/// The size of the attachment is configurable, and the default size is 50 MiB. The default chunk size is 5MiB. <br />
		/// After the file has been uploaded, the corresponding event will contain the fragment <c>c8y_IsBinary</c> similar to: <br />
		/// <![CDATA[
		/// "c8y_IsBinary": {
		///     "name": "hello.txt",
		///     "length": 365,
		///     "type": "text/plain"
		/// }
		/// ]]>
		/// When using <c>multipart/form-data</c> each value is sent as a block of data (body part), with a user agent-defined delimiter (<c>boundary</c>) separating each part. The keys are given in the <c>Content-Disposition</c> header of each part. <br />
		/// <![CDATA[
		/// POST /event/events/{id}/binaries
		/// Host: https://<TENANT_DOMAIN>
		/// Authorization: <AUTHORIZATION>
		/// Accept: application/json
		/// Content-Type: multipart/form-data;boundary="boundary"
		/// 
		/// --boundary
		/// Content-Disposition: form-data; name="object"
		/// 
		/// { "name": "hello.txt", "type": "text/plain" }
		/// --boundary
		/// Content-Disposition: form-data; name="file"; filename="hello.txt"
		/// Content-Type: text/plain
		/// 
		/// <FILE_CONTENTS>
		/// --boundary--
		/// ]]>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A file was uploaded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Event not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 An attachment exists already. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<EventBinary?> UploadEventAttachment(byte[] body, string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Attach a file to a specific event <br />
		/// Upload a file (binary) as an attachment of a specific event by a given ID.<br />
		/// The size of the attachment is configurable, and the default size is 50 MiB. The default chunk size is 5MiB. <br />
		/// After the file has been uploaded, the corresponding event will contain the fragment <c>c8y_IsBinary</c> similar to: <br />
		/// <![CDATA[
		/// "c8y_IsBinary": {
		///     "name": "hello.txt",
		///     "length": 365,
		///     "type": "text/plain"
		/// }
		/// ]]>
		/// When using <c>multipart/form-data</c> each value is sent as a block of data (body part), with a user agent-defined delimiter (<c>boundary</c>) separating each part. The keys are given in the <c>Content-Disposition</c> header of each part. <br />
		/// <![CDATA[
		/// POST /event/events/{id}/binaries
		/// Host: https://<TENANT_DOMAIN>
		/// Authorization: <AUTHORIZATION>
		/// Accept: application/json
		/// Content-Type: multipart/form-data;boundary="boundary"
		/// 
		/// --boundary
		/// Content-Disposition: form-data; name="object"
		/// 
		/// { "name": "hello.txt", "type": "text/plain" }
		/// --boundary
		/// Content-Disposition: form-data; name="file"; filename="hello.txt"
		/// Content-Type: text/plain
		/// 
		/// <FILE_CONTENTS>
		/// --boundary--
		/// ]]>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A file was uploaded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Event not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 409 An attachment exists already. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="pObject"></param>
		/// <param name="file">Path of the file to be uploaded. <br /></param>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<EventBinary?> UploadEventAttachment(BinaryInfo pObject, byte[] file, string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Remove the attached file from a specific event <br />
		/// Remove the attached file (binary) from a specific event by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A file was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Event not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteEventAttachment(string id, CancellationToken cToken = default) ;
	}
	#nullable disable
}
