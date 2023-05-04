///
/// IEventsApi.cs
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
	/// Events are used to pass real-time information through Cumulocity IoT. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IEventsApi
	{
	
		/// <summary> 
		/// Retrieve all events <br />
		/// Retrieve all events on your tenant. <br />
		/// In case of executing <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" /> between an upper and lower boundary, for example, querying using <c>dateFrom</c>–<c>dateTo</c> or <c>createdFrom</c>–<c>createdTo</c>, the newest registered events are returned first. It is possible to change the order using the query parameter <c>revert=true</c>. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all events are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="createdFrom">Start date or date and time of the event's creation (set by the platform during creation). <br /></param>
		/// <param name="createdTo">End date or date and time of the event's creation (set by the platform during creation). <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="dateFrom">Start date or date and time of the event occurrence (provided by the device). <br /></param>
		/// <param name="dateTo">End date or date and time of the event occurrence (provided by the device). <br /></param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state. <br /></param>
		/// <param name="fragmentValue">Allows filtering events by the fragment's value, but only when provided together with <c>fragmentType</c>. <br />⚠️ Important: Only fragments with a string value are supported. <br /></param>
		/// <param name="lastUpdatedFrom">Start date or date and time of the last update made. <br /></param>
		/// <param name="lastUpdatedTo">End date or date and time of the last update made. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="revert">If you are using a range query (that is, at least one of the <c>dateFrom</c> or <c>dateTo</c> parameters is included in the request), then setting <c>revert=true</c> will sort the results by the oldest events first.By default, the results are sorted by the newest events first. <br /></param>
		/// <param name="source">The managed object ID to which the event is associated. <br /></param>
		/// <param name="type">The type of event to search for. <br /></param>
		/// <param name="withSourceAssets">When set to <c>true</c> also events for related source assets will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
		/// <param name="withSourceDevices">When set to <c>true</c> also events for related source devices will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<EventCollection<TEvent>?> GetEvents<TEvent>(System.DateTime? createdFrom = null, System.DateTime? createdTo = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? fragmentValue = null, System.DateTime? lastUpdatedFrom = null, System.DateTime? lastUpdatedTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TEvent : Event;
		
		/// <summary> 
		/// Create an event <br />
		/// An event must be associated with a source (managed object) identified by an ID.<br />
		/// In general, each event consists of: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>A type to identify the nature of the event. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>A time stamp to indicate when the event was last updated. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>A description of the event. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>The managed object which originated the event. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 An event was created. <br /> <br />
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
		Task<TEvent?> CreateEvent<TEvent>(TEvent body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TEvent : Event;
		
		/// <summary> 
		/// Remove event collections <br />
		/// Remove event collections specified by query parameters. <br />
		/// DELETE requests are not synchronous. The response could be returned before the delete request has been completed. This may happen especially when the deleted event has a lot of associated data. After sending the request, the platform starts deleting the associated data in an asynchronous way. Finally, the requested event is deleted after all associated data has been deleted. <br />
		/// ⚠️ Important: DELETE requires at least one of the following parameters: <c>source</c>, <c>dateFrom</c>, <c>dateTo</c>, <c>createdFrom</c>, <c>createdTo</c>. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A collection of events was removed. <br /> <br />
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
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="createdFrom">Start date or date and time of the event's creation (set by the platform during creation). <br /></param>
		/// <param name="createdTo">End date or date and time of the event's creation (set by the platform during creation). <br /></param>
		/// <param name="dateFrom">Start date or date and time of the event occurrence (provided by the device). <br /></param>
		/// <param name="dateTo">End date or date and time of the event occurrence (provided by the device). <br /></param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state. <br /></param>
		/// <param name="source">The managed object ID to which the event is associated. <br /></param>
		/// <param name="type">The type of event to search for. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteEvents(string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve a specific event <br />
		/// Retrieve a specific event by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_READ OR owner of the source OR EVENT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the event is sent in the response. <br /> <br />
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
		Task<TEvent?> GetEvent<TEvent>(string id, CancellationToken cToken = default) where TEvent : Event;
		
		/// <summary> 
		/// Update a specific event <br />
		/// Update a specific event by a given ID. Only its text description and custom fragments can be updated. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An event was updated. <br /> <br />
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
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TEvent?> UpdateEvent<TEvent>(TEvent body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TEvent : Event;
		
		/// <summary> 
		/// Remove a specific event <br />
		/// Remove a specific event by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_EVENT_ADMIN OR owner of the source OR EVENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 An event was removed. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 Event not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the event. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteEvent(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	}
	#nullable disable
}
