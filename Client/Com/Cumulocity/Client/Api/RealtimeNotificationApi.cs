///
/// RealtimeNotificationApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
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
	/// </summary>
	///
	#nullable enable
	public class RealtimeNotificationApi : AdaptableApi, IRealtimeNotificationApi
	{
		public RealtimeNotificationApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<RealtimeNotification?> CreateRealtimeNotification(RealtimeNotification body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<RealtimeNotification>(body);
			jsonNode?.RemoveFromNode("clientId");
			jsonNode?.RemoveFromNode("data");
			jsonNode?.RemoveFromNode("error");
			jsonNode?.RemoveFromNode("successful");
			var client = HttpClient;
			var resourcePath = $"/notification/realtime";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken: cToken).ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<RealtimeNotification?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
