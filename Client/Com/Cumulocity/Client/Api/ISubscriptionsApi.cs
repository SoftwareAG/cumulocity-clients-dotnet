//
// ISubscriptionsApi.cs
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
/// Methods to create, retrieve and delete notification subscriptions. <br />
/// </summary>
///
public interface ISubscriptionsApi
{

	/// <summary> 
	/// Retrieve all subscriptions <br />
	/// Retrieve all subscriptions on your tenant, or a specific subset based on queries. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_NOTIFICATION_2_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and all subscriptions are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="context">The context to which the subscription is associated. <br /></param>
	/// <param name="currentPage">The current page of the paginated results. <br /></param>
	/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
	/// <param name="source">The managed object ID to which the subscription is associated. <br /></param>
	/// <param name="subscription">The subscription name by which filtering will be done. <br /></param>
	/// <param name="typeFilter">The type used to filter subscriptions. This will check the subscription's <c>subscriptionFilter.typeFilter</c> field. <br />ⓘ Info: Filtering by <c>typeFilter</c> may affect paging. Additional post filtering may be performed if OData-like expressions are used in the subscriptions. <br /></param>
	/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	///
	Task<NotificationSubscriptionCollection?> GetSubscriptions(string? context = null, int? currentPage = null, int? pageSize = null, string? source = null, string? subscription = null, string? typeFilter = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Create a subscription <br />
	/// Create a new subscription, for example, a subscription that forwards measurements and events of a specific type for a given device. <br />
	/// In general, each subscription may consist of: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>The managed object to which the subscription is associated. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The context under which the subscription is to be processed. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The name of the subscription. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The applicable filter criteria. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The option to only include specific custom fragments in the forwarded data. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The option to use persistent or non-persistent message storage. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// 
	/// <br /> Required roles <br />
	///  ROLE_NOTIFICATION_2_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 A notification subscription was created. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 409 Duplicated subscription. <br /> <br />
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
	Task<NotificationSubscription?> CreateSubscription(NotificationSubscription body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Remove subscriptions by source <br />
	/// Remove subscriptions by source and context. <br />
	/// ⓘ Info: The request will result in an error if there are no query parameters. The <c>source</c> parameter is optional only if the <c>context</c> parameter equals <c>tenant</c>. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_NOTIFICATION_2_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 A collection of subscriptions was removed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – error in query parameters <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="context">The context to which the subscription is associated. <br />ⓘ Info: If the value is <c>mo</c>, then <c>source</c> must also be provided in the query. <br /></param>
	/// <param name="source">The managed object ID to which the subscription is associated. <br /></param>
	///
	Task<string?> DeleteSubscriptions(string? xCumulocityProcessingMode = null, string? context = null, string? source = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve a specific subscription <br />
	/// Retrieve a specific subscription by a given ID. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_NOTIFICATION_2_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the subscription is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Subscription not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the notification subscription. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<NotificationSubscription?> GetSubscription(string id, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Remove a specific subscription <br />
	/// Remove a specific subscription by a given ID. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_NOTIFICATION_2_ADMIN 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 A subscription was removed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Subscription not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="id">Unique identifier of the notification subscription. <br /></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> DeleteSubscription(string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
}
