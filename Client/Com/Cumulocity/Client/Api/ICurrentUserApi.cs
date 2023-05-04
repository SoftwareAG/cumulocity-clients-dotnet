///
/// ICurrentUserApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// The current user is the user that is currently authenticated with Cumulocity IoT for the API calls. <br />
	/// ⓘ Info: The Accept header should be provided in all PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface ICurrentUserApi
	{
	
		/// <summary> 
		/// Retrieve the current user <br />
		/// Retrieve the user reference of the current user. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_READ OR ROLE_SYSTEM 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the current user is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<CurrentUser?> GetCurrentUser(CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update the current user <br />
		/// Update the current user. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The current user was updated. <br /> <br />
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
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<CurrentUser?> UpdateCurrentUser(CurrentUser body, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Update the current user's password <br />
		/// Update the current user's  password. <br />
		/// ⚠️ Important: If the tenant uses OAI-Secure authentication, the current user will not be logged out. Instead, a new cookie will be set with a new token, and the previous token will expire within a minute. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The current user password was updated. <br /> <br />
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
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UpdateCurrentUserPassword(PasswordChange body, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Generate secret to set up TFA <br />
		/// Generate a secret code to create a QR code to set up the two-factor authentication functionality using a TFA app/service. <br />
		/// For more information about the feature, see <see href="https://cumulocity.com/guides/users-guide/administration/#tfa" langword="User Guide > Administration > Two-factor authentication" /> in the Cumulocity IoT documentation. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_READ OR ROLE_SYSTEM 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the secret is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<CurrentUserTotpSecret?> GenerateTfaSecret(CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Returns the activation state of the two-factor authentication feature. <br />
		/// Returns the activation state of the two-factor authentication feature for the current user. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_READ OR ROLE_SYSTEM 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 Returns the activation state. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 User not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<CurrentUserTotpSecretActivity?> GetTfaState(CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Activates or deactivates the two-factor authentication feature <br />
		/// Activates or deactivates the two-factor authentication feature for the current user. <br />
		/// For more information about the feature, see <see href="https://cumulocity.com/guides/users-guide/administration/#tfa" langword="User Guide > Administration > Two-factor authentication" /> in the Cumulocity IoT documentation. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_READ OR ROLE_SYSTEM 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 The two-factor authentication was activated or deactivated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Cannot deactivate TOTP setup. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 User not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> SetTfaState(CurrentUserTotpSecretActivity body, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Verify TFA code <br />
		/// Verifies the authentication code that the current user received from a TFA app/service and uploaded to the platform to gain access or enable the two-factor authentication feature. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_READ OR ROLE_SYSTEM 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 The sent code was correct and the access can be granted. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Invalid verification code. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Cannot validate TFA TOTP code - user's TFA TOTP secret does not exist. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> VerifyTfaCode(CurrentUserTotpCode body, CancellationToken cToken = default) ;
	}
	#nullable disable
}
