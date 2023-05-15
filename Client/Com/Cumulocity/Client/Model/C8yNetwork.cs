//
// C8yNetwork.cs
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
/// Device capability to either display or display and manage the WAN, LAN, and DHCP settings. <br />
/// </summary>
///
public sealed class C8yNetwork 
{

	/// <summary> 
	/// Local network information. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_LAN")]
	public C8yLAN? PC8yLAN { get; set; }

	/// <summary> 
	/// Mobile internet connectivity interface status. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_WAN")]
	public C8yWAN? PC8yWAN { get; set; }

	/// <summary> 
	/// Information for DHCP server status. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_DHCP")]
	public C8yDHCP? PC8yDHCP { get; set; }

	/// <summary> 
	/// Local network information. <br />
	/// </summary>
	///
	public sealed class C8yLAN 
	{
	
		/// <summary> 
		/// Subnet mask configured for the network interface. <br />
		/// </summary>
		///
		[JsonPropertyName("netmask")]
		public string? Netmask { get; set; }
	
		/// <summary> 
		/// IP address configured for the network interface. <br />
		/// </summary>
		///
		[JsonPropertyName("ip")]
		public string? Ip { get; set; }
	
		/// <summary> 
		/// Identifier for the network interface. <br />
		/// </summary>
		///
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary> 
		/// Indicator showing if the interface is enabled. <br />
		/// </summary>
		///
		[JsonPropertyName("enabled")]
		public int? Enabled { get; set; }
	
		/// <summary> 
		/// MAC address of the network interface. <br />
		/// </summary>
		///
		[JsonPropertyName("mac")]
		public string? Mac { get; set; }
	
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

	/// <summary> 
	/// Mobile internet connectivity interface status. <br />
	/// </summary>
	///
	public sealed class C8yWAN 
	{
	
		/// <summary> 
		/// SIM connectivity password. <br />
		/// </summary>
		///
		[JsonPropertyName("password")]
		public string? Password { get; set; }
	
		/// <summary> 
		/// SIM connection status. <br />
		/// </summary>
		///
		[JsonPropertyName("simStatus")]
		public string? SimStatus { get; set; }
	
		/// <summary> 
		/// Authentication type used by the SIM connectivity. <br />
		/// </summary>
		///
		[JsonPropertyName("authType")]
		public string? AuthType { get; set; }
	
		/// <summary> 
		/// APN used for internet access. <br />
		/// </summary>
		///
		[JsonPropertyName("apn")]
		public string? Apn { get; set; }
	
		/// <summary> 
		/// SIM connectivity username. <br />
		/// </summary>
		///
		[JsonPropertyName("username")]
		public string? Username { get; set; }
	
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

	/// <summary> 
	/// Information for DHCP server status. <br />
	/// </summary>
	///
	public sealed class C8yDHCP 
	{
	
		/// <summary> 
		/// First configured DNS server. <br />
		/// </summary>
		///
		[JsonPropertyName("dns1")]
		public string? Dns1 { get; set; }
	
		/// <summary> 
		/// Second configured DNS server. <br />
		/// </summary>
		///
		[JsonPropertyName("dns2")]
		public string? Dns2 { get; set; }
	
		/// <summary> 
		/// Domain name configured for the device. <br />
		/// </summary>
		///
		[JsonPropertyName("domainName")]
		public string? DomainName { get; set; }
	
		/// <summary> 
		/// IP address range. <br />
		/// </summary>
		///
		[JsonPropertyName("addressRange")]
		public AddressRange? PAddressRange { get; set; }
	
		/// <summary> 
		/// Indicator showing if the DHCP server is enabled. <br />
		/// </summary>
		///
		[JsonPropertyName("enabled")]
		public int? Enabled { get; set; }
	
		/// <summary> 
		/// IP address range. <br />
		/// </summary>
		///
		public sealed class AddressRange 
		{
		
			/// <summary> 
			/// Start of address range assigned to DHCP clients. <br />
			/// </summary>
			///
			[JsonPropertyName("start")]
			public string? Start { get; set; }
		
			/// <summary> 
			/// End of address range assigned to DHCP clients. <br />
			/// </summary>
			///
			[JsonPropertyName("end")]
			public string? End { get; set; }
		
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
