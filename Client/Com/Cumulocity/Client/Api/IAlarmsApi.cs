///
/// IAlarmsApi.cs
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
	/// An alarm represents an event that requires manual action, for example, when the temperature of a fridge increases above a particular threshold.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IAlarmsApi
	{
	
		/// <summary>
		/// Retrieve all alarms<br/>
		/// Retrieve all alarms on your tenant, or a specific subset based on queries. The results are sorted by the newest alarms first.  #### Query parameters  The query parameter `withTotalPages` only works when the user has the ROLE_ALARM_READ role, otherwise it is ignored.  <section><h5>Required roles</h5> The role ROLE_ALARM_READ is not required, but if a user has this role, all the alarms on the tenant are returned. If a user has access to alarms through inventory roles, only those alarms are returned. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all alarms are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="createdFrom">Start date or date and time of the alarm creation.</param>
		/// <param name="createdTo">End date or date and time of the alarm creation.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the alarm occurrence.</param>
		/// <param name="dateTo">End date or date and time of the alarm occurrence.</param>
		/// <param name="lastUpdatedFrom">Start date or date and time of the last update made.</param>
		/// <param name="lastUpdatedTo">End date or date and time of the last update made.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="resolved">When set to `true` only alarms with status CLEARED will be fetched, whereas `false` will fetch all alarms with status ACTIVE or ACKNOWLEDGED.</param>
		/// <param name="severity">The severity of the alarm to search for.</param>
		/// <param name="source">The managed object ID to which the alarm is associated.</param>
		/// <param name="status">The status of the alarm to search for.</param>
		/// <param name="type">The types of alarm to search for (comma separated).</param>
		/// <param name="withSourceAssets">When set to `true` also alarms for related source assets will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withSourceDevices">When set to `true` also alarms for related source devices will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<AlarmCollection<TAlarm>?> GetAlarms<TAlarm>(System.DateTime? createdFrom = null, System.DateTime? createdTo = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, System.DateTime? lastUpdatedFrom = null, System.DateTime? lastUpdatedTo = null, int? pageSize = null, bool? resolved = null, string? severity = null, string? source = null, string? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, bool? withTotalElements = null, bool? withTotalPages = null) where TAlarm : Alarm;
		
		/// <summary>
		/// Update alarm collections<br/>
		/// Update alarm collections specified by query parameters. At least one query parameter is required to avoid accidentally updating all existing alarms.<br> Currently, only the status of alarms can be modified.  > **&#9432; Info:** Since this operation can take considerable time, the request returns after maximum 0.5 seconds of processing, and the update operation continues as a background process in the platform.  <section><h5>Required roles</h5> ROLE_ALARM_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An alarm collection was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 202</term>
		/// <description>An alarm collection is being updated in background.</description>
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
		/// <param name="createdFrom">Start date or date and time of the alarm creation.</param>
		/// <param name="createdTo">End date or date and time of the alarm creation.</param>
		/// <param name="dateFrom">Start date or date and time of the alarm occurrence.</param>
		/// <param name="dateTo">End date or date and time of the alarm occurrence.</param>
		/// <param name="resolved">When set to `true` only alarms with status CLEARED will be fetched, whereas `false` will fetch all alarms with status ACTIVE or ACKNOWLEDGED.</param>
		/// <param name="severity">The severity of the alarm to search for.</param>
		/// <param name="source">The managed object ID to which the alarm is associated.</param>
		/// <param name="status">The status of the alarm to search for.</param>
		/// <param name="withSourceAssets">When set to `true` also alarms for related source assets will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withSourceDevices">When set to `true` also alarms for related source devices will be included in the request. When this parameter is provided a `source` must be specified.</param>
		Task<System.IO.Stream> UpdateAlarms<TAlarm>(TAlarm body, string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, string? severity = null, string? source = null, string? status = null, bool? withSourceAssets = null, bool? withSourceDevices = null) where TAlarm : Alarm;
		
		/// <summary>
		/// Create an alarm<br/>
		/// An alarm must be associated with a source (managed object) identified by ID.<br> In general, each alarm may consist of:  *  A status showing whether the alarm is ACTIVE, ACKNOWLEDGED or CLEARED. *  A time stamp to indicate when the alarm was last updated. *  The severity of the alarm: CRITICAL, MAJOR, MINOR or WARNING. *  A history of changes to the event in form of audit logs.  ### Alarm suppression  If the source device is in maintenance mode, the alarm is not created and not reported to the Cumulocity IoT event processing engine. When sending a POST request to create a new alarm and if the source device is in maintenance mode, the self link of the alarm will be:  ```json "self": "https://<TENANT_DOMAIN>/alarm/alarms/null" ```  ### Alarm de-duplication  If an ACTIVE or ACKNOWLEDGED alarm with the same source and type exists, no new alarm is created. Instead, the existing alarm is updated by incrementing the `count` property; the `time` property is also updated. Any other changes are ignored, and the alarm history is not updated. Alarms with status CLEARED are not de-duplicated. The first occurrence of the alarm is recorded in the `firstOccurrenceTime` property.  <section><h5>Required roles</h5> ROLE_ALARM_ADMIN <b>OR</b> owner of the source <b>OR</b> ALARM_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An alarm was created.</description>
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
		Task<TAlarm?> CreateAlarm<TAlarm>(TAlarm body, string? xCumulocityProcessingMode = null) where TAlarm : Alarm;
		
		/// <summary>
		/// Remove alarm collections<br/>
		/// Remove alarm collections specified by query parameters.  > **⚠️ Important:** Note that it is possible to call this endpoint without providing any parameter - it will result in deleting all alarms and it is not recommended. > Also note that DELETE requests are not synchronous. The response could be returned before the delete request has been completed.  <section><h5>Required roles</h5> ROLE_ALARM_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>A collection of alarms was removed.</description>
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
		/// <param name="createdFrom">Start date or date and time of the alarm creation.</param>
		/// <param name="createdTo">End date or date and time of the alarm creation.</param>
		/// <param name="dateFrom">Start date or date and time of the alarm occurrence.</param>
		/// <param name="dateTo">End date or date and time of the alarm occurrence.</param>
		/// <param name="resolved">When set to `true` only alarms with status CLEARED will be fetched, whereas `false` will fetch all alarms with status ACTIVE or ACKNOWLEDGED.</param>
		/// <param name="severity">The severity of the alarm to search for.</param>
		/// <param name="source">The managed object ID to which the alarm is associated.</param>
		/// <param name="status">The status of the alarm to search for.</param>
		/// <param name="type">The types of alarm to search for (comma separated).</param>
		/// <param name="withSourceAssets">When set to `true` also alarms for related source assets will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withSourceDevices">When set to `true` also alarms for related source devices will be included in the request. When this parameter is provided a `source` must be specified.</param>
		Task<System.IO.Stream> DeleteAlarms(string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, string? severity = null, string? source = null, string? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null) ;
		
		/// <summary>
		/// Retrieve a specific alarm<br/>
		/// Retrieve a specific alarm by a given ID.  <section><h5>Required roles</h5> ROLE_ALARM_READ <b>OR</b> owner of the source <b>OR</b> ALARM_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the alarm is sent in the response.</description>
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
		/// <description>Alarm not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the alarm.</param>
		/// <returns></returns>
		Task<TAlarm?> GetAlarm<TAlarm>(string id) where TAlarm : Alarm;
		
		/// <summary>
		/// Update a specific alarm<br/>
		/// Update a specific alarm by a given ID. Only text, status, severity and custom properties can be modified. A request will be rejected when non-modifiable properties are provided in the request body.  > **&#9432; Info:** Changes to alarms will generate a new audit record. The audit record will include the username and application that triggered the update, if applicable. If the update operation doesn’t change anything (that is, the request body contains data that is identical to the already present in the database), there will be no audit record added and no notifications will be sent.  <section><h5>Required roles</h5> ROLE_ALARM_ADMIN <b>OR</b> owner of the source <b>OR</b> ALARM_ADMIN permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An alarm was updated.</description>
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
		/// <description>Alarm not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the alarm.</param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<TAlarm?> UpdateAlarm<TAlarm>(TAlarm body, string id, string? xCumulocityProcessingMode = null) where TAlarm : Alarm;
		
		/// <summary>
		/// Retrieve the total number of alarms<br/>
		/// Count the total number of active alarms on your tenant.  <section><h5>Required roles</h5> The role ROLE_ALARM_READ is not required, but if a user has this role, all the alarms on the tenant are counted. Otherwise, inventory role permissions are used to count the alarms and the limit is 100. </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the number of active alarms is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="dateFrom">Start date or date and time of the alarm occurrence.</param>
		/// <param name="dateTo">End date or date and time of the alarm occurrence.</param>
		/// <param name="resolved">When set to `true` only alarms with status CLEARED will be fetched, whereas `false` will fetch all alarms with status ACTIVE or ACKNOWLEDGED.</param>
		/// <param name="severity">The severity of the alarm to search for.</param>
		/// <param name="source">The managed object ID to which the alarm is associated.</param>
		/// <param name="status">The status of the alarm to search for.</param>
		/// <param name="type">The types of alarm to search for (comma separated).</param>
		/// <param name="withSourceAssets">When set to `true` also alarms for related source assets will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <param name="withSourceDevices">When set to `true` also alarms for related source devices will be included in the request. When this parameter is provided a `source` must be specified.</param>
		/// <returns></returns>
		Task<int> GetNumberOfAlarms(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, string? severity = null, string? source = null, string? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null) ;
	}
	#nullable disable
}
