//
// PageStatistics.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Information about paging statistics. <br />
/// </summary>
///
public sealed class PageStatistics 
{

	/// <summary> 
	/// The current page of the paginated results. <br />
	/// </summary>
	///
	[JsonPropertyName("currentPage")]
	public int? CurrentPage { get; set; }

	/// <summary> 
	/// Indicates the number of objects that the collection may contain per page. The upper limit for one page is 2,000 objects. <br />
	/// </summary>
	///
	[JsonPropertyName("pageSize")]
	public int? PageSize { get; set; }

	/// <summary> 
	/// The total number of results (elements). <br />
	/// </summary>
	///
	[JsonPropertyName("totalElements")]
	public int? TotalElements { get; set; }

	/// <summary> 
	/// The total number of paginated results (pages). <br />
	/// ⓘ Info: This property is returned by default except when an operation retrieves all records where values are between an upper and lower boundary, for example, querying ranges using <c>dateFrom</c>–<c>dateTo</c>. In such cases, the query parameter <c>withTotalPages=true</c> should be used to include the total number of pages (at the expense of slightly slower performance). <br />
	/// </summary>
	///
	[JsonPropertyName("totalPages")]
	public int? TotalPages { get; set; }

	public override string ToString()
	{
		var jsonOptions = new JsonSerializerOptions() 
		{ 
			WriteIndented = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};
		return JsonSerializer.Serialize(this, jsonOptions);
	}
}
