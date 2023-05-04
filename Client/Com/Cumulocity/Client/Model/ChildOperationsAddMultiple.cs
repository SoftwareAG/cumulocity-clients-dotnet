///
/// ChildOperationsAddMultiple.cs
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
	public class ChildOperationsAddMultiple 
	{
	
		/// <summary> 
		/// An array containing the IDs of the managed objects (children). <br />
		/// </summary>
		///
		[JsonPropertyName("references")]
		public List<References> PReferences { get; set; } = new List<References>();
	
		public ChildOperationsAddMultiple() 
		{
		}
	
		public ChildOperationsAddMultiple(List<References> references)
		{
			this.PReferences = references;
		}
	
		public class References 
		{
		
			[JsonPropertyName("managedObject")]
			public ManagedObject? PManagedObject { get; set; }
		
			public class ManagedObject 
			{
			
				/// <summary> 
				/// Unique identifier of the object. <br />
				/// </summary>
				///
				[JsonPropertyName("id")]
				public string? Id { get; set; }
			
				public ManagedObject() 
				{
				}
			
				public ManagedObject(string id)
				{
					this.Id = id;
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
