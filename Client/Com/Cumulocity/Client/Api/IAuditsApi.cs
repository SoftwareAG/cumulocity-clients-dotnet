///
/// IAuditsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// An audit log stores events that are security-relevant and should be stored for auditing. For example, an audit log should be generated when a user logs into a gateway. <br />
	/// An audit log extends an event through: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>A username of the user that carried out the activity. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>An application that was used to carry out the activity. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>The actual activity. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>A severity. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IAuditsApi
	{
	
		/// <summary> 
		/// Retrieve all audit records <br />
		/// Retrieve all audit records registered on your tenant, or a specific subset based on queries. <br />
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and all audit records are sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="application">Name of the application from which the audit was carried out. <br /></param>
		/// <param name="currentPage">The current page of the paginated results. <br /></param>
		/// <param name="dateFrom">Start date or date and time of the audit record. <br /></param>
		/// <param name="dateTo">End date or date and time of the audit record. <br /></param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
		/// <param name="source">The platform component ID to which the audit is associated. <br /></param>
		/// <param name="type">The type of audit record to search for. <br /></param>
		/// <param name="user">The username to search for. <br /></param>
		/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<AuditRecordCollection<TAuditRecord>?> GetAuditRecords<TAuditRecord>(string? application = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, string? source = null, string? type = null, string? user = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TAuditRecord : AuditRecord;
		
		/// <summary> 
		/// Create an audit record <br />
		/// Create an audit record. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_AUDIT_ADMIN OR ROLE_SYSTEM OR AUDIT_ADMIN permission on the resource 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 An audit record was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TAuditRecord?> CreateAuditRecord<TAuditRecord>(TAuditRecord body, CancellationToken cToken = default) where TAuditRecord : AuditRecord;
		
		/// <summary> 
		/// Retrieve a specific audit record <br />
		/// Retrieve a specific audit record by a given ID. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_AUDIT_READ OR AUDIT_READ permission on the source 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 The request has succeeded and the audit record is sent in the response. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the audit record. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<TAuditRecord?> GetAuditRecord<TAuditRecord>(string id, CancellationToken cToken = default) where TAuditRecord : AuditRecord;
	}
	#nullable disable
}
