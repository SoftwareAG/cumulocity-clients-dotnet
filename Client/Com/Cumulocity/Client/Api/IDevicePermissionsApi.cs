///
/// IDevicePermissionsApi.cs
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
	/// API methods to retrieve and update device permissions assignments. <br />
	/// Device permissions enable users to access and manipulate devices. <br />
	/// The device permission structure is [API:fragment_name:permission] where: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>API is one of the following values: OPERATION, ALARM, AUDIT, EVENT, MANAGED_OBJECT, MEASUREMENT or "*" <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>fragment_name can be the name of any fragment, for example, "c8y_Restart" or "*" <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>permission is ADMIN, READ or "*" <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// Required permission per HTTP method: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>GET - READ or "*" <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>PUT - ADMIN or "*" <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// The wildcard "*" enables you to access every API and stored object regardless of the fragments that are inside it. <br />
	/// ⚠️ Important: If there is no fragment in an object, for example, to read the object, you must use the wildcard "*" for the fragment_name part of the device permission (see the structure above). For example: <c>"10200":["MEASUREMENT:*:READ"]</c>. <br />
	/// </summary>
	///
	#nullable enable
	public interface IDevicePermissionsApi
	{
	
		/// <summary> 
		/// Returns all device permissions assignments <br />
		/// Returns all device permissions assignments if the current user has READ permission. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the device permissions assignments are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<DevicePermissions<TCustomProperties>?> GetDevicePermissionAssignments<TCustomProperties>(string id, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Updates the device permissions assignments <br />
		/// Updates the device permissions assignments if the current user has ADMIN permission or CREATE permission and also has all device permissions. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_ADMIN OR ROLE_USER_MANAGEMENT_CREATE 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The device permissions were successfully updated. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="id">Unique identifier of the managed object. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<System.IO.Stream> UpdateDevicePermissionAssignments<TCustomProperties>(DevicePermissions<TCustomProperties> body, string id, CancellationToken cToken = default) where TCustomProperties : CustomProperties;
	}
	#nullable disable
}
