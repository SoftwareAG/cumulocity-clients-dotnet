///
/// ILoginOptionsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to retrieve the login options configured in the tenant. <br />
	/// More detailed information about the parameters and their meaning can be found in <see href="https://cumulocity.com/guides/users-guide/administration/#changing-settings" langword="Administration > Changing settings" /> in the Users guide. <br />
	/// ⓘ Info: If OAuth external is the only login option shown in the response, the user will be automatically redirected to the SSO login screen. <br />
	/// </summary>
	///
	#nullable enable
	public interface ILoginOptionsApi
	{
	
		/// <summary> 
		/// Retrieve the login options <br />
		/// Retrieve the login options available in the tenant. <br />
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the login options are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 400 Bad request – invalid parameters. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="management">If this is set to <c>true</c>, the management tenant login options will be returned. <br />ⓘ Info: The <c>tenantId</c> parameter must not be present in the request when using the <c>management</c> parameter, otherwise it will cause an error. <br /></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		///
		Task<LoginOptionCollection?> GetLoginOptions(bool? management = null, string? tenantId = null) ;
		
		/// <summary> 
		/// Create a login option <br />
		/// Create an authentication configuration on your tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_ADMIN OR ROLE_TENANT_MANAGEMENT_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A login option was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 400 Duplicated – The login option already exists. <br /> <br />
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
		///
		Task<AuthConfig?> CreateLoginOption(AuthConfig body) ;
		
		/// <summary> 
		/// Update a tenant's access to the login option <br />
		/// Update the tenant's access to the authentication configuration. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_MANAGEMENT_ADMIN AND is the management tenant 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The login option was updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Tenant not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="typeOrId">The type or ID of the login option. The type's value is case insensitive and can be <c>OAUTH2</c>, <c>OAUTH2_INTERNAL</c> or <c>BASIC</c>. <br /></param>
		/// <param name="targetTenant">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		///
		Task<AuthConfig?> UpdateLoginOption(AuthConfigAccess body, string typeOrId, string? targetTenant = null) ;
	}
	#nullable disable
}
