///
/// IManagedObjectsApi.cs
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
	/// The inventory stores devices and other assets relevant to your IoT solution. We refer to them as managed objects and such can be “smart objects”, for example, smart electricity meters, home automation gateways or GPS devices. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IManagedObjectsApi
	{
	
		/// <summary> 
		/// Retrieve all managed objects <br />
		/// Retrieve all managed objects (for example, devices, assets, etc.) registered in your tenant, or a subset based on queries. <br />
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the collection of objects is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Invalid data was sent. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="childAdditionId">Search for a specific child addition and list all the groups to which it belongs. <br /></param>
		/// <param name="childAssetId">Search for a specific child asset and list all the groups to which it belongs. <br /></param>
		/// <param name="childDeviceId">Search for a specific child device and list all the groups to which it belongs. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state. <br /></param>
		/// <param name="ids">The managed object IDs to search for. <br />ⓘ Info: If you query for multiple IDs at once, comma-separate the values. <br /></param>
		/// <param name="onlyRoots">When set to <c>true</c> it returns managed objects which don't have any parent. If the current user doesn't have access to the parent, this is also root for the user. <br /></param>
		/// <param name="owner">Username of the owner of the managed objects. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="q">Similar to the parameter <c>query</c>, but it assumes that this is a device query request and it adds automatically the search criteria <c>fragmentType=c8y_IsDevice</c>. <br /></param>
		/// <param name="query">Use query language to perform operations and/or filter the results. Details about the properties and supported operations can be found in <see href="#tag/Query-language" langword="Query language" />. <br /></param>
		/// <param name="skipChildrenNames">When set to <c>true</c>, the returned references of child devices won't contain their names. <br /></param>
		/// <param name="text">Search for managed objects where any property value is equal to the given one. Only string values are supported. <br /></param>
		/// <param name="type">The type of managed object to search for. <br /></param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to <c>false</c> to improve query performance. <br /></param>
		/// <param name="withChildrenCount">When set to <c>true</c>, the returned result will contain the total number of children in the respective objects (<c>childAdditions</c>, <c>childAssets</c> and <c>childDevices</c>). <br /></param>
		/// <param name="withGroups">When set to <c>true</c> it returns additional information about the groups to which the searched managed object belongs. This results in setting the <c>assetParents</c> property with additional information about the groups. <br /></param>
		/// <param name="withParents">When set to <c>true</c>, the returned references of child parents will return the device's parents (if any). Otherwise, it will be an empty array. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectCollection<TManagedObject>?> GetManagedObjects<TManagedObject>(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, int? currentPage = null, string? fragmentType = null, List<string>? ids = null, bool? onlyRoots = null, string? owner = null, int? pageSize = null, string? q = null, string? query = null, bool? skipChildrenNames = null, string? text = null, string? type = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withGroups = null, bool? withParents = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Create a managed object <br />
		/// Create a managed object, for example, a device with temperature measurements support or a binary switch.<br />
		/// In general, each managed object may consist of: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>A unique identifier that references the object. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>The name of the object. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>The most specific type of the managed object. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>A time stamp showing the last update. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Fragments with specific meanings, for example, <c>c8y_IsDevice</c>, <c>c8y_SupportedOperations</c>. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>Any additional custom fragments. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// Imagine, for example, that you want to describe electric meters from different vendors. Depending on the make of the meter, one may have a relay and one may be capable to measure a single phase or three phases (for example, a three-phase electricity sensor). A fragment <c>c8y_ThreePhaseElectricitySensor</c> would identify such an electric meter. Devices' characteristics are identified by storing fragments for each of them. <br />
		/// ⓘ Info: For more details about fragments with specific meanings, review the sections <see href="#section/Device-management-library" langword="Device management library" /> and <see href="#section/Sensor-library" langword="Sensor library" />. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR ROLE_INVENTORY_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A managed object was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TManagedObject?> CreateManagedObject<TManagedObject>(TManagedObject body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Retrieve the total number of managed objects <br />
		/// Retrieve the total number of managed objects (for example, devices, assets, etc.) registered in your tenant, or a subset based on queries. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ is not required, but if the current user doesn't have this role, the response will contain the number of inventory objects accessible for the user. 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the number of managed objects is sent in the response. <br /> <br />
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
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state. <br /></param>
		/// <param name="ids">The managed object IDs to search for. <br />ⓘ Info: If you query for multiple IDs at once, comma-separate the values. <br /></param>
		/// <param name="owner">Username of the owner of the managed objects. <br /></param>
		/// <param name="text">Search for managed objects where any property value is equal to the given one. Only string values are supported. <br /></param>
		/// <param name="type">The type of managed object to search for. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<int> GetNumberOfManagedObjects(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, string? fragmentType = null, List<string>? ids = null, string? owner = null, string? text = null, string? type = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific managed object <br />
		/// Retrieve a specific managed object (for example, device, group, template) by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the object is sent in the response. <br /> <br />
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
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="skipChildrenNames">When set to <c>true</c>, the returned references of child devices won't contain their names. <br /></param>
		/// <param name="withChildren">Determines if children with ID and name should be returned when fetching the managed object. Set it to <c>false</c> to improve query performance. <br /></param>
		/// <param name="withChildrenCount">When set to <c>true</c>, the returned result will contain the total number of children in the respective objects (<c>childAdditions</c>, <c>childAssets</c> and <c>childDevices</c>). <br /></param>
		/// <param name="withParents">When set to <c>true</c>, the returned references of child parents will return the device's parents (if any). Otherwise, it will be an empty array. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TManagedObject?> GetManagedObject<TManagedObject>(string id, bool? skipChildrenNames = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withParents = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Update a specific managed object <br />
		/// Update a specific managed object (for example, device) by a given ID. <br />
		/// For example, if you want to specify that your managed object is a device, you must add the fragment <c>c8y_IsDevice</c>. <br />
		/// The endpoint can also be used as a device availability heartbeat.If you only specifiy the <c>id</c>, it updates the date when the last message was received and no other property.The response then only contains the <c>id</c> instead of the full managed object. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source OR MANAGE_OBJECT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A managed object was updated. <br /> <br />
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
		Task<TManagedObject?> UpdateManagedObject<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject;
		
		/// <summary> 
		/// Remove a specific managed object <br />
		/// Remove a specific managed object (for example, device) by a given ID. <br />
		/// ⓘ Info: Inventory DELETE requests are not synchronous. The response could be returned before the delete request has been completed. This may happen especially when the deleted managed object has a lot of associated data. After sending the request, the platform starts deleting the associated data in an asynchronous way. Finally, the requested managed object is deleted after all associated data has been deleted. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source OR MANAGE_OBJECT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A managed object was removed. <br /> <br />
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
		/// 		<description>HTTP 409 Conflict – The managed object is associated to other objects, for example child devices. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cascade">When set to <c>true</c> and the managed object is a device or group, all the hierarchy will be deleted. <br /></param>
		/// <param name="forceCascade">When set to <c>true</c> all the hierarchy will be deleted without checking the type of managed object. It takes precedence over the parameter <c>cascade</c>. <br /></param>
		/// <param name="withDeviceUser">When set to <c>true</c> and the managed object is a device, it deletes the associated device user (credentials). <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteManagedObject(string id, string? xCumulocityProcessingMode = null, bool? cascade = null, bool? forceCascade = null, bool? withDeviceUser = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve the latest availability date of a specific managed object <br />
		/// Retrieve the date when a specific managed object (by a given ID) sent the last message to Cumulocity IoT. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the date is sent in the response. <br /> <br />
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
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.DateTime> GetLatestAvailability(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all supported measurement fragments of a specific managed object <br />
		/// Retrieve all measurement types of a specific managed object by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all measurement types are sent in the response. <br /> <br />
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
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<SupportedMeasurements?> GetSupportedMeasurements(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all supported measurement fragments and series of a specific managed object <br />
		/// Retrieve all supported measurement fragments and series of a specific managed object by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all supported measurement series are sent in the response. <br /> <br />
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
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<SupportedSeries?> GetSupportedSeries(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve the username and state of a specific managed object <br />
		/// Retrieve the device owner's username and state (enabled or disabled) of a specific managed object (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_READ OR owner of the source OR MANAGE_OBJECT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the username and state are sent in the response. <br /> <br />
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
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<ManagedObjectUser?> GetManagedObjectUser(string id, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update the user's details of a specific managed object <br />
		/// Update the device owner's state (enabled or disabled) of a specific managed object (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_INVENTORY_ADMIN OR owner of the source OR MANAGE_OBJECT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The user's details of a specific managed object were updated. <br /> <br />
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
		Task<ManagedObjectUser?> UpdateManagedObjectUser(ManagedObjectUser body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	}
	#nullable disable
}
