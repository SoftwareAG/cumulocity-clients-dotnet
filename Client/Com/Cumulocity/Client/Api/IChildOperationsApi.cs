///
/// IChildOperationsApi.cs
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
	/// Managed objects can contain collections of references to child devices, additions and assets.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IChildOperationsApi
	{
	
		/// <summary>
		/// Retrieve all child additions of a specific managed object<br/>
		/// Retrieve all child additions of a specific managed object by a given ID, or a subset based on queries.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all child additions are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in [Query language](#tag/Query-language).</param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to `false` to improve query performance.</param>
		/// <param name="withChildrenCount">When set to `true`, the returned result will contain the total number of children in the respective objects (`childAdditions`, `childAssets` and `childDevices`).</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ManagedObjectReferenceCollection?> GetChildAdditions(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null);
		
		/// <summary>
		/// Assign a managed object as child addition<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child addition of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child additions of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child addition to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child addition.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildAddition(ChildOperationsAddOne body, string id);
		
		/// <summary>
		/// Assign a managed object as child addition<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child addition of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child additions of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child addition to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child addition.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildAddition(ChildOperationsAddMultiple body, string id);
		
		/// <summary>
		/// Assign a managed object as child addition<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child addition of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child additions of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child addition to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child addition.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildAddition(ManagedObject body, string id);
		
		/// <summary>
		/// Remove specific child additions from its parent<br/>
		/// Remove specific child additions (by given child IDs) from its parent (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source (parent) <b>OR</b> owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>Child additions were removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> UnassignChildAdditions(ChildOperationsAddMultiple body, string id);
		
		/// <summary>
		/// Retrieve a specific child addition of a specific managed object<br/>
		/// Retrieve a specific child addition (by a given child ID) of a specific managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> MANAGE_OBJECT_READ permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the child addition is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="childId">Unique identifier of the child object.</param>
		/// <returns></returns>
		Task<ManagedObjectReference?> GetChildAddition(string id, string childId);
		
		/// <summary>
		/// Remove a specific child addition from its parent<br/>
		/// Remove a specific child addition (by a given child ID) from its parent (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source (parent) <b>OR</b> owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A child addition was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="childId">Unique identifier of the child object.</param>
		Task<System.IO.Stream> UnassignChildAddition(string id, string childId);
		
		/// <summary>
		/// Retrieve all child assets of a specific managed object<br/>
		/// Retrieve all child assets of a specific managed object by a given ID, or a subset based on queries.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all child assets are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in [Query language](#tag/Query-language).</param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to `false` to improve query performance.</param>
		/// <param name="withChildrenCount">When set to `true`, the returned result will contain the total number of children in the respective objects (`childAdditions`, `childAssets` and `childDevices`).</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ManagedObjectReferenceCollection?> GetChildAssets(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null);
		
		/// <summary>
		/// Assign a managed object as child asset<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child asset of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child assets of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child asset to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child asset.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildAsset(ChildOperationsAddOne body, string id);
		
		/// <summary>
		/// Assign a managed object as child asset<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child asset of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child assets of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child asset to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child asset.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildAsset(ChildOperationsAddMultiple body, string id);
		
		/// <summary>
		/// Assign a managed object as child asset<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child asset of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child assets of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child asset to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child asset.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildAsset(ManagedObject body, string id);
		
		/// <summary>
		/// Remove specific child assets from its parent<br/>
		/// Remove specific child assets (by given child IDs) from its parent (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source (parent) <b>OR</b> owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>Child assets were removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> UnassignChildAssets(ChildOperationsAddMultiple body, string id);
		
		/// <summary>
		/// Retrieve a specific child asset of a specific managed object<br/>
		/// Retrieve a specific child asset (by a given child ID) of a specific managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> MANAGE_OBJECT_READ permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the child asset is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="childId">Unique identifier of the child object.</param>
		/// <returns></returns>
		Task<ManagedObjectReference?> GetChildAsset(string id, string childId);
		
		/// <summary>
		/// Remove a specific child asset from its parent<br/>
		/// Remove a specific child asset (by a given child ID) from its parent (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source (parent) <b>OR</b> owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A child asset was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="childId">Unique identifier of the child object.</param>
		Task<System.IO.Stream> UnassignChildAsset(string id, string childId);
		
		/// <summary>
		/// Retrieve all child devices of a specific managed object<br/>
		/// Retrieve all child devices of a specific managed object by a given ID, or a subset based on queries.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all child devices are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in [Query language](#tag/Query-language).</param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to `false` to improve query performance.</param>
		/// <param name="withChildrenCount">When set to `true`, the returned result will contain the total number of children in the respective objects (`childAdditions`, `childAssets` and `childDevices`).</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ManagedObjectReferenceCollection?> GetChildDevices(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null);
		
		/// <summary>
		/// Assign a managed object as child device<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child device of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child devices of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child device to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child device.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildDevice(ChildOperationsAddOne body, string id);
		
		/// <summary>
		/// Assign a managed object as child device<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child device of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child devices of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child device to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child device.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildDevice(ChildOperationsAddMultiple body, string id);
		
		/// <summary>
		/// Assign a managed object as child device<br/>
		/// The possible ways to assign child objects are:  *  Assign an existing managed object (by a given child ID) as child device of another managed object (by a given ID). *  Assign multiple existing managed objects (by given child IDs) as child devices of another managed object (by a given ID). *  Create a managed object in the inventory and assign it as a child device to another managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ((owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source) <b>AND</b> (owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the child)) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was assigned as child device.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> AssignAsChildDevice(ManagedObject body, string id);
		
		/// <summary>
		/// Remove specific child devices from its parent<br/>
		/// Remove specific child devices (by given child IDs) from its parent (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source (parent) <b>OR</b> owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>Child devices were removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object.</param>
		Task<System.IO.Stream> UnassignChildDevices(ChildOperationsAddMultiple body, string id);
		
		/// <summary>
		/// Retrieve a specific child device of a specific managed object<br/>
		/// Retrieve a specific child device (by a given child ID) of a specific managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> MANAGE_OBJECT_READ permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the child device is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="childId">Unique identifier of the child object.</param>
		/// <returns></returns>
		Task<ManagedObjectReference?> GetChildDevice(string id, string childId);
		
		/// <summary>
		/// Remove a specific child device from its parent<br/>
		/// Remove a specific child device (by a given child ID) from its parent (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source (parent) <b>OR</b> owner of the child <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source (parent) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A child device was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Managed object not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="childId">Unique identifier of the child object.</param>
		Task<System.IO.Stream> UnassignChildDevice(string id, string childId);
	}
	#nullable disable
}
