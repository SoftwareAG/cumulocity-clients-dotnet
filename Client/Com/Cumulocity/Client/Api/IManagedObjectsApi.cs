///
/// IManagedObjectsApi.cs
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
	/// The inventory stores devices and other assets relevant to your IoT solution. We refer to them as managed objects and such can be “smart objects”, for example, smart electricity meters, home automation gateways or GPS devices.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IManagedObjectsApi
	{
	
		/// <summary>
		/// Retrieve all managed objects<br/>
		/// Retrieve all managed objects (for example, devices, assets, etc.) registered in your tenant, or a subset based on queries. 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the collection of objects is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Invalid data was sent.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="childAdditionId">Search for a specific child addition and list all the groups to which it belongs.</param>
		/// <param name="childAssetId">Search for a specific child asset and list all the groups to which it belongs.</param>
		/// <param name="childDeviceId">Search for a specific child device and list all the groups to which it belongs.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state.</param>
		/// <param name="ids">The managed object IDs to search for (comma separated).</param>
		/// <param name="onlyRoots">When set to `true` it returns managed objects which don't have any parent. If the current user doesn't have access to the parent, this is also root for the user.</param>
		/// <param name="owner">Username of the owner of the managed objects.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="q">Similar to the parameter `query`, but it assumes that this is a device query request and it adds automatically the search criteria `fragmentType=c8y_IsDevice`.</param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in [Query language](#tag/Query-language).</param>
		/// <param name="skipChildrenNames">When set to `true`, the returned references of child devices won't contain their names.</param>
		/// <param name="text">Search for managed objects where any property value is equal to the given one. Only string values are supported.</param>
		/// <param name="type">The type of managed object to search for.</param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to `false` to improve query performance.</param>
		/// <param name="withChildrenCount">When set to `true`, the returned result will contain the total number of children in the respective objects (`childAdditions`, `childAssets` and `childDevices`).</param>
		/// <param name="withGroups">When set to `true` it returns additional information about the groups to which the searched managed object belongs. This results in setting the `assetParents` property with additional information about the groups.</param>
		/// <param name="withParents">When set to `true`, the returned references of child parents will return the device's parents (if any). Otherwise, it will be an empty array.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<ManagedObjectCollection<TManagedObject>?> GetManagedObjects<TManagedObject>(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, int? currentPage = null, string? fragmentType = null, List<string>? ids = null, bool? onlyRoots = null, string? owner = null, int? pageSize = null, string? q = null, string? query = null, bool? skipChildrenNames = null, string? text = null, string? type = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withGroups = null, bool? withParents = null, bool? withTotalElements = null, bool? withTotalPages = null) where TManagedObject : ManagedObject;
		
		/// <summary>
		/// Create a managed object<br/>
		/// Create a managed object, for example, a device with temperature measurements support or a binary switch.<br> In general, each managed object may consist of:  *  A unique identifier that references the object. *  The name of the object. *  The most specific type of the managed object. *  A time stamp showing the last update. *  Fragments with specific meanings, for example, `c8y_IsDevice`, `c8y_SupportedOperations`. *  Any additional custom fragments.  Imagine, for example, that you want to describe electric meters from different vendors. Depending on the make of the meter, one may have a relay and one may be capable to measure a single phase or three phases (for example, a three-phase electricity sensor). A fragment `c8y_ThreePhaseElectricitySensor` would identify such an electric meter. Devices' characteristics are identified by storing fragments for each of them.  > **&#9432; Info:** For more details about fragments with specific meanings, review the sections [Device management library](#section/Device-management-library) and [Sensor library](#section/Sensor-library).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> ROLE_INVENTORY_CREATE </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A managed object was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<TManagedObject?> CreateManagedObject<TManagedObject>(TManagedObject body, string xCumulocityProcessingMode) where TManagedObject : ManagedObject;
		
		/// <summary>
		/// Retrieve the total number of managed objects<br/>
		/// Retrieve the total number of managed objects (for example, devices, assets, etc.) registered in your tenant, or a subset based on queries.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ is not required, but if the current user doesn't have this role, the response will contain the number of inventory objects accessible for the user. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the number of managed objects is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="childAdditionId">Search for a specific child addition and list all the groups to which it belongs.</param>
		/// <param name="childAssetId">Search for a specific child asset and list all the groups to which it belongs.</param>
		/// <param name="childDeviceId">Search for a specific child device and list all the groups to which it belongs.</param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state.</param>
		/// <param name="ids">The managed object IDs to search for (comma separated).</param>
		/// <param name="owner">Username of the owner of the managed objects.</param>
		/// <param name="text">Search for managed objects where any property value is equal to the given one. Only string values are supported.</param>
		/// <param name="type">The type of managed object to search for.</param>
		/// <returns></returns>
		Task<int> GetNumberOfManagedObjects(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, string? fragmentType = null, List<string>? ids = null, string? owner = null, string? text = null, string? type = null) ;
		
		/// <summary>
		/// Retrieve a specific managed object<br/>
		/// Retrieve a specific managed object (for example, device, group, template) by a given ID.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the object is sent in the response.</description>
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
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="skipChildrenNames">When set to `true`, the returned references of child devices won't contain their names.</param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to `false` to improve query performance.</param>
		/// <param name="withChildrenCount">When set to `true`, the returned result will contain the total number of children in the respective objects (`childAdditions`, `childAssets` and `childDevices`).</param>
		/// <param name="withParents">When set to `true`, the returned references of child parents will return the device's parents (if any). Otherwise, it will be an empty array.</param>
		/// <returns></returns>
		Task<TManagedObject?> GetManagedObject<TManagedObject>(string id, bool? skipChildrenNames = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withParents = null) where TManagedObject : ManagedObject;
		
		/// <summary>
		/// Update a specific managed object<br/>
		/// Update a specific managed object (for example, device) by a given ID.  For example, if you want to specify that your managed object is a device, you must add the fragment `c8y_IsDevice`.  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>A managed object was updated.</description>
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
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<TManagedObject?> UpdateManagedObject<TManagedObject>(TManagedObject body, string id, string xCumulocityProcessingMode) where TManagedObject : ManagedObject;
		
		/// <summary>
		/// Remove a specific managed object<br/>
		/// Remove a specific managed object (for example, device) by a given ID.  > **&#9432; Info:** Inventory DELETE requests are not synchronous. The response could be returned before the delete request has been completed. This may happen especially when the deleted managed object has a lot of associated data. After sending the request, the platform starts deleting the associated data in an asynchronous way. Finally, the requested managed object is deleted after all associated data has been deleted.  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A managed object was removed.</description>
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
		/// <term>HTTP 409</term>
		/// <description>Conflict – The managed object is associated to other objects, for example child devices.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <param name="cascade">When set to `true` and the managed object is a device or group, all the hierarchy will be deleted.</param>
		/// <param name="forceCascade">When set to `true` all the hierarchy will be deleted without checking the type of managed object. It takes precedence over the parameter `cascade`.</param>
		/// <param name="withDeviceUser">When set to `true` and the managed object is a device, it deletes the associated device user (credentials).</param>
		Task<System.IO.Stream> DeleteManagedObject(string id, string xCumulocityProcessingMode, bool? cascade = null, bool? forceCascade = null, bool? withDeviceUser = null) ;
		
		/// <summary>
		/// Retrieve the latest availability date of a specific managed object<br/>
		/// Retrieve the date when a specific managed object (by a given ID) sent the last message to Cumulocity IoT.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the date is sent in the response.</description>
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
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		Task<System.DateTime> GetLatestAvailability(string id) ;
		
		/// <summary>
		/// Retrieve all supported measurement fragments of a specific managed object<br/>
		/// Retrieve all measurement types of a specific managed object by a given ID.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all measurement types are sent in the response.</description>
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
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		Task<SupportedMeasurements?> GetSupportedMeasurements(string id) ;
		
		/// <summary>
		/// Retrieve all supported measurement fragments and series of a specific managed object<br/>
		/// Retrieve all supported measurement fragments and series of a specific managed object by a given ID.  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all supported measurement series are sent in the response.</description>
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
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		Task<SupportedSeries?> GetSupportedSeries(string id) ;
		
		/// <summary>
		/// Retrieve the username and state of a specific managed object<br/>
		/// Retrieve the device owner's username and state (enabled or disabled) of a specific managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_READ <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the username and state are sent in the response.</description>
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
		/// <param name="id">Unique identifier of the managed object.</param>
		/// <returns></returns>
		Task<ManagedObjectUser?> GetManagedObjectUser(string id) ;
		
		/// <summary>
		/// Update the user's details of a specific managed object<br/>
		/// Update the device owner's state (enabled or disabled) of a specific managed object (by a given ID).  <section><h5>Required roles</h5> ROLE_INVENTORY_ADMIN <b>OR</b> owner of the source <b>OR</b> MANAGE_OBJECT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The user's details of a specific managed object were updated.</description>
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
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<ManagedObjectUser?> UpdateManagedObjectUser(ManagedObjectUser body, string id, string xCumulocityProcessingMode) ;
	}
	#nullable disable
}
