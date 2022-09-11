///
/// OptionsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// API methods to retrieve the options configured in the tenant.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class OptionsApi : AdaptableApi 
	{
		public OptionsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve all options<br/>
		/// Retrieve all the options available on the tenant.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the options are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		public async Task<OptionCollection?> GetOptions(int? currentPage = null, int? pageSize = null, bool? withTotalPages = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"pageSize", pageSize},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.optioncollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<OptionCollection?>(responseStream);
		}
		
		/// <summary>
		/// Create an option<br/>
		/// Create an option on your tenant.  Options are category-key-value tuples which store tenant configurations. Some categories of options allow the creation of new ones, while others are limited to predefined set of keys.  Any option of any tenant can be defined as "non-editable" by the "management" tenant; once done, any PUT or DELETE requests made on that option by the tenant owner will result in a 403 error (Unauthorized).  ### Default option categories  **access.control**  | Key |	Default value |	Predefined | Description | |--|--|--|--| | allow.origin | * | Yes | Comma separated list of domains allowed for execution of CORS. Wildcards are allowed (for example, `*.cumuclocity.com`) |  **alarm.type.mapping**  | Key  |	Predefined | Description | |--|--|--| | &lt;ALARM_TYPE> | No | Overrides the severity and alarm text for the alarm with type &lt;ALARM_TYPE>. The severity and text are specified as `<ALARM_SEVERITY>\|<ALARM_TEXT>`. If either part is empty, the value will not be overridden. If the severity is NONE, the alarm will be suppressed. Example: `"CRITICAL\|temperature too high"`|  ### Encrypted credentials  Adding a "credentials." prefix to the `key` will make the `value` of the option encrypted. When the option is  sent to a microservice, the "credentials." prefix is removed and the `value` is decrypted. For example:  ```json {   "category": "secrets",   "key": "credentials.mykey",   "value": "myvalue" } ```  In that particular example, the request will contain an additional header `"Mykey": "myvalue"`.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An option was created.</description>
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
		/// <returns></returns>
		public async Task<Option?> CreateOption(Option body)
		{
			var jsonNode = ToJsonNode<Option>(body);
			jsonNode?.RemoveFromNode("self");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.option+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.option+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.option+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Option?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve all options by category<br/>
		/// Retrieve all the options (by a specified category) on your tenant.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the options are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the options.</param>
		/// <returns></returns>
		public async Task<CategoryOptions?> GetOptionsByCategory(string category)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options/{category}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.option+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<CategoryOptions?>(responseStream);
		}
		
		/// <summary>
		/// Update options by category<br/>
		/// Update one or more options (by a specified category) on your tenant.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>A collection of options was updated.</description>
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
		/// <param name="category">The category of the options.</param>
		/// <returns></returns>
		public async Task<CategoryOptions?> UpdateOptionsByCategory(CategoryOptions body, string category)
		{
			var jsonNode = ToJsonNode<CategoryOptions>(body);
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options/{category}"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.option+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<CategoryOptions?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve a specific option<br/>
		/// Retrieve a specific option (by a given category and key) on your tenant.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the option is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Option not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the options.</param>
		/// <param name="key">The key of an option.</param>
		/// <returns></returns>
		public async Task<Option?> GetOption(string category, string key)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options/{category}/{key}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.option+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Option?>(responseStream);
		}
		
		/// <summary>
		/// Update a specific option<br/>
		/// Update the value of a specific option (by a given category and key) on your tenant.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_ADMIN <b>AND</b> the option is editable </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>An option was updated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Option not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="category">The category of the options.</param>
		/// <param name="key">The key of an option.</param>
		/// <returns></returns>
		public async Task<Option?> UpdateOption(CategoryKeyOption body, string category, string key)
		{
			var jsonNode = ToJsonNode<CategoryKeyOption>(body);
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options/{category}/{key}"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.option+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Option?>(responseStream);
		}
		
		/// <summary>
		/// Remove a specific option<br/>
		/// Remove a specific option (by a given category and key) on your tenant.  <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>An option was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Option not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the options.</param>
		/// <param name="key">The key of an option.</param>
		public async Task<System.IO.Stream> DeleteOption(string category, string key)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}//tenant/options/{category}/{key}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
	}
	#nullable disable
}
