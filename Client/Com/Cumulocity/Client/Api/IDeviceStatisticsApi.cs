///
/// IDeviceStatisticsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// Device statistics are collected for each inventory object with at least one measurement, event or alarm. There are no additional checks if the inventory object is marked as device using the <c>c8y_IsDevice</c> fragment. When the first measurement, event or alarm is created for a specific inventory object, Cumulocity IoT is always considering this as a device and starts counting. <br />
	/// Device statistics are counted with daily and monthy rate. All requests are considered when counting device statistics, no matter which processing mode is used. <br />
	/// The following requests are counted: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>Alarm creation and update <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Event creation and update <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Measurement creation <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Bulk measurement creation is counted as multiple requests <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Bulk alarm status update is counted as multiple requests <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>MQTT and SmartREST requests with multiple rows are counted as multiple requests <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// <br /> Frequently asked questions <br />
	/// <br /> Are operations on device firmware counted? <br />
	/// No, device configuration and firmware update operate on inventory objects, hence they are not counted. <br />
	/// <br /> Are requests done by the UI applications, for example, when browsing device details, counted? <br />
	/// No, viewing device details performs only GET requests which are not counted. <br />
	/// <br /> Is the clear alarm operation done from the UI counted? <br />
	/// Yes, a clear alarm operation in fact performs an alarm update operation and it will be counted as device request. <br />
	/// <br /> Is there any operation performed on the device which is counted? <br />
	/// Yes, retrieving device logs requires from the device to create an event and attach a binary with logs to it. Those are two separate requests and both are counted. <br />
	/// <br /> When I have a device with children are the requests counted always to the root device or separately for each child? <br />
	/// Separately for each child. <br />
	/// </summary>
	///
	#nullable enable
	public interface IDeviceStatisticsApi
	{
	
		/// <summary> 
		/// Retrieve monthly device statistics <br />
		/// Retrieve monthly device statistics from a specific tenant (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_STATISTICS_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the devices statistics are sent in the response. <br /> <br />
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
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="date">Date (format YYYY-MM-dd) of the queried month (the day value is ignored). <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="deviceId">The ID of the device to search for. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<DeviceStatisticsCollection?> GetMonthlyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve daily device statistics <br />
		/// Retrieve daily device statistics from a specific tenant (by a given ID). <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_STATISTICS_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the devices statistics are sent in the response. <br /> <br />
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
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		/// <param name="date">Date (format YYYY-MM-dd) of the queried day. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="deviceId">The ID of the device to search for. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<DeviceStatisticsCollection?> GetDailyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
	}
	#nullable disable
}
