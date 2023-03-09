///
/// WebApplicationManifest.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary> 
	/// The manifest of the web application. <br />
	/// </summary>
	///
	public class WebApplicationManifest 
	{
	
		/// <summary> 
		/// A legacy flag that identified a certain type of web application that would control the behavior of plugin tab in the application details view.It is no longer used. <br />
		/// </summary>
		///
		[System.ObsoleteAttribute("This property might be removed in future releases.", false)]
		[JsonPropertyName("_webpaas")]
		public bool? PWebpaas { get; set; }
	
		/// <summary> 
		/// The content security policy of the application. <br />
		/// </summary>
		///
		[JsonPropertyName("contentSecurityPolicy")]
		public string? ContentSecurityPolicy { get; set; }
	
		/// <summary> 
		/// A flag that decides if the application is shown in the app switcher on the UI. <br />
		/// </summary>
		///
		[JsonPropertyName("noAppSwitcher")]
		public bool? NoAppSwitcher { get; set; }
	
		/// <summary> 
		/// A flag that decides if the application tabs are displayed horizontally or not. <br />
		/// </summary>
		///
		[JsonPropertyName("tabsHorizontal")]
		public bool? TabsHorizontal { get; set; }
	
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
