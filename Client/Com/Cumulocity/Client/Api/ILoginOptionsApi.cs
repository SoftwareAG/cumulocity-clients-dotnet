///
/// ILoginOptionsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// API methods to retrieve the login options configured in the tenant.
	/// 
	/// More detailed information about the parameters and their meaning can be found in [Administration > Changing settings](https://cumulocity.com/guides/users-guide/administration/#changing-settings) in the *Users guide*.
	/// > **&#9432; Info:** If OAuth external is the only login option shown in the response, the user will be automatically redirected to the SSO login screen.
	/// 
	/// </summary>
	#nullable enable
	public interface ILoginOptionsApi
	{
	
		/// <summary>
		/// Retrieve the login options<br/>
		/// Retrieve the login options available in the tenant.
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the login options are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 400</term>
		/// <description>Bad request – invalid parameters.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="management">If this is set to `true`, the management tenant login options will be returned.  > **&#9432; Info:** The `tenantId` parameter must not be present in the request when using the `management` parameter, otherwise it will cause an error. </param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <returns></returns>
		Task<LoginOptionCollection?> GetLoginOptions(bool? management = null, string? tenantId = null) ;
		
		/// <summary>
		/// Create a login option<br/>
		/// Create an authentication configuration on your tenant.  <section><h5>Required roles</h5> ROLE_TENANT_ADMIN <b>OR</b> ROLE_TENANT_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>A login option was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 400</term>
		/// <description>Duplicated – The login option already exists.</description>
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
		Task<AuthConfig?> CreateLoginOption(AuthConfig body) ;
	}
	#nullable disable
}
