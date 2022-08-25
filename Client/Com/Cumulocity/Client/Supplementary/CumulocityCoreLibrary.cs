///
/// CumulocityCoreLibrary.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Net.Http;
using Com.Cumulocity.Client.Api;

namespace Com.Cumulocity.Client.Supplementary 
{
	public class CumulocityCoreLibrary 
	{
		private static readonly CumulocityCoreLibrary instance = new();
		public static CumulocityCoreLibrary Instance
		{
			get
			{
				return instance;
			}
		}
	
		public HttpClient HttpClient { get; set; }
		public ApplicationsFactory Applications => new();
		public MeasurementsFactory Measurements => new();
		public AlarmsFactory Alarms => new();
		public TenantsFactory Tenants => new();
		public UsersFactory Users => new();
		public AuditsFactory Audits => new();
		public RealtimenotificationsFactory RealtimeNotifications => new();
		public EventsFactory Events => new();
		public Notifications20Factory Notifications20 => new();
		public RetentionsFactory Retentions => new();
		public IdentityFactory Identity => new();
		public DevicecontrolFactory DeviceControl => new();
		public InventoryFactory Inventory => new();
	
		private CumulocityCoreLibrary()
		{
			HttpClient = new();
		}
	
		public class ApplicationsFactory
		{
			public ApplicationsApi ApplicationsApi => new(Instance.HttpClient);
			public ApplicationBinariesApi ApplicationBinariesApi => new(Instance.HttpClient);
			public BootstrapUserApi BootstrapUserApi => new(Instance.HttpClient);
			public CurrentApplicationApi CurrentApplicationApi => new(Instance.HttpClient);
		}
	
		public class MeasurementsFactory
		{
			public MeasurementsApi MeasurementsApi => new(Instance.HttpClient);
		}
	
		public class AlarmsFactory
		{
			public AlarmsApi AlarmsApi => new(Instance.HttpClient);
		}
	
		public class TenantsFactory
		{
			public TenantsApi TenantsApi => new(Instance.HttpClient);
			public TenantApplicationsApi TenantApplicationsApi => new(Instance.HttpClient);
			public TrustedCertificatesApi TrustedCertificatesApi => new(Instance.HttpClient);
			public DeviceStatisticsApi DeviceStatisticsApi => new(Instance.HttpClient);
			public UsageStatisticsApi UsageStatisticsApi => new(Instance.HttpClient);
			public OptionsApi OptionsApi => new(Instance.HttpClient);
			public LoginOptionsApi LoginOptionsApi => new(Instance.HttpClient);
			public LoginTokensApi LoginTokensApi => new(Instance.HttpClient);
			public SystemOptionsApi SystemOptionsApi => new(Instance.HttpClient);
		}
	
		public class UsersFactory
		{
			public CurrentUserApi CurrentUserApi => new(Instance.HttpClient);
			public UsersApi UsersApi => new(Instance.HttpClient);
			public GroupsApi GroupsApi => new(Instance.HttpClient);
			public RolesApi RolesApi => new(Instance.HttpClient);
			public InventoryRolesApi InventoryRolesApi => new(Instance.HttpClient);
		}
	
		public class AuditsFactory
		{
			public AuditsApi AuditsApi => new(Instance.HttpClient);
		}
	
		public class RealtimenotificationsFactory
		{
			public RealtimeNotificationApi RealtimeNotificationApi => new(Instance.HttpClient);
		}
	
		public class EventsFactory
		{
			public EventsApi EventsApi => new(Instance.HttpClient);
			public AttachmentsApi AttachmentsApi => new(Instance.HttpClient);
		}
	
		public class Notifications20Factory
		{
			public SubscriptionsApi SubscriptionsApi => new(Instance.HttpClient);
			public TokensApi TokensApi => new(Instance.HttpClient);
		}
	
		public class RetentionsFactory
		{
			public RetentionRulesApi RetentionRulesApi => new(Instance.HttpClient);
		}
	
		public class IdentityFactory
		{
			public IdentityApi IdentityApi => new(Instance.HttpClient);
			public ExternalIDsApi ExternalIDsApi => new(Instance.HttpClient);
		}
	
		public class DevicecontrolFactory
		{
			public OperationsApi OperationsApi => new(Instance.HttpClient);
			public BulkOperationsApi BulkOperationsApi => new(Instance.HttpClient);
			public DeviceCredentialsApi DeviceCredentialsApi => new(Instance.HttpClient);
			public NewDeviceRequestsApi NewDeviceRequestsApi => new(Instance.HttpClient);
		}
	
		public class InventoryFactory
		{
			public InventoryApi InventoryApi => new(Instance.HttpClient);
			public ManagedObjectsApi ManagedObjectsApi => new(Instance.HttpClient);
			public BinariesApi BinariesApi => new(Instance.HttpClient);
			public ChildOperationsApi ChildOperationsApi => new(Instance.HttpClient);
		}
	}
}
