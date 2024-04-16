//
// IRealtimeNotificationApi.cs
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
/// <br /> Real-time operations <br />
/// Real-time notification services of Cumulocity IoT have their own subscription channel name format and URL. The real-time notifications are available for <see href="#tag/Alarm-notification-API" langword="Alarms" />, <see href="#tag/Device-control-notification-API" langword="Device control" />, <see href="#tag/Event-notification-API" langword="Events" />, <see href="#tag/Inventory-notification-API" langword="Inventory" /> and <see href="#tag/Measurement-notification-API" langword="Measurements" />. <br />
/// Note that when using long-polling, all POST requests must contain the Accept header, otherwise an empty response body will be returned.All requests are sent to the <kbd>/notification/realtime</kbd> endpoint. <br />
/// ⓘ Info: The long-polling interface is designed as a mechanism for custom applications to poll infrequent events from Cumulocity IoT. The long-polling interface is not designed as a mechanism to stream large data volumes (>100kB/sec) or frequent data (>50 events/sec) out of Cumulocity IoT. The usage of long-polling is not supported for such use cases. <br />
/// <br /> Handshake <br />
/// A real-time notifications client initiates the connection negotiation by sending a message to the <c>/meta/handshake</c> channel. In response, the client receives a <c>clientId</c> which identifies a conversation and must be passed in every non-handshake request. <br />
/// ⓘ Info: The number of parallel connections that can be opened at the same time by a single user is limited. After exceeding this limit when a new connection is created, the oldest one will be closed and the newly created one will be added in its place. This limit is configurable and managed per installation. Its default value is 10 connections per user, subscription channel and server node. <br />
/// When using WebSockets, a property <c>ext</c> containing an authentication object must be sent. In case of basic authentication, the token is used with Base64 encoded credentials. In case of OAuth authentication, the request must have the cookie with the authorization name, holding the access token. Moreover, the XSRF token must be forwarded as part of the handshake message. <br />
/// <br /> Request example <br />
/// <![CDATA[
/// POST /notification/realtime
/// Authorization: <AUTHORIZATION>
/// Content-Type: application/json
/// 
/// [
///   {
///     "channel": "/meta/handshake",
///     "version": "1.0"
///   }
/// ]
/// ]]>
/// <br /> Response example <br />
/// A successful response looks like: <br />
/// <![CDATA[
/// [
///   {
///     "channel": "/meta/handshake",
///     "clientId": "69wzith4teyensmz6zyk516um4yum0mvp",
///     "minimumVersion": "1.0",
///     "successful": true,
///     "supportedConnectionTypes": [
///       "long-polling",
///       "smartrest-long-polling",
///       "websocket"
///     ],
///     "version": "1.0"
///   }
/// ]
/// ]]>
/// When an error occurs, the response looks like: <br />
/// <![CDATA[
/// [
///   {
///     "channel": "/meta/handshake",
///     "error": "403::Handshake denied",
///     "successful": false
///   }
/// ]
/// ]]>
/// <br /> Subscribe <br />
/// A notification client can send subscribe messages and specify the desired channel to receive output messages from the Cumulocity IoT server. The client will receive the messages in succeeding connect requests. <br />
/// Each REST API that uses the real-time notification service has its own format for channel names. See <see href="#tag/Device-control-notification-API" langword="Device control" /> for more details. <br />
/// <br /> Request example <br />
/// <![CDATA[
/// POST /notification/realtime
/// Authorization: <AUTHORIZATION>
/// Content-Type: application/json
/// 
/// [
///   {
///     "channel": "/meta/subscribe",
///     "clientId": "69wzith4teyensmz6zyk516um4yum0mvp",
///     "subscription": "/alarms/<DEVICE_ID>"
///   }
/// ]
/// ]]>
/// <br /> Response example <br />
/// <![CDATA[
/// [
///   {
///     "channel": "/meta/subscribe",
///     "clientId": "69wzith4teyensmz6zyk516um4yum0mvp",
///     "subscription": "/alarms/<DEVICE_ID>",
///     "successful": true
///   }
/// ]
/// ]]>
/// <br /> Unsubscribe <br />
/// To stop receiving notifications from a channel, send a message to the channel <c>/meta/unsubscribe</c> in the same format as used during subscription. <br />
/// <br /> Request example <br />
/// Example Request: <br />
/// <![CDATA[
/// POST /notification/realtime
/// Authorization: <AUTHORIZATION>
/// Content-Type: application/json
/// 
/// [
///   {
///     "channel": "/meta/unsubscribe",
///     "clientId": "69wzith4teyensmz6zyk516um4yum0mvp",
///     "subscription": "/alarms/<DEVICE_ID>"
///   }
/// ]
/// ]]>
/// <br /> Response example <br />
/// <![CDATA[
/// [
///   {
///     "channel": "/meta/unsubscribe",
///     "subscription": "/alarms/<DEVICE_ID>",
///     "successful": true
///   }
/// ]
/// ]]>
/// <br /> Connect <br />
/// After a Bayeux client has discovered the server's capabilities with a handshake exchange and subscribed to the desired channels, a connection is established by sending a message to the <c>/meta/connect</c> channel. This message may be transported over any of the transports returned by the server in the handshake response. Requests to the connect channel must be immediately repeated after every response to receive the next batch of notifications. <br />
/// <br /> Request example <br />
/// <![CDATA[
/// POST /notification/realtime
/// Authorization: <AUTHORIZATION>
/// Content-Type: application/json
/// 
/// [
///   {
///     "channel": "/meta/connect",
///     "clientId": "69wzith4teyensmz6zyk516um4yum0mvp",
///     "connectionType": "long-polling",
///     "advice": {
///       "timeout": 5400000,
///       "interval": 3000
///     }
///   }
/// ]
/// ]]>
/// <br /> Response example <br />
/// <![CDATA[
/// [
///   {
///     "channel": "/meta/connect",
///     "data": null,
///     "advice": {
///       "interval": 3000,
///       "timeout": 5400000
///     },
///     "successful": true
///   }
/// ]
/// ]]>
/// <br /> Disconnect <br />
/// To stop receiving notifications from all channels and close the conversation, send a message to the <c>/meta/disconnect</c> channel. <br />
/// <br /> Request example <br />
/// <![CDATA[
/// POST /notification/realtime
/// Authorization: <AUTHORIZATION>
/// Content-Type: application/json
/// 
/// [
///   {
///     "channel": "/meta/disconnect",
///     "clientId": "69wzith4teyensmz6zyk516um4yum0mvp"
///   }
/// ]
/// ]]>
/// <br /> Response example <br />
/// <![CDATA[
/// [
///   {
///     "channel": "/meta/disconnect",
///     "successful": true
///   }
/// ]
/// ]]>
/// <br /> Long-running connections <br />
/// To keep a long-running connection alive when there are no new notifications to deliver, the server will periodically send an empty <c>/meta/connect</c> response to the client.The client should send a new <c>/meta/connect</c> request immediately after receiving such a response, to ensure that the connection remains active and future notifications are delivered. <br />
/// </summary>
///
public interface IRealtimeNotificationApi
{

	/// <summary> 
	/// Responsive communication <br />
	/// The Real-time notification API enables responsive communication from Cumulocity IoT over restricted networks towards clients such as web browser and mobile devices. All clients subscribe to so-called channels to receive messages. These channels are filled by Cumulocity IoT with the output of <see href="#tag/Operations" langword="Operations" />. In addition, particular system channels are used for the initial handshake with clients, subscription to channels, removal from channels and connection. The <see href="https://docs.cometd.org/current/reference/#_concepts_bayeux_protocol" langword="Bayeux protocol" /> over HTTPS or WSS is used as communication mechanism. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The operation was completed and the result is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 400 Unprocessable Entity – invalid payload. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<RealtimeNotification?> CreateRealtimeNotification(RealtimeNotification body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
}
