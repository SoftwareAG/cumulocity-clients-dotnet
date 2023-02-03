///
/// ISystemOptionsApi.cs
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
	/// API methods to retrieve the read-only properties predefined in the platform's configuration.
	/// 
	/// For security reasons, a few system options are considered secured, which means the user must have the required role **ROLE_OPTION_MANAGEMENT_ADMIN** to read their values.
	/// 
	/// List of options:
	/// 
	/// |         Category          | Key                           | Considered as secured |
	/// |:-------------------------:|:------------------------------|:----------------------|
	/// |         password          | green.min-length              | yes                   |
	/// | two-factor-authentication | pin.validity                  | yes                   |
	/// | two-factor-authentication | token.length                  | yes                   |
	/// | two-factor-authentication | token.validity                | yes                   |
	/// |      authentication       | badRequestCounter             | yes                   |
	/// |           files           | microservice.zipped.max.size  | yes                   |
	/// |           files           | microservice.unzipped.max.size| yes                   |
	/// |           files           | webapp.zipped.max.size        | yes                   |
	/// |           files           | webapp.unzipped.max.size      | yes                   |
	/// | two-factor-authentication | enforced                      | no                    |
	/// |       reportMailer        | available                     | no                    |
	/// |          system           | version                       | no                    |
	/// |          plugin           | eventprocessing.enabled       | no                    |
	/// |         password          | limit.validity                | no                    |
	/// |         password          | enforce.strength              | no                    |
	/// | two-factor-authentication | strategy                      | no                    |
	/// | two-factor-authentication | pin.length                    | no                    |
	/// | two-factor-authentication | enabled                       | no                    |
	/// | two-factor-authentication | enforced.group                | no                    |
	/// | two-factor-authentication | tenant-scope-settings.enabled | no                    |
	/// | two-factor-authentication | logout-on-browser-termination | no                    |
	/// |       connectivity        | microservice.url              | no                    |
	/// |       support-user        | enabled                       | no                    |
	/// |          support          | url                           | no                    |
	/// |         trackers          | supported.models              | no                    |
	/// |         encoding          | test                          | no                    |
	/// |        data-broker        | bootstrap.period              | no                    |
	/// |           files           | max.size                      | no                    |
	/// |      device-control       | bulkoperation.creationramp    | no                    |
	/// |         gainsight         | api.key                       | no                    |
	/// |            cep            | deprecation.alarm             | no                    |
	/// |       remoteaccess        | pass-through.enabled          | no                    |
	/// |    device-registration    | security-token.policy         | no                    |
	/// 
	/// </summary>
	#nullable enable
	public interface ISystemOptionsApi
	{
	
		/// <summary>
		/// Retrieve all system options<br/>
		/// Retrieve all the system options available on the tenant.  > **⚠️ Important:** Note that it is possible to call this endpoint without the ROLE_OPTION_MANAGEMENT_ADMIN role, but options that are considered secured (see the list of options above) will be obfuscated with a constant value `"<<Encrypted>>"`. 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the system options are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<SystemOptionCollection?> GetSystemOptions() ;
		
		/// <summary>
		/// Retrieve a specific system option<br/>
		/// Retrieve a specific system option (by a given category and key) on your tenant.  > **⚠️ Important:** Note that it is possible to call this endpoint without the ROLE_OPTION_MANAGEMENT_ADMIN role, but only the options that are considered not secured (see the list of options above) will be returned. Otherwise, if the option is considered secured and the user does not have the required role, an HTTP response 403 will be returned. <section><h5>Required roles</h5> ROLE_OPTION_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the system option is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="category">The category of the system options.</param>
		/// <param name="key">The key of a system option.</param>
		/// <returns></returns>
		Task<SystemOption?> GetSystemOption(string category, string key) ;
	}
	#nullable disable
}
