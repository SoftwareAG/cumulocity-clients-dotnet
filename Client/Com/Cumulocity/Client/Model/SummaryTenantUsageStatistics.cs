///
/// SummaryTenantUsageStatistics.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// Summary of the usage statistics.
	/// </summary>
	public class SummaryTenantUsageStatistics 
	{
	
		/// <summary>
		/// Number of created alarms.
		/// </summary>
		[JsonPropertyName("alarmsCreatedCount")]
		public int? AlarmsCreatedCount { get; set; }
	
		/// <summary>
		/// Number of updates made to the alarms.
		/// </summary>
		[JsonPropertyName("alarmsUpdatedCount")]
		public int? AlarmsUpdatedCount { get; set; }
	
		/// <summary>
		/// Date of this usage statistics summary.
		/// </summary>
		[JsonPropertyName("day")]
		public System.DateTime? Day { get; set; }
	
		/// <summary>
		/// Number of devices in the tenant identified by the fragment `c8y_IsDevice`. Updated only three times a day starting at 8:57, 16:57 and 23:57.
		/// </summary>
		[JsonPropertyName("deviceCount")]
		public int? DeviceCount { get; set; }
	
		/// <summary>
		/// Number of devices which do not have child devices. Updated only three times a day starting at 8:57, 16:57 and 23:57.
		/// </summary>
		[JsonPropertyName("deviceEndpointCount")]
		public int? DeviceEndpointCount { get; set; }
	
		/// <summary>
		/// Number of requests that were issued only by devices against the tenant. Updated every 5 minutes. The following requests are not included:
		/// 
		/// * Requests made to <kbd>/user</kbd>, <kbd>/tenant</kbd> and <kbd>/application</kbd> APIs
		/// * Application related requests (with `X-Cumulocity-Application-Key` header)
		/// 
		/// </summary>
		[JsonPropertyName("deviceRequestCount")]
		public int? DeviceRequestCount { get; set; }
	
		/// <summary>
		/// Number of devices with children. Updated only three times a day starting at 8:57, 16:57 and 23:57.
		/// </summary>
		[JsonPropertyName("deviceWithChildrenCount")]
		public int? DeviceWithChildrenCount { get; set; }
	
		/// <summary>
		/// Number of created events.
		/// </summary>
		[JsonPropertyName("eventsCreatedCount")]
		public int? EventsCreatedCount { get; set; }
	
		/// <summary>
		/// Number of updates made to the events.
		/// </summary>
		[JsonPropertyName("eventsUpdatedCount")]
		public int? EventsUpdatedCount { get; set; }
	
		/// <summary>
		/// Number of created managed objects.
		/// </summary>
		[JsonPropertyName("inventoriesCreatedCount")]
		public int? InventoriesCreatedCount { get; set; }
	
		/// <summary>
		/// Number of updates made to the managed objects.
		/// </summary>
		[JsonPropertyName("inventoriesUpdatedCount")]
		public int? InventoriesUpdatedCount { get; set; }
	
		/// <summary>
		/// Number of created measurements.
		/// 
		/// > **&#9432; Info:** Bulk creation of measurements is handled in a way that each measurement is counted individually.
		/// 
		/// </summary>
		[JsonPropertyName("measurementsCreatedCount")]
		public int? MeasurementsCreatedCount { get; set; }
	
		/// <summary>
		/// Number of requests that were made against the tenant. Updated every 5 minutes. The following requests are not included:
		/// 
		/// *  Internal SmartREST requests used to resolve templates
		/// *  Internal SLA monitoring requests
		/// *  Calls to any <kbd>/health</kbd> endpoint
		/// *  Device bootstrap process requests related to configuring and retrieving device credentials
		/// *  Microservice SDK internal calls for applications and subscriptions
		/// 
		/// </summary>
		[JsonPropertyName("requestCount")]
		public int? RequestCount { get; set; }
	
		/// <summary>
		/// Resources usage for each subscribed microservice application.
		/// </summary>
		[JsonPropertyName("resources")]
		public UsageStatisticsResources? Resources { get; set; }
	
		/// <summary>
		/// Database storage in use, specified in bytes. It is affected by your retention rules and by the regularly running database optimization functions in Cumulocity IoT. If the size decreases, it does not necessarily mean that data was deleted. Updated only three times a day starting at 8:57, 16:57 and 23:57.
		/// </summary>
		[JsonPropertyName("storageSize")]
		public int? StorageSize { get; set; }
	
		/// <summary>
		/// Names of the tenant subscribed applications. Updated only three times a day starting at 8:57, 16:57 and 23:57.
		/// </summary>
		[JsonPropertyName("subscribedApplications")]
		public List<string>? SubscribedApplications { get; set; }
	
		/// <summary>
		/// Sum of all inbound transfers.
		/// </summary>
		[JsonPropertyName("totalResourceCreateAndUpdateCount")]
		public int? TotalResourceCreateAndUpdateCount { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
