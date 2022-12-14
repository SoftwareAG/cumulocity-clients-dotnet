///
/// IEventsApi.cs
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
	/// Events are used to pass real-time information through Cumulocity IoT and they come in three types: base events  when something in the sensor network happens, alarms requiring manual actions, and audit logs to store events that are security-relevant.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IEventsApi
	{
	
		/// <summary>
		/// Retrieve all events<br/>
		/// Retrieve all events on your tenant.  In case of executing [range queries](https://en.wikipedia.org/wiki/Range_query_(database)) between an upper and lower boundary, for example, querying using `dateFrom`–`dateTo` or `createdFrom`–`createdTo`, the newest registered events are returned first. It is possible to change the order using the query parameter `revert=true`.  <section><h5>Required roles</h5> ROLE_EVENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all events are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="createdFrom">Start date or date and time of the event's creation (set by the platform during creation).</param>
		/// <param name="createdTo">End date or date and time of the event's creation (set by the platform during creation).</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the event occurrence (provided by the device).</param>
		/// <param name="dateTo">End date or date and time of the event occurrence (provided by the device).</param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state.</param>
		/// <param name="fragmentValue">Allows filtering events by the fragment's value, but only when provided together with `fragmentType`.  > **⚠️ Important:** Only fragments with a string value are supported. </param>
		/// <param name="lastUpdatedFrom">Start date or date and time of the last update made.</param>
		/// <param name="lastUpdatedTo">End date or date and time of the last update made.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="revert">If you are using a range query (that is, at least one of the `dateFrom` or `dateTo` parameters is included in the request), then setting `revert=true` will sort the results by the oldest events first. By default, the results are sorted by the newest events first. </param>
		/// <param name="source">The managed object ID to which the event is associated.</param>
		/// <param name="type">The type of event to search for.</param>
		/// <param name="withSourceAssets">When set to `true` also events for related source assets will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withSourceDevices">When set to `true` also events for related source devices will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<EventCollection<TEvent>?> GetEvents<TEvent>(System.DateTime? createdFrom = null, System.DateTime? createdTo = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? fragmentValue = null, System.DateTime? lastUpdatedFrom = null, System.DateTime? lastUpdatedTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, bool? withTotalElements = null, bool? withTotalPages = null) where TEvent : Event;
		
		/// <summary>
		/// Create an event<br/>
		/// An event must be associated with a source (managed object) identified by an ID.<br> In general, each event consists of:  *  A type to identify the nature of the event. *  A time stamp to indicate when the event was last updated. *  A description of the event. *  The managed object which originated the event.  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An event was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
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
		Task<TEvent?> CreateEvent<TEvent>(TEvent body, string? xCumulocityProcessingMode = null) where TEvent : Event;
		
		/// <summary>
		/// Remove event collections<br/>
		/// Remove event collections specified by query parameters.  DELETE requests are not synchronous. The response could be returned before the delete request has been completed. This may happen especially when the deleted event has a lot of associated data. After sending the request, the platform starts deleting the associated data in an asynchronous way. Finally, the requested event is deleted after all associated data has been deleted.  > **⚠️ Important:** Note that it is possible to call this endpoint without providing any parameter - it will result in deleting all events and it is not recommended.  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A collection of events was removed.</description>
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
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <param name="createdFrom">Start date or date and time of the event's creation (set by the platform during creation).</param>
		/// <param name="createdTo">End date or date and time of the event's creation (set by the platform during creation).</param>
		/// <param name="dateFrom">Start date or date and time of the event occurrence (provided by the device).</param>
		/// <param name="dateTo">End date or date and time of the event occurrence (provided by the device).</param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state.</param>
		/// <param name="source">The managed object ID to which the event is associated.</param>
		/// <param name="type">The type of event to search for.</param>
		Task<System.IO.Stream> DeleteEvents(string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null) ;
		
		/// <summary>
		/// Retrieve a specific event<br/>
		/// Retrieve a specific event by a given ID.  <section><h5>Required roles</h5> ROLE_EVENT_READ <b>OR</b> owner of the source <b>OR</b> EVENT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the event is sent in the response.</description>
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
		/// <returns></returns>
		Task<TEvent?> GetEvent<TEvent>(string id) where TEvent : Event;
		
		/// <summary>
		/// Update a specific event<br/>
		/// Update a specific event by a given ID. Only its text description and custom fragments can be updated.  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An event was updated.</description>
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
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the event.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<TEvent?> UpdateEvent<TEvent>(TEvent body, string id, string? xCumulocityProcessingMode = null) where TEvent : Event;
		
		/// <summary>
		/// Remove a specific event<br/>
		/// Remove a specific event by a given ID.  <section><h5>Required roles</h5> ROLE_EVENT_ADMIN <b>OR</b> owner of the source <b>OR</b> EVENT_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>An event was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Event not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the event.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> DeleteEvent(string id, string? xCumulocityProcessingMode = null) ;
	}
	#nullable disable
}
