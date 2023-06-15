//
// ITokensApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// In order to receive subscribed notifications, a consumer application or microservice must obtain an authorization token that provides proof that the holder is allowed to receive subscribed notifications. <br />
/// </summary>
///
public interface ITokensApi
{

	/// <summary> 
	/// Create a notification token <br />
	/// Create a new JWT (JSON web token) access token which can be used to establish a successful WebSocket connection to read a sequence of notifications. <br />
	/// In general, each request to obtain an access token consists of: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>The subscriber name which the client wishes to be identified with. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The subscription name. This value must be associated with a subscription that's already been created and in essence, the obtained token will give the ability to read notifications for the subscription that is specified here. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The token expiration duration. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The option to disable signing of the token by the Cumulocity IoT platform. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The subscription type that the token should be associated with. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The option to use the token to create shared consumers of the subscription. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The option to select the non-persistent variant of the subscription, if one exists. <br />
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
	/// 		<description>HTTP 200 A notification token was created. <br /> <br />
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
	/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<NotificationToken?> CreateToken(NotificationTokenClaims body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Unsubscribe a subscriber <br />
	/// Unsubscribe a notification subscriber using the notification token. <br />
	/// Once a subscription is made, notifications will be kept until they are consumed by all subscribers who have previously connected to the subscription. For non-volatile subscriptions, this can result in notifications remaining in storage if never consumed by the application.They will be deleted if a tenant is deleted. It can take up considerable space in permanent storage for high-frequency notification sources. Therefore, we recommend you to unsubscribe a subscriber that will never run again. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The notification subscription was deleted or is scheduled for deletion. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="token">Subscriptions associated with this token will be removed. <br /></param>
	///
	Task<NotificationSubscriptionResult?> UnsubscribeSubscriber(string? xCumulocityProcessingMode = null, string? token = null, CancellationToken cToken = default) ;
}
