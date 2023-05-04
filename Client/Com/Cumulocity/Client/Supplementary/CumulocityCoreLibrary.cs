///
/// CumulocityCoreLibrary.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
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
			public IApplicationsApi ApplicationsApi => new ApplicationsApi(Instance.HttpClient);
			public IApplicationVersionsApi ApplicationVersionsApi => new ApplicationVersionsApi(Instance.HttpClient);
			public IApplicationBinariesApi ApplicationBinariesApi => new ApplicationBinariesApi(Instance.HttpClient);
			public IBootstrapUserApi BootstrapUserApi => new BootstrapUserApi(Instance.HttpClient);
			public ICurrentApplicationApi CurrentApplicationApi => new CurrentApplicationApi(Instance.HttpClient);
		}
	
		public class MeasurementsFactory
		{
			public IMeasurementsApi MeasurementsApi => new MeasurementsApi(Instance.HttpClient);
		}
	
		public class AlarmsFactory
		{
			public IAlarmsApi AlarmsApi => new AlarmsApi(Instance.HttpClient);
		}
	
		public class TenantsFactory
		{
			public ITenantsApi TenantsApi => new TenantsApi(Instance.HttpClient);
			public ITenantApplicationsApi TenantApplicationsApi => new TenantApplicationsApi(Instance.HttpClient);
			public ITrustedCertificatesApi TrustedCertificatesApi => new TrustedCertificatesApi(Instance.HttpClient);
			public IDeviceStatisticsApi DeviceStatisticsApi => new DeviceStatisticsApi(Instance.HttpClient);
			public IUsageStatisticsApi UsageStatisticsApi => new UsageStatisticsApi(Instance.HttpClient);
			public IOptionsApi OptionsApi => new OptionsApi(Instance.HttpClient);
			public ILoginOptionsApi LoginOptionsApi => new LoginOptionsApi(Instance.HttpClient);
			public ILoginTokensApi LoginTokensApi => new LoginTokensApi(Instance.HttpClient);
			public ISystemOptionsApi SystemOptionsApi => new SystemOptionsApi(Instance.HttpClient);
		}
	
		public class UsersFactory
		{
			public ICurrentUserApi CurrentUserApi => new CurrentUserApi(Instance.HttpClient);
			public IUsersApi UsersApi => new UsersApi(Instance.HttpClient);
			public IGroupsApi GroupsApi => new GroupsApi(Instance.HttpClient);
			public IRolesApi RolesApi => new RolesApi(Instance.HttpClient);
			public IInventoryRolesApi InventoryRolesApi => new InventoryRolesApi(Instance.HttpClient);
			public IDevicePermissionsApi DevicePermissionsApi => new DevicePermissionsApi(Instance.HttpClient);
		}
	
		public class AuditsFactory
		{
			public IAuditsApi AuditsApi => new AuditsApi(Instance.HttpClient);
		}
	
		public class RealtimenotificationsFactory
		{
			public IRealtimeNotificationApi RealtimeNotificationApi => new RealtimeNotificationApi(Instance.HttpClient);
		}
	
		public class EventsFactory
		{
			public IEventsApi EventsApi => new EventsApi(Instance.HttpClient);
			public IAttachmentsApi AttachmentsApi => new AttachmentsApi(Instance.HttpClient);
		}
	
		public class Notifications20Factory
		{
			public ISubscriptionsApi SubscriptionsApi => new SubscriptionsApi(Instance.HttpClient);
			public ITokensApi TokensApi => new TokensApi(Instance.HttpClient);
		}
	
		public class RetentionsFactory
		{
			public IRetentionRulesApi RetentionRulesApi => new RetentionRulesApi(Instance.HttpClient);
		}
	
		public class IdentityFactory
		{
			public IIdentityApi IdentityApi => new IdentityApi(Instance.HttpClient);
			public IExternalIDsApi ExternalIDsApi => new ExternalIDsApi(Instance.HttpClient);
		}
	
		public class DevicecontrolFactory
		{
			public IOperationsApi OperationsApi => new OperationsApi(Instance.HttpClient);
			public IBulkOperationsApi BulkOperationsApi => new BulkOperationsApi(Instance.HttpClient);
			public IDeviceCredentialsApi DeviceCredentialsApi => new DeviceCredentialsApi(Instance.HttpClient);
			public INewDeviceRequestsApi NewDeviceRequestsApi => new NewDeviceRequestsApi(Instance.HttpClient);
		}
	
		public class InventoryFactory
		{
			public IManagedObjectsApi ManagedObjectsApi => new ManagedObjectsApi(Instance.HttpClient);
			public IBinariesApi BinariesApi => new BinariesApi(Instance.HttpClient);
			public IChildOperationsApi ChildOperationsApi => new ChildOperationsApi(Instance.HttpClient);
		}
	}
}
