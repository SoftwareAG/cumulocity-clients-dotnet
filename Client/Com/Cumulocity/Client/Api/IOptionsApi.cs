///
/// IOptionsApi.cs
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
	/// API methods to retrieve the options configured in the tenant. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IOptionsApi
	{
	
		/// <summary> 
		/// Retrieve all options <br />
		/// Retrieve all the options available on the tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the options are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<OptionCollection?> GetOptions(int? currentPage = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Create an option <br />
		/// Create an option on your tenant. <br />
		/// Options are category-key-value tuples which store tenant configurations. Some categories of options allow the creation of new ones, while others are limited to predefined set of keys. <br />
		/// Any option of any tenant can be defined as "non-editable" by the "management" tenant; once done, any PUT or DELETE requests made on that option by the tenant owner will result in a 403 error (Unauthorized). <br />
		/// <br /> Default option categories <br />
		/// access.control <br />
		/// | Key |	Default value |	Predefined | Description ||--|--|--|--|| allow.origin | * | Yes | Comma separated list of domains allowed for execution of CORS. Wildcards are allowed (for example, <c>*.cumuclocity.com</c>) | <br />
		/// alarm.type.mapping <br />
		/// | Key  |	Predefined | Description ||--|--|--|| <ALARM_TYPE> | No | Overrides the severity and alarm text for the alarm with type <ALARM_TYPE>. The severity and text are specified as <c><ALARM_SEVERITY>\|<ALARM_TEXT></c>. If either part is empty, the value will not be overridden. If the severity is NONE, the alarm will be suppressed. Example: <c>"CRITICAL\|temperature too high"</c>| <br />
		/// <br /> Encrypted credentials <br />
		/// Adding a "credentials." prefix to the <c>key</c> will make the <c>value</c> of the option encrypted. When the option is  sent to a microservice, the "credentials." prefix is removed and the <c>value</c> is decrypted. For example: <br />
		/// <![CDATA[
		/// {
		///   "category": "secrets",
		///   "key": "credentials.mykey",
		///   "value": "myvalue"
		/// }
		/// ]]>
		/// In that particular example, the request will contain an additional header <c>"Mykey": "myvalue"</c>. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An option was created. <br /> <br />
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
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Option?> CreateOption(Option body, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Retrieve all options by category <br />
		/// Retrieve all the options (by a specified category) on your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the options are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the options. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TCategoryOptions?> GetOptionsByCategory<TCategoryOptions>(string category, CancellationToken cToken = default) where TCategoryOptions : CategoryOptions;
		
		/// <summary> 
		/// Update options by category <br />
		/// Update one or more options (by a specified category) on your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A collection of options was updated. <br /> <br />
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
		/// <param name="category">The category of the options. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TCategoryOptions?> UpdateOptionsByCategory<TCategoryOptions>(TCategoryOptions body, string category, CancellationToken cToken = default) where TCategoryOptions : CategoryOptions;
		
		/// <summary> 
		/// Retrieve a specific option <br />
		/// Retrieve a specific option (by a given category and key) on your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the option is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Option not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the options. <br /></param>
		/// <param name="key">The key of an option. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Option?> GetOption(string category, string key, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update a specific option <br />
		/// Update the value of a specific option (by a given category and key) on your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_ADMIN AND the option is editable 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 An option was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Option not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="category">The category of the options. <br /></param>
		/// <param name="key">The key of an option. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<Option?> UpdateOption(CategoryKeyOption body, string category, string key, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Remove a specific option <br />
		/// Remove a specific option (by a given category and key) on your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_OPTION_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 An option was removed. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Option not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the options. <br /></param>
		/// <param name="key">The key of an option. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> DeleteOption(string category, string key, CancellationToken cToken = default) ;
	}
	#nullable disable
}
