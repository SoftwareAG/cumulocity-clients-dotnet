///
/// IMeasurementsApi.cs
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
	/// Measurements are produced by reading sensor values. In some cases, this data is read in static intervals and sent to the platform (for example, temperature sensors or electrical meters). In other cases, the data is read on demand or at irregular intervals (for example, health devices such as weight scales). Regardless what kind of protocol the device supports, the agent is responsible for converting it into a "push" protocol by uploading data to Cumulocity IoT. <br />
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IMeasurementsApi
	{
	
		/// <summary> 
		/// Retrieve all measurements <br />
		/// Retrieve all measurements on your tenant, or a specific subset based on queries. <br />
		/// In case of executing <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" /> between an upper and lower boundary, for example, querying using <c>dateFrom</c>–<c>dateTo</c>, the oldest registered measurements are returned first. It is possible to change the order using the query parameter <c>revert=true</c>. <br />
		/// For large measurement collections, querying older records without filters can be slow as the server needs to scan from the beginning of the input results set before beginning to return the results. For cases when older measurements should be retrieved, it is recommended to narrow the scope by using range queries based on the time stamp reported by a device. The scope of query can also be reduced significantly when a source device is provided. <br />
		/// Review <see href="#tag/Measurements-specifics" langword="Measurements Specifics" /> for details about data streaming and response formats. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all measurements are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="dateFrom">Start date or date and time of the measurement. <br /></param>
		/// <param name="dateTo">End date or date and time of the measurement. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="revert">If you are using a range query (that is, at least one of the <c>dateFrom</c> or <c>dateTo</c> parameters is included in the request), then setting <c>revert=true</c> will sort the results by the newest measurements first.By default, the results are sorted by the oldest measurements first. <br /></param>
		/// <param name="source">The managed object ID to which the measurement is associated. <br /></param>
		/// <param name="type">The type of measurement to search for. <br /></param>
		/// <param name="valueFragmentSeries">The specific series to search for. <br /></param>
		/// <param name="valueFragmentType">A characteristic which identifies the measurement. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		///
		Task<MeasurementCollection<TMeasurement>?> GetMeasurements<TMeasurement>(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? revert = null, string? source = null, string? type = null, string? valueFragmentSeries = null, string? valueFragmentType = null, bool? withTotalElements = null, bool? withTotalPages = null) where TMeasurement : Measurement;
		
		/// <summary> 
		/// Create a measurement <br />
		/// A measurement must be associated with a source (managed object) identified by ID, and must specify the type of measurement and the time when it was measured by the device (for example, a thermometer). <br />
		/// Each measurement fragment is an object (for example, <c>c8y_Steam</c>) containing the actual measurements as properties. The property name represents the name of the measurement (for example, <c>Temperature</c>) and it contains two properties: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description><c>value</c> - The value of the individual measurement. The maximum precision for floating point numbers is 64-bit IEEE 754. For integers it's a 64-bit two's complement integer. The <c>value</c> is mandatory for a fragment. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description><c>unit</c> - The unit of the measurements. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// Review the <see href="#section/System-of-units" langword="System of units" /> section for details about the conversions of units. Also review the <see href="https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments" langword="Naming conventions of fragments" /> in the Concepts guide. <br />
		/// The example below uses <c>c8y_Steam</c> in the request body to illustrate a fragment for recording temperature measurements. <br />
		/// ⚠️ Important: Property names used for fragment and series must not contain whitespaces nor the special characters <c>. , * [ ] ( ) @ $</c>. This is required to ensure a correct processing and visualization of measurement series on UI graphs. <br />
		/// <br /> Create multiple measurements <br />
		/// It is also possible to create multiple measurements at once by sending a <c>measurements</c> array containing all the measurements to be created. The content type must be <c>application/vnd.com.nsn.cumulocity.measurementcollection+json</c>. <br />
		/// ⓘ Info: For more details about fragments with specific meanings, review the sections <see href="#section/Device-management-library" langword="Device management library" /> and <see href="#section/Sensor-library" langword="Sensor library" />. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_ADMIN OR owner of the source OR MEASUREMENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A measurement was created. <br /> <br />
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
		///
		Task<TMeasurement?> CreateMeasurement<TMeasurement>(TMeasurement body, string? xCumulocityProcessingMode = null) where TMeasurement : Measurement;
		
		/// <summary> 
		/// Create a measurement <br />
		/// A measurement must be associated with a source (managed object) identified by ID, and must specify the type of measurement and the time when it was measured by the device (for example, a thermometer). <br />
		/// Each measurement fragment is an object (for example, <c>c8y_Steam</c>) containing the actual measurements as properties. The property name represents the name of the measurement (for example, <c>Temperature</c>) and it contains two properties: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description><c>value</c> - The value of the individual measurement. The maximum precision for floating point numbers is 64-bit IEEE 754. For integers it's a 64-bit two's complement integer. The <c>value</c> is mandatory for a fragment. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description><c>unit</c> - The unit of the measurements. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// Review the <see href="#section/System-of-units" langword="System of units" /> section for details about the conversions of units. Also review the <see href="https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments" langword="Naming conventions of fragments" /> in the Concepts guide. <br />
		/// The example below uses <c>c8y_Steam</c> in the request body to illustrate a fragment for recording temperature measurements. <br />
		/// ⚠️ Important: Property names used for fragment and series must not contain whitespaces nor the special characters <c>. , * [ ] ( ) @ $</c>. This is required to ensure a correct processing and visualization of measurement series on UI graphs. <br />
		/// <br /> Create multiple measurements <br />
		/// It is also possible to create multiple measurements at once by sending a <c>measurements</c> array containing all the measurements to be created. The content type must be <c>application/vnd.com.nsn.cumulocity.measurementcollection+json</c>. <br />
		/// ⓘ Info: For more details about fragments with specific meanings, review the sections <see href="#section/Device-management-library" langword="Device management library" /> and <see href="#section/Sensor-library" langword="Sensor library" />. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_ADMIN OR owner of the source OR MEASUREMENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A measurement was created. <br /> <br />
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
		///
		Task<MeasurementCollection<TMeasurement>?> CreateMeasurement<TMeasurement>(MeasurementCollection<TMeasurement> body, string? xCumulocityProcessingMode = null) where TMeasurement : Measurement;
		
		/// <summary> 
		/// Remove measurement collections <br />
		/// Remove measurement collections specified by query parameters. <br />
		/// DELETE requests are not synchronous. The response could be returned before the delete request has been completed. This may happen especially when there are a lot of measurements to be deleted. <br />
		/// ⚠️ Important: Note that it is possible to call this endpoint without providing any parameter - it may result in deleting all measurements and it is not recommended. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A collection of measurements was removed. <br /> <br />
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
		/// <param name="dateFrom">Start date or date and time of the measurement. <br /></param>
		/// <param name="dateTo">End date or date and time of the measurement. <br /></param>
		/// <param name="fragmentType">A characteristic which identifies a managed object or event, for example, geolocation, electricity sensor, relay state. <br /></param>
		/// <param name="source">The managed object ID to which the measurement is associated. <br /></param>
		/// <param name="type">The type of measurement to search for. <br /></param>
		///
		Task<System.IO.Stream> DeleteMeasurements(string? xCumulocityProcessingMode = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? fragmentType = null, string? source = null, string? type = null) ;
		
		/// <summary> 
		/// Retrieve a specific measurement <br />
		/// Retrieve a specific measurement by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_READ OR owner of the source OR MEASUREMENT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the measurement is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Measurement not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the measurement. <br /></param>
		///
		Task<TMeasurement?> GetMeasurement<TMeasurement>(string id) where TMeasurement : Measurement;
		
		/// <summary> 
		/// Remove a specific measurement <br />
		/// Remove a specific measurement by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_ADMIN OR owner of the source OR MEASUREMENT_ADMIN permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A measurement was removed. <br /> <br />
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
		/// 		<description>HTTP 404 Measurement not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the measurement. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		///
		Task<System.IO.Stream> DeleteMeasurement(string id, string? xCumulocityProcessingMode = null) ;
		
		/// <summary> 
		/// Retrieve a list of series and their values <br />
		/// Retrieve a list of series (all or only those matching the specified names) and their values within a given period of a specific managed object (source).<br />
		/// A series is any fragment in measurement that contains a <c>value</c> property. <br />
		/// It is possible to fetch aggregated results using the <c>aggregationType</c> parameter. If the aggregation is not specified, the result will contain no more than 5000 values. <br />
		/// ⚠️ Important: For the aggregation to be done correctly, a device shall always use the same time zone when it sends dates. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_MEASUREMENT_READ OR owner of the source OR MEASUREMENT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the series are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="aggregationType">Fetch aggregated results as specified. <br /></param>
		/// <param name="dateFrom">Start date or date and time of the measurement. <br /></param>
		/// <param name="dateTo">End date or date and time of the measurement. <br /></param>
		/// <param name="revert">If you are using a range query (that is, at least one of the <c>dateFrom</c> or <c>dateTo</c> parameters is included in the request), then setting <c>revert=true</c> will sort the results by the newest measurements first.By default, the results are sorted by the oldest measurements first. <br /></param>
		/// <param name="series">The specific series to search for. <br />ⓘ Info: If you query for multiple series at once, comma-separate the values. <br /></param>
		/// <param name="source">The managed object ID to which the measurement is associated. <br /></param>
		///
		Task<MeasurementSeries?> GetMeasurementSeries(string? aggregationType = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? revert = null, List<string>? series = null, string? source = null) ;
	}
	#nullable disable
}
