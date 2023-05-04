///
/// LoginTokensApi.cs
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
	/// API methods to obtain access tokens to the Cumulocity IoT platform in case of OAI-Secure or SSO authentication. <br />
	/// </summary>
	///
	#nullable enable
	public class LoginTokensApi : AdaptableApi, ILoginTokensApi
	{
		public LoginTokensApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
	}
	#nullable disable
}
