///
/// IBinariesApi.cs
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
	/// Managed objects can perform operations to store, retrieve and delete binaries. One binary can store only one file. Together with the binary, a managed object is created which acts as a metadata information for the binary. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IBinariesApi
	{
	
		/// <summary> 
		/// Search for stored files <br />
		/// Retrieve metadata information about stored files. Search for files by query parameters. This will not download the files. <br />
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the managed objects are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="childAdditionId">Search for a specific child addition and list all the groups to which it belongs. <br /></param>
		/// <param name="childAssetId">Search for a specific child asset and list all the groups to which it belongs. <br /></param>
		/// <param name="childDeviceId">Search for a specific child device and list all the groups to which it belongs. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="ids">The managed object IDs to search for. <br />ⓘ Info: If you query for multiple IDs at once, comma-separate the values. <br /></param>
		/// <param name="owner">Username of the owner of the managed objects. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="text">Search for managed objects where any property value is equal to the given one. Only string values are supported. <br /></param>
		/// <param name="type">The type of managed object to search for. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BinaryCollection?> GetBinaries(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, int? currentPage = null, List<string>? ids = null, string? owner = null, int? pageSize = null, string? text = null, string? type = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Upload a file <br />
		/// Uploading a file (binary) requires providing the following properties: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description><c>object</c> – In JSON format, it contains information about the file. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description><c>file</c> – Contains the file to be uploaded. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// After the file has been uploaded, the corresponding managed object will contain the fragment <c>c8y_IsBinary</c>. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ROLE_INVENTORY_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A file was uploaded. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 400 Unprocessable Entity – invalid payload. <br /> <br />
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
		/// <param name="pObject"></param>
		/// <param name="file">Path of the file to be uploaded. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Binary?> UploadBinary(BinaryInfo pObject, byte[] file, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a stored file <br />
		/// Retrieve a stored file (managed object) by a given ID.Supports chunk download and resuming an interrupted download using the <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Range" langword="<c>Range</c> header" />. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the resource OR MANAGE_OBJECT_READ permission on the resource 
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
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> GetBinary(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Replace a file <br />
		/// Upload and replace the attached file (binary) of a specific managed object by a given ID.<br />
		///  <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the resource OR MANAGE_OBJECT_ADMIN permission on the resource 
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
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Binary?> ReplaceBinary(byte[] body, string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Remove a stored file <br />
		/// Remove a managed object and its stored file by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the resource OR MANAGE_OBJECT_ADMIN permission on the resource 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A managed object and its stored file was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> RemoveBinary(string id, CancellationToken cToken = default) ;
	}
	#nullable disable
}
