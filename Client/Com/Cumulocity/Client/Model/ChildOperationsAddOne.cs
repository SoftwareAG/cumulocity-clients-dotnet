///
/// ChildOperationsAddOne.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class ChildOperationsAddOne 
	{
	
		[JsonPropertyName("managedObject")]
		public ManagedObject? PManagedObject { get; set; }
	
		public ChildOperationsAddOne() 
		{
		}
	
		public ChildOperationsAddOne(ManagedObject managedObject)
		{
			this.PManagedObject = managedObject;
		}
	
		public class ManagedObject 
		{
		
			/// <summary>
			/// Unique identifier of the object.
			/// </summary>
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
				return JsonSerializer.Serialize(this);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
