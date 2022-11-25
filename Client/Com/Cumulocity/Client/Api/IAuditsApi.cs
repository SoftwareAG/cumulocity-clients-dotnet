///
/// IAuditsApi.cs
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
	/// An audit log stores events that are security-relevant and should be stored for auditing. For example, an audit log should be generated when a user logs into a gateway.
	/// 
	/// An audit log extends an event through:
	/// 
	/// * A username of the user that carried out the activity.
	/// * An application that was used to carry out the activity.
	/// * The actual activity.
	/// * A severity.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public interface IAuditsApi
	{
	
		/// <summary>
		/// Retrieve all audit records<br/>
		/// Retrieve all audit records registered on your tenant, or a specific subset based on queries. 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and all audit records are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="application">Name of the application from which the audit was carried out.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the audit record.</param>
		/// <param name="dateTo">End date or date and time of the audit record.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="source">The platform component ID to which the audit is associated.</param>
		/// <param name="type">The type of audit record to search for.</param>
		/// <param name="user">The username to search for.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<AuditRecordCollection<TAuditRecord>?> GetAuditRecords<TAuditRecord>(string? application = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, string? source = null, string? type = null, string? user = null, bool? withTotalElements = null, bool? withTotalPages = null) where TAuditRecord : AuditRecord;
		
		/// <summary>
		/// Create an audit record<br/>
		/// Create an audit record.  <section><h5>Required roles</h5> ROLE_AUDIT_ADMIN <b>OR</b> ROLE_SYSTEM <b>OR</b> AUDIT_ADMIN permission on the resource </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>An audit record was created.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See [Processing mode](#processing-mode) for more details.</param>
		/// <returns></returns>
		Task<TAuditRecord?> CreateAuditRecord<TAuditRecord>(TAuditRecord body, string xCumulocityProcessingMode) where TAuditRecord : AuditRecord;
		
		/// <summary>
		/// Retrieve a specific audit record<br/>
		/// Retrieve a specific audit record by a given ID.  <section><h5>Required roles</h5> ROLE_AUDIT_READ <b>OR</b> AUDIT_READ permission on the source </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the audit record is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the audit record.</param>
		/// <returns></returns>
		Task<TAuditRecord?> GetAuditRecord<TAuditRecord>(string id) where TAuditRecord : AuditRecord;
	}
	#nullable disable
}
