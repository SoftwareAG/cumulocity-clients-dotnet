///
/// ITenantsApi.cs
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
	/// Tenants are physically separated data spaces with a separate URL, with own users, a separate application management and no sharing of data by default. Users in a single tenant by default share the same URL and the same data space. <br />
	/// <br /> Tenant ID and tenant domain <br />
	/// The tenant ID is a unique identifier across all tenants in Cumulocity IoT and it follows the format t<number>, for example, t07007007. It is possible to specify the tenant ID while creating a subtenant, but the ID cannot be changed after creation. If the ID is not specified (recommended), it gets auto-generated for all tenant types. <br />
	/// The location where a tenant can be accessed is called tenant domain, for example, mytenant.cumulocity.com. It needs to be unique across all tenants and it can be changed after tenant creation.The tenant domain may contain only lowercase letters, digits and hyphens. It must start with a lowercase letter, hyphens are only allowed in the middle, and the minimum length is 2 characters. Note that the usage of underscore characters is deprecated but still possible for backward compatibility reasons. <br />
	/// In general, the tenant domain should be used for communication if it is known. <br />
	/// ⚠️ Important: For support user access, the tenant ID must be used and not the tenant domain. <br />
	/// See <see href="#operation/getCurrentTenantResource" langword="Tenant > Current tenant" /> for information on how to retrieve the tenant ID and domain of the current tenant via the API. <br />
	/// In the UI, the tenant ID is displayed in the user dropdown menu, see <see href="https://cumulocity.com/guides/users-guide/getting-started/#user-settings" langword="Getting started > User options and settings" /> in the User guide. <br />
	/// <br /> Access rights and permissions <br />
	/// There are two types of roles in Cumulocity IoT – global and inventory. Global roles are applied at the tenant level. In a Role Based Access Control (RBAC) approach you must use the inventory roles in order to have the correct level of separation. Apart from some global permissions (like "own user management") customer users will not be assigned any roles. Inventory roles must be created, or the default roles used, and then assigned to the user in combination with the assets the roles apply to. This needs to be done at least once for each customer. <br />
	/// In a multi-tenancy approach, as the tenant is completely separated from all other customers you do not necessarily need to be involved in setting up the access rights of the customer. If customers are given administration rights for their tenants, they can set up permissions on their own. It is not possible for customers to have any sight or knowledge of other customers. <br />
	/// In the RBAC approach, managing access is the most complicated part because a misconfiguration can potentially give customers access to data that they must not see, like other customers' data. The inventory roles allow you to granularly define access for only certain parts of data, but they don't protect you from accidental misconfigurations. A limitation here is that customers won't be able to create their own roles. <br />
	/// For more details, see <see href="https://cumulocity.com/guides/concepts/tenant-hierarchy/#comparison" langword="RBAC versus multi-tenancy approach" />. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface ITenantsApi
	{
	
		/// <summary> 
		/// Retrieve all subtenants <br />
		/// Retrieve all subtenants of the current tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_MANAGEMENT_READ 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the subtenants are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		///
		Task<TenantCollection<TCustomProperties>?> GetTenants<TCustomProperties>(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Create a tenant <br />
		/// Create a subtenant for the current tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_MANAGEMENT_CREATE) AND the current tenant is allowed to create subtenants 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A tenant was created. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 409 Conflict – The tenant domain/ID already exists. <br /> <br />
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
		Task<Tenant<TCustomProperties>?> CreateTenant<TCustomProperties>(Tenant<TCustomProperties> body) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Retrieve the current tenant <br />
		/// Retrieve information about the current tenant. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_USER_MANAGEMENT_OWN_READ OR ROLE_SYSTEM 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the information is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="withParent">When set to <c>true</c>, the returned result will contain the parent of the current tenant. <br /></param>
		///
		Task<CurrentTenant<TCustomProperties>?> GetCurrentTenant<TCustomProperties>(bool? withParent = null) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Retrieve a specific tenant <br />
		/// Retrieve a specific tenant by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_MANAGEMENT_READ AND the current tenant is its parent OR is the management tenant 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the tenant is sent in the response. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 Tenant not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		///
		Task<Tenant<TCustomProperties>?> GetTenant<TCustomProperties>(string tenantId) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Update a specific tenant <br />
		/// Update a specific tenant by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_MANAGEMENT_UPDATE) AND (the current tenant is its parent AND the current tenant is allowed to create subtenants) OR is the management tenant 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 A tenant was updated. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 Tenant not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		///
		Task<Tenant<TCustomProperties>?> UpdateTenant<TCustomProperties>(Tenant<TCustomProperties> body, string tenantId) where TCustomProperties : CustomProperties;
		
		/// <summary> 
		/// Remove a specific tenant <br />
		/// Remove a specific tenant by a given ID. <br />
		/// ⚠️ Important: Deleting a subtenant cannot be reverted. For security reasons, it is therefore only available in the management tenant. You cannot delete tenants from any tenant but the management tenant. <br />
		/// Administrators in Enterprise Tenants are only allowed to suspend active subtenants, but not to delete them. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_TENANT_MANAGEMENT_ADMIN AND is the management tenant 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 204 A tenant was removed. <br /> <br />
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
		/// 	<item>
		/// 		<description>HTTP 404 Tenant not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		///
		Task<System.IO.Stream> DeleteTenant(string tenantId) ;
		
		/// <summary> 
		/// Retrieve TFA settings of a specific tenant <br />
		/// Retrieve the two-factor authentication settings of a specific tenant by a given tenant ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ((ROLE_TENANT_MANAGEMENT_READ OR ROLE_USER_MANAGEMENT_READ) AND (the current tenant is its parent OR is the management tenant OR the current user belongs to the tenant)) OR (the user belongs to the tenant AND ROLE_USER_MANAGEMENT_OWN_READ) 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the TFA settings are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 404 Tenant not found. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
		///
		Task<TenantTfaData?> GetTenantTfaSettings(string tenantId) ;
	}
	#nullable disable
}
