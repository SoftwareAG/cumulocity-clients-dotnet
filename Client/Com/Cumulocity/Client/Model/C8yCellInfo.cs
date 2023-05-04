///
/// C8yCellInfo.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// Provides detailed information about the closest mobile cell towers. When the functionality is activated, the location of the device is determined based on this fragment, in order to track the device whereabouts when GPS tracking is not available. <br />
	/// </summary>
	///
	public class C8yCellInfo 
	{
	
		/// <summary> 
		/// The radio type of this cell tower. <br />
		/// </summary>
		///
		[JsonPropertyName("radioType")]
		public string? RadioType { get; set; }
	
		/// <summary> 
		/// Detailed information about the neighboring cell towers. <br />
		/// </summary>
		///
		[JsonPropertyName("cellTowers")]
		public List<C8yCellTower> CellTowers { get; set; } = new List<C8yCellTower>();
	
		public C8yCellInfo() 
		{
		}
	
		public C8yCellInfo(List<C8yCellTower> cellTowers)
		{
			this.CellTowers = cellTowers;
		}
	
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
}
