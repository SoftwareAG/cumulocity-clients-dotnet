///
/// ICurrentUserApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// The current user is the user that is currently authenticated with Cumulocity IoT for the API calls.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface ICurrentUserApi
	{
	
		/// <summary>
		/// Retrieve the current user<br/>
		/// Retrieve the user reference of the current user.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_OWN_READ <b>OR</b> ROLE_SYSTEM </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the current user is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<CurrentUser?> GetCurrentUser() ;
		
		/// <summary>
		/// Update the current user<br/>
		/// Update the current user.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The current user was updated.</description>
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
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<CurrentUser?> UpdateCurrentUser(CurrentUser body, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Update the current user's password<br/>
		/// Update the current user's  password.  > **⚠️ Important:** If the tenant uses OAI-Secure authentication, the current user will not be logged out. Instead, a new cookie will be set with a new token, and the previous token will expire within a minute.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_OWN_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The current user password was updated.</description>
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
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> UpdateCurrentUserPassword(PasswordChange body, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Generate secret to set up TFA<br/>
		/// Generate a secret code to create a QR code to set up the two-factor authentication functionality using a TFA app/service.  For more information about the feature, see [User Guide > Administration > Two-factor authentication](https://cumulocity.com/guides/users-guide/administration/#tfa) in the *Cumulocity IoT documentation*.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_OWN_READ <b>OR</b> ROLE_SYSTEM </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the secret is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<CurrentUserTotpSecret?> GenerateTfaSecret(string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Returns the activation state of the two-factor authentication feature.<br/>
		/// Returns the activation state of the two-factor authentication feature for the current user.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_OWN_READ <b>OR</b> ROLE_SYSTEM </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>Returns the activation state.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>User not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		Task<CurrentUserTotpSecretActivity?> GetTfaState() ;
		
		/// <summary>
		/// Activates or deactivates the two-factor authentication feature<br/>
		/// Activates or deactivates the two-factor authentication feature for the current user.  For more information about the feature, see [User Guide > Administration > Two-factor authentication](https://cumulocity.com/guides/users-guide/administration/#tfa) in the *Cumulocity IoT documentation*.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_OWN_READ <b>OR</b> ROLE_SYSTEM </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>The two-factor authentication was activated or deactivated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Cannot deactivate TOTP setup.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>User not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> SetTfaState(CurrentUserTotpSecretActivity body, string xCumulocityProcessingMode) ;
		
		/// <summary>
		/// Verify TFA code<br/>
		/// Verifies the authentication code that the current user received from a TFA app/service and uploaded to the platform to gain access or enable the two-factor authentication feature.  <section><h5>Required roles</h5> ROLE_USER_MANAGEMENT_OWN_READ <b>OR</b> ROLE_SYSTEM </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>The sent code was correct and the access can be granted.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Invalid verification code.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Cannot validate TFA TOTP code - user's TFA TOTP secret does not exist.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		Task<System.IO.Stream> VerifyTfaCode(CurrentUserTotpCode body, string xCumulocityProcessingMode) ;
	}
	#nullable disable
}
