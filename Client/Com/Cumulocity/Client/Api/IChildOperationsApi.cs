///
/// IChildOperationsApi.cs
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
	/// Managed objects can contain collections of references to child devices, additions and assets. <br />
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IChildOperationsApi
	{
	
		/// <summary> 
		/// Retrieve all child additions of a specific managed object <br />
		/// Retrieve all child additions of a specific managed object by a given ID, or a subset based on queries. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all child additions are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in <see href="#tag/Query-language" langword="Query language" />. <br /></param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to <c>false</c> to improve query performance. <br /></param>
		/// <param name="withChildrenCount">When set to <c>true</c>, the returned result will contain the total number of children in the respective objects (<c>childAdditions</c>, <c>childAssets</c> and <c>childDevices</c>). <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectReferenceCollection<TManagedObject>?> GetChildAdditions<TManagedObject>(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Assign a managed object as child addition <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child addition of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child additions of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child addition to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child addition. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildAddition(ChildOperationsAddOne body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a managed object as child addition <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child addition of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child additions of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child addition to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child addition. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildAddition(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a managed object as child addition <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child addition of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child additions of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child addition to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child addition. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildAddition<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove specific child additions from its parent <br />
		/// Remove specific child additions (by given child IDs) from its parent (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source (parent) OR owner of the child OR MANAGE_OBJECT_ADMIN permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 Child additions were removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignChildAdditions(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific child addition of a specific managed object <br />
		/// Retrieve a specific child addition (by a given child ID) of a specific managed object (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR MANAGE_OBJECT_READ permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the child addition is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="childId">Unique identifier of the child object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectReference<TManagedObject>?> GetChildAddition<TManagedObject>(string id, string childId, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove a specific child addition from its parent <br />
		/// Remove a specific child addition (by a given child ID) from its parent (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source (parent) OR owner of the child OR MANAGE_OBJECT_ADMIN permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A child addition was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="childId">Unique identifier of the child object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignChildAddition(string id, string childId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all child assets of a specific managed object <br />
		/// Retrieve all child assets of a specific managed object by a given ID, or a subset based on queries. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all child assets are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in <see href="#tag/Query-language" langword="Query language" />. <br /></param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to <c>false</c> to improve query performance. <br /></param>
		/// <param name="withChildrenCount">When set to <c>true</c>, the returned result will contain the total number of children in the respective objects (<c>childAdditions</c>, <c>childAssets</c> and <c>childDevices</c>). <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectReferenceCollection<TManagedObject>?> GetChildAssets<TManagedObject>(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Assign a managed object as child asset <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child asset of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child assets of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child asset to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child asset. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildAsset(ChildOperationsAddOne body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a managed object as child asset <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child asset of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child assets of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child asset to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child asset. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildAsset(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a managed object as child asset <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child asset of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child assets of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child asset to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child asset. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildAsset<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove specific child assets from its parent <br />
		/// Remove specific child assets (by given child IDs) from its parent (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source (parent) OR owner of the child OR MANAGE_OBJECT_ADMIN permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 Child assets were removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignChildAssets(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific child asset of a specific managed object <br />
		/// Retrieve a specific child asset (by a given child ID) of a specific managed object (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR MANAGE_OBJECT_READ permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the child asset is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="childId">Unique identifier of the child object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectReference<TManagedObject>?> GetChildAsset<TManagedObject>(string id, string childId, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove a specific child asset from its parent <br />
		/// Remove a specific child asset (by a given child ID) from its parent (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source (parent) OR owner of the child OR MANAGE_OBJECT_ADMIN permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A child asset was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="childId">Unique identifier of the child object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignChildAsset(string id, string childId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all child devices of a specific managed object <br />
		/// Retrieve all child devices of a specific managed object by a given ID, or a subset based on queries. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all child devices are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in <see href="#tag/Query-language" langword="Query language" />. <br /></param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to <c>false</c> to improve query performance. <br /></param>
		/// <param name="withChildrenCount">When set to <c>true</c>, the returned result will contain the total number of children in the respective objects (<c>childAdditions</c>, <c>childAssets</c> and <c>childDevices</c>). <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectReferenceCollection<TManagedObject>?> GetChildDevices<TManagedObject>(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Assign a managed object as child device <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child device of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child devices of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child device to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child device. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildDevice(ChildOperationsAddOne body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a managed object as child device <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child device of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child devices of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child device to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child device. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildDevice(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Assign a managed object as child device <br />
		/// The possible ways to assign child objects are: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Assign an existing managed object (by a given child ID) as child device of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Assign multiple existing managed objects (by given child IDs) as child devices of another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Create a managed object in the inventory and assign it as a child device to another managed object (by a given ID). <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ((owner of the source OR MANAGE_OBJECT_ADMIN permission on the source) AND (owner of the child OR MANAGE_OBJECT_ADMIN permission on the child)) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was assigned as child device. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> AssignAsChildDevice<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove specific child devices from its parent <br />
		/// Remove specific child devices (by given child IDs) from its parent (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source (parent) OR owner of the child OR MANAGE_OBJECT_ADMIN permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 Child devices were removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignChildDevices(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific child device of a specific managed object <br />
		/// Retrieve a specific child device (by a given child ID) of a specific managed object (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR MANAGE_OBJECT_READ permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the child device is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="childId">Unique identifier of the child object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectReference<TManagedObject>?> GetChildDevice<TManagedObject>(string id, string childId, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove a specific child device from its parent <br />
		/// Remove a specific child device (by a given child ID) from its parent (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source (parent) OR owner of the child OR MANAGE_OBJECT_ADMIN permission on the source (parent) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A child device was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Managed object not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="childId">Unique identifier of the child object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UnassignChildDevice(string id, string childId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	}
	#nullable disable
}
