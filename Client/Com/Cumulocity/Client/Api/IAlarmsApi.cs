//
// IAlarmsApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// An alarm represents an event that requires manual action, for example, when the temperature of a fridge increases above a particular threshold. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public interface IAlarmsApi
{

	/// <summary> 
	/// Retrieve all alarms <br />
	/// Retrieve all alarms on your tenant, or a specific subset based on queries. The results are sorted by the newest alarms first. <br />
	/// <br /> Query parameters <br />
	/// The query parameter <c>withTotalPages</c> only works when the user has the ROLE_ALARM_READ role, otherwise it is ignored. <br />
	/// 
	/// <br /> Required roles <br />
	///  The role ROLE_ALARM_READ is not required, but if a user has this role, all the alarms on the tenant are returned. If a user has access to alarms through inventory roles, only those alarms are returned. 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and all alarms are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="createdFrom">Start date or date and time of the alarm creation. <br /></param>
	/// <param name="createdTo">End date or date and time of the alarm creation. <br /></param>
	/// <param name="currentPage">The current page of the paginated results. <br /></param>
	/// <param name="dateFrom">Start date or date and time of the alarm occurrence. <br /></param>
	/// <param name="dateTo">End date or date and time of the alarm occurrence. <br /></param>
	/// <param name="lastUpdatedFrom">Start date or date and time of the last update made. <br /></param>
	/// <param name="lastUpdatedTo">End date or date and time of the last update made. <br /></param>
	/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
	/// <param name="resolved">When set to <c>true</c> only alarms with status CLEARED will be fetched, whereas <c>false</c> will fetch all alarms with status ACTIVE or ACKNOWLEDGED. <br /></param>
	/// <param name="severity">The severity of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm severities at once, comma-separate the values. <br /></param>
	/// <param name="source">The managed object ID to which the alarm is associated. <br /></param>
	/// <param name="status">The status of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm statuses at once, comma-separate the values. <br /></param>
	/// <param name="type">The types of alarm to search for. <br />ⓘ Info: If you query for multiple alarm types at once, comma-separate the values. Space characters in alarm types must be escaped. <br /></param>
	/// <param name="withSourceAssets">When set to <c>true</c> also alarms for related source assets will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	/// <param name="withSourceDevices">When set to <c>true</c> also alarms for related source devices will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	///
	Task<AlarmCollection<TAlarm>?> GetAlarms<TAlarm>(System.DateTime? createdFrom = null, System.DateTime? createdTo = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, System.DateTime? lastUpdatedFrom = null, System.DateTime? lastUpdatedTo = null, int? pageSize = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TAlarm : Alarm;
	
	/// <summary> 
	/// Update alarm collections <br />
	/// Update alarm collections specified by query parameters. At least one query parameter is required to avoid accidentally updating all existing alarms.<br />
	/// Currently, only the status of alarms can be modified. <br />
	/// ⓘ Info: Since this operation can take considerable time, the request returns after maximum 0.5 seconds of processing, and the update operation continues as a background process in the platform. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_ALARM_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 An alarm collection was updated. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 202 An alarm collection is being updated in background. <br /> <br />
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
	/// <param name="createdFrom">Start date or date and time of the alarm creation. <br /></param>
	/// <param name="createdTo">End date or date and time of the alarm creation. <br /></param>
	/// <param name="dateFrom">Start date or date and time of the alarm occurrence. <br /></param>
	/// <param name="dateTo">End date or date and time of the alarm occurrence. <br /></param>
	/// <param name="resolved">When set to <c>true</c> only alarms with status CLEARED will be fetched, whereas <c>false</c> will fetch all alarms with status ACTIVE or ACKNOWLEDGED. <br /></param>
	/// <param name="severity">The severity of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm severities at once, comma-separate the values. <br /></param>
	/// <param name="source">The managed object ID to which the alarm is associated. <br /></param>
	/// <param name="status">The status of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm statuses at once, comma-separate the values. <br /></param>
	/// <param name="withSourceAssets">When set to <c>true</c> also alarms for related source assets will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	/// <param name="withSourceDevices">When set to <c>true</c> also alarms for related source devices will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	///
	Task<string?> UpdateAlarms<TAlarm>(TAlarm body, string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, bool? withSourceAssets = null, bool? withSourceDevices = null, CancellationToken cToken = default) where TAlarm : Alarm;
	
	/// <summary> 
	/// Create an alarm <br />
	/// An alarm must be associated with a source (managed object) identified by ID.<br />
	/// In general, each alarm may consist of: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>A status showing whether the alarm is ACTIVE, ACKNOWLEDGED or CLEARED. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>A time stamp to indicate when the alarm was last updated. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The severity of the alarm: CRITICAL, MAJOR, MINOR or WARNING. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>A history of changes to the event in form of audit logs. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// <br /> Alarm suppression <br />
	/// If the source device is in maintenance mode, the alarm is not created and not reported to the Cumulocity IoT event processing engine. When sending a POST request to create a new alarm and if the source device is in maintenance mode, the self link of the alarm will be: <br />
	/// <![CDATA[
	/// "self": "https://<TENANT_DOMAIN>/alarm/alarms/null"
	/// ]]>
	/// <br /> Alarm de-duplication <br />
	/// If an ACTIVE or ACKNOWLEDGED alarm with the same source and type exists, no new alarm is created.Instead, the existing alarm is updated by incrementing the <c>count</c> property; the <c>time</c> property is also updated.Any other changes are ignored, and the alarm history is not updated. Alarms with status CLEARED are not de-duplicated.The first occurrence of the alarm is recorded in the <c>firstOccurrenceTime</c> property. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_ALARM_ADMIN OR owner of the source OR ALARM_ADMIN permission on the source 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 An alarm was created. <br /> <br />
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
	Task<TAlarm?> CreateAlarm<TAlarm>(TAlarm body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TAlarm : Alarm;
	
	/// <summary> 
	/// Remove alarm collections <br />
	/// Remove alarm collections specified by query parameters. <br />
	/// ⚠️ Important: Note that it is possible to call this endpoint without providing any parameter - it will result in deleting all alarms and it is not recommended.Also note that DELETE requests are not synchronous. The response could be returned before the delete request has been completed. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_ALARM_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 A collection of alarms was removed. <br /> <br />
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
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="createdFrom">Start date or date and time of the alarm creation. <br /></param>
	/// <param name="createdTo">End date or date and time of the alarm creation. <br /></param>
	/// <param name="dateFrom">Start date or date and time of the alarm occurrence. <br /></param>
	/// <param name="dateTo">End date or date and time of the alarm occurrence. <br /></param>
	/// <param name="resolved">When set to <c>true</c> only alarms with status CLEARED will be fetched, whereas <c>false</c> will fetch all alarms with status ACTIVE or ACKNOWLEDGED. <br /></param>
	/// <param name="severity">The severity of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm severities at once, comma-separate the values. <br /></param>
	/// <param name="source">The managed object ID to which the alarm is associated. <br /></param>
	/// <param name="status">The status of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm statuses at once, comma-separate the values. <br /></param>
	/// <param name="type">The types of alarm to search for. <br />ⓘ Info: If you query for multiple alarm types at once, comma-separate the values. Space characters in alarm types must be escaped. <br /></param>
	/// <param name="withSourceAssets">When set to <c>true</c> also alarms for related source assets will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	/// <param name="withSourceDevices">When set to <c>true</c> also alarms for related source devices will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	///
	Task<string?> DeleteAlarms(string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve a specific alarm <br />
	/// Retrieve a specific alarm by a given ID. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_ALARM_READ OR owner of the source OR ALARM_READ permission on the source 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the alarm is sent in the response. <br /> <br />
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
	/// 		<description>HTTP 404 Alarm not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the alarm. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TAlarm?> GetAlarm<TAlarm>(string id, CancellationToken cToken = default) where TAlarm : Alarm;
	
	/// <summary> 
	/// Update a specific alarm <br />
	/// Update a specific alarm by a given ID.Only text, status, severity and custom properties can be modified. A request will be rejected when non-modifiable properties are provided in the request body. <br />
	/// ⓘ Info: Changes to alarms will generate a new audit record. The audit record will include the username and application that triggered the update, if applicable. If the update operation doesn’t change anything (that is, the request body contains data that is identical to the already present in the database), there will be no audit record added and no notifications will be sent. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_ALARM_ADMIN OR owner of the source OR ALARM_ADMIN permission on the source 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 An alarm was updated. <br /> <br />
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
	/// 		<description>HTTP 404 Alarm not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="id">Unique identifier of the alarm. <br /></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TAlarm?> UpdateAlarm<TAlarm>(TAlarm body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TAlarm : Alarm;
	
	/// <summary> 
	/// Retrieve the total number of alarms <br />
	/// Count the total number of active alarms on your tenant. <br />
	/// 
	/// <br /> Required roles <br />
	///  The role ROLE_ALARM_READ is not required, but if a user has this role, all the alarms on the tenant are counted. Otherwise, inventory role permissions are used to count the alarms and the limit is 100. 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the number of active alarms is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="dateFrom">Start date or date and time of the alarm occurrence. <br /></param>
	/// <param name="dateTo">End date or date and time of the alarm occurrence. <br /></param>
	/// <param name="resolved">When set to <c>true</c> only alarms with status CLEARED will be fetched, whereas <c>false</c> will fetch all alarms with status ACTIVE or ACKNOWLEDGED. <br /></param>
	/// <param name="severity">The severity of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm severities at once, comma-separate the values. <br /></param>
	/// <param name="source">The managed object ID to which the alarm is associated. <br /></param>
	/// <param name="status">The status of the alarm to search for. <br />ⓘ Info: If you query for multiple alarm statuses at once, comma-separate the values. <br /></param>
	/// <param name="type">The types of alarm to search for. <br />ⓘ Info: If you query for multiple alarm types at once, comma-separate the values. Space characters in alarm types must be escaped. <br /></param>
	/// <param name="withSourceAssets">When set to <c>true</c> also alarms for related source assets will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	/// <param name="withSourceDevices">When set to <c>true</c> also alarms for related source devices will be included in the request. When this parameter is provided a <c>source</c> must be specified. <br /></param>
	///
	Task<int> GetNumberOfAlarms(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, CancellationToken cToken = default) ;
}
