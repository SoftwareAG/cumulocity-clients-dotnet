///
/// C8yNetwork.cs
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
	/// <summary>
	/// Device capability to either display or display and manage the WAN, LAN, and DHCP settings.
	/// </summary>
	public class C8yNetwork 
	{
	
		/// <summary>
		/// Local network information.
		/// </summary>
		[JsonPropertyName("c8y_LAN")]
		public C8yLAN? PC8yLAN { get; set; }
	
		/// <summary>
		/// Mobile internet connectivity interface status.
		/// </summary>
		[JsonPropertyName("c8y_WAN")]
		public C8yWAN? PC8yWAN { get; set; }
	
		/// <summary>
		/// Information for DHCP server status.
		/// </summary>
		[JsonPropertyName("c8y_DHCP")]
		public C8yDHCP? PC8yDHCP { get; set; }
	
		/// <summary>
		/// Local network information.
		/// </summary>
		public class C8yLAN 
		{
		
			/// <summary>
			/// Subnet mask configured for the network interface.
			/// </summary>
			[JsonPropertyName("netmask")]
			public string? Netmask { get; set; }
		
			/// <summary>
			/// IP address configured for the network interface.
			/// </summary>
			[JsonPropertyName("ip")]
			public string? Ip { get; set; }
		
			/// <summary>
			/// Identifier for the network interface.
			/// </summary>
			[JsonPropertyName("name")]
			public string? Name { get; set; }
		
			/// <summary>
			/// Indicator showing if the interface is enabled.
			/// </summary>
			[JsonPropertyName("enabled")]
			public int? Enabled { get; set; }
		
			/// <summary>
			/// MAC address of the network interface.
			/// </summary>
			[JsonPropertyName("mac")]
			public string? Mac { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		/// <summary>
		/// Mobile internet connectivity interface status.
		/// </summary>
		public class C8yWAN 
		{
		
			/// <summary>
			/// SIM connectivity password.
			/// </summary>
			[JsonPropertyName("password")]
			public string? Password { get; set; }
		
			/// <summary>
			/// SIM connection status.
			/// </summary>
			[JsonPropertyName("simStatus")]
			public string? SimStatus { get; set; }
		
			/// <summary>
			/// Authentication type used by the SIM connectivity.
			/// </summary>
			[JsonPropertyName("authType")]
			public string? AuthType { get; set; }
		
			/// <summary>
			/// APN used for internet access.
			/// </summary>
			[JsonPropertyName("apn")]
			public string? Apn { get; set; }
		
			/// <summary>
			/// SIM connectivity username.
			/// </summary>
			[JsonPropertyName("username")]
			public string? Username { get; set; }
		
			public override string ToString()
			{
				return JsonSerializer.Serialize(this);
			}
		}
	
		/// <summary>
		/// Information for DHCP server status.
		/// </summary>
		public class C8yDHCP 
		{
		
			/// <summary>
			/// First configured DNS server.
			/// </summary>
			[JsonPropertyName("dns1")]
			public string? Dns1 { get; set; }
		
			/// <summary>
			/// Second configured DNS server.
			/// </summary>
			[JsonPropertyName("dns2")]
			public string? Dns2 { get; set; }
		
			/// <summary>
			/// Domain name configured for the device.
			/// </summary>
			[JsonPropertyName("domainName")]
			public string? DomainName { get; set; }
		
			/// <summary>
			/// IP address range.
			/// </summary>
			[JsonPropertyName("addressRange")]
			public AddressRange? PAddressRange { get; set; }
		
			/// <summary>
			/// Indicator showing if the DHCP server is enabled.
			/// </summary>
			[JsonPropertyName("enabled")]
			public int? Enabled { get; set; }
		
			/// <summary>
			/// IP address range.
			/// </summary>
			public class AddressRange 
			{
			
				/// <summary>
				/// Start of address range assigned to DHCP clients.
				/// </summary>
				[JsonPropertyName("start")]
				public string? Start { get; set; }
			
				/// <summary>
				/// End of address range assigned to DHCP clients.
				/// </summary>
				[JsonPropertyName("end")]
				public string? End { get; set; }
			
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
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
