//
// CumulocityCoreLibrary.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System;
using System.Net.Http;
using Client.Com.Cumulocity.Client.Api;
using static Client.Com.Cumulocity.Client.Supplementary.ICumulocityCoreLibrary;

namespace Client.Com.Cumulocity.Client.Supplementary;

public sealed class CumulocityCoreLibrary: ICumulocityCoreLibrary
{
	private readonly Lazy<IApplicationsFactory> _lazyApplications;
	private readonly Lazy<IMeasurementsFactory> _lazyMeasurements;
	private readonly Lazy<IAlarmsFactory> _lazyAlarms;
	private readonly Lazy<ITenantsFactory> _lazyTenants;
	private readonly Lazy<IUsersFactory> _lazyUsers;
	private readonly Lazy<IAuditsFactory> _lazyAudits;
	private readonly Lazy<IRealtimeNotificationsFactory> _lazyRealtimeNotifications;
	private readonly Lazy<IEventsFactory> _lazyEvents;
	private readonly Lazy<INotifications20Factory> _lazyNotifications20;
	private readonly Lazy<IRetentionsFactory> _lazyRetentions;
	private readonly Lazy<IDentityFactory> _lazyIdentity;
	private readonly Lazy<IDeviceControlFactory> _lazyDeviceControl;
	private readonly Lazy<INventoryFactory> _lazyInventory;

	public CumulocityCoreLibrary(HttpClient client)
	{
		_lazyApplications = new Lazy<IApplicationsFactory>(() => new ApplicationsFactory(client));
		_lazyMeasurements = new Lazy<IMeasurementsFactory>(() => new MeasurementsFactory(client));
		_lazyAlarms = new Lazy<IAlarmsFactory>(() => new AlarmsFactory(client));
		_lazyTenants = new Lazy<ITenantsFactory>(() => new TenantsFactory(client));
		_lazyUsers = new Lazy<IUsersFactory>(() => new UsersFactory(client));
		_lazyAudits = new Lazy<IAuditsFactory>(() => new AuditsFactory(client));
		_lazyRealtimeNotifications = new Lazy<IRealtimeNotificationsFactory>(() => new RealtimeNotificationsFactory(client));
		_lazyEvents = new Lazy<IEventsFactory>(() => new EventsFactory(client));
		_lazyNotifications20 = new Lazy<INotifications20Factory>(() => new Notifications20Factory(client));
		_lazyRetentions = new Lazy<IRetentionsFactory>(() => new RetentionsFactory(client));
		_lazyIdentity = new Lazy<IDentityFactory>(() => new IdentityFactory(client));
		_lazyDeviceControl = new Lazy<IDeviceControlFactory>(() => new DeviceControlFactory(client));
		_lazyInventory = new Lazy<INventoryFactory>(() => new InventoryFactory(client));
	}

	public CumulocityCoreLibrary(IHttpClientFactory clientFactory): this(clientFactory.CreateClient())
	{
	}

	public CumulocityCoreLibrary(IHttpClientFactory clientFactory, string clientName) : this(clientFactory.CreateClient(clientName))
	{
	}

	public IApplicationsFactory Applications => _lazyApplications.Value;
	public IMeasurementsFactory Measurements => _lazyMeasurements.Value;
	public IAlarmsFactory Alarms => _lazyAlarms.Value;
	public ITenantsFactory Tenants => _lazyTenants.Value;
	public IUsersFactory Users => _lazyUsers.Value;
	public IAuditsFactory Audits => _lazyAudits.Value;
	public IRealtimeNotificationsFactory RealtimeNotifications => _lazyRealtimeNotifications.Value;
	public IEventsFactory Events => _lazyEvents.Value;
	public INotifications20Factory Notifications20 => _lazyNotifications20.Value;
	public IRetentionsFactory Retentions => _lazyRetentions.Value;
	public IDentityFactory Identity => _lazyIdentity.Value;
	public IDeviceControlFactory DeviceControl => _lazyDeviceControl.Value;
	public INventoryFactory Inventory => _lazyInventory.Value;

	public class ApplicationsFactory: IApplicationsFactory
	{
		private readonly Lazy<IApplicationsApi> _lazyApplicationsApi;
		private readonly Lazy<IApplicationVersionsApi> _lazyApplicationVersionsApi;
		private readonly Lazy<IApplicationBinariesApi> _lazyApplicationBinariesApi;
		private readonly Lazy<IBootstrapUserApi> _lazyBootstrapUserApi;
		private readonly Lazy<ICurrentApplicationApi> _lazyCurrentApplicationApi;

		internal ApplicationsFactory(HttpClient client)
		{
			_lazyApplicationsApi = new Lazy<IApplicationsApi>(() => new ApplicationsApi(client));
			_lazyApplicationVersionsApi = new Lazy<IApplicationVersionsApi>(() => new ApplicationVersionsApi(client));
			_lazyApplicationBinariesApi = new Lazy<IApplicationBinariesApi>(() => new ApplicationBinariesApi(client));
			_lazyBootstrapUserApi = new Lazy<IBootstrapUserApi>(() => new BootstrapUserApi(client));
			_lazyCurrentApplicationApi = new Lazy<ICurrentApplicationApi>(() => new CurrentApplicationApi(client));
		}
		
		public IApplicationsApi ApplicationsApi => _lazyApplicationsApi.Value;
		public IApplicationVersionsApi ApplicationVersionsApi => _lazyApplicationVersionsApi.Value;
		public IApplicationBinariesApi ApplicationBinariesApi => _lazyApplicationBinariesApi.Value;
		public IBootstrapUserApi BootstrapUserApi => _lazyBootstrapUserApi.Value;
		public ICurrentApplicationApi CurrentApplicationApi => _lazyCurrentApplicationApi.Value;
	}

	public class MeasurementsFactory: IMeasurementsFactory
	{
		private readonly Lazy<IMeasurementsApi> _lazyMeasurementsApi;

		internal MeasurementsFactory(HttpClient client)
		{
			_lazyMeasurementsApi = new Lazy<IMeasurementsApi>(() => new MeasurementsApi(client));
		}
		
		public IMeasurementsApi MeasurementsApi => _lazyMeasurementsApi.Value;
	}

	public class AlarmsFactory: IAlarmsFactory
	{
		private readonly Lazy<IAlarmsApi> _lazyAlarmsApi;

		internal AlarmsFactory(HttpClient client)
		{
			_lazyAlarmsApi = new Lazy<IAlarmsApi>(() => new AlarmsApi(client));
		}
		
		public IAlarmsApi AlarmsApi => _lazyAlarmsApi.Value;
	}

	public class TenantsFactory: ITenantsFactory
	{
		private readonly Lazy<ITenantsApi> _lazyTenantsApi;
		private readonly Lazy<ITenantApplicationsApi> _lazyTenantApplicationsApi;
		private readonly Lazy<ITrustedCertificatesApi> _lazyTrustedCertificatesApi;
		private readonly Lazy<IDeviceStatisticsApi> _lazyDeviceStatisticsApi;
		private readonly Lazy<IUsageStatisticsApi> _lazyUsageStatisticsApi;
		private readonly Lazy<IOptionsApi> _lazyOptionsApi;
		private readonly Lazy<ILoginOptionsApi> _lazyLoginOptionsApi;
		private readonly Lazy<ISystemOptionsApi> _lazySystemOptionsApi;

		internal TenantsFactory(HttpClient client)
		{
			_lazyTenantsApi = new Lazy<ITenantsApi>(() => new TenantsApi(client));
			_lazyTenantApplicationsApi = new Lazy<ITenantApplicationsApi>(() => new TenantApplicationsApi(client));
			_lazyTrustedCertificatesApi = new Lazy<ITrustedCertificatesApi>(() => new TrustedCertificatesApi(client));
			_lazyDeviceStatisticsApi = new Lazy<IDeviceStatisticsApi>(() => new DeviceStatisticsApi(client));
			_lazyUsageStatisticsApi = new Lazy<IUsageStatisticsApi>(() => new UsageStatisticsApi(client));
			_lazyOptionsApi = new Lazy<IOptionsApi>(() => new OptionsApi(client));
			_lazyLoginOptionsApi = new Lazy<ILoginOptionsApi>(() => new LoginOptionsApi(client));
			_lazySystemOptionsApi = new Lazy<ISystemOptionsApi>(() => new SystemOptionsApi(client));
		}
		
		public ITenantsApi TenantsApi => _lazyTenantsApi.Value;
		public ITenantApplicationsApi TenantApplicationsApi => _lazyTenantApplicationsApi.Value;
		public ITrustedCertificatesApi TrustedCertificatesApi => _lazyTrustedCertificatesApi.Value;
		public IDeviceStatisticsApi DeviceStatisticsApi => _lazyDeviceStatisticsApi.Value;
		public IUsageStatisticsApi UsageStatisticsApi => _lazyUsageStatisticsApi.Value;
		public IOptionsApi OptionsApi => _lazyOptionsApi.Value;
		public ILoginOptionsApi LoginOptionsApi => _lazyLoginOptionsApi.Value;
		public ISystemOptionsApi SystemOptionsApi => _lazySystemOptionsApi.Value;
	}

	public class UsersFactory: IUsersFactory
	{
		private readonly Lazy<ICurrentUserApi> _lazyCurrentUserApi;
		private readonly Lazy<IUsersApi> _lazyUsersApi;
		private readonly Lazy<IGroupsApi> _lazyGroupsApi;
		private readonly Lazy<IRolesApi> _lazyRolesApi;
		private readonly Lazy<IInventoryRolesApi> _lazyInventoryRolesApi;
		private readonly Lazy<IDevicePermissionsApi> _lazyDevicePermissionsApi;

		internal UsersFactory(HttpClient client)
		{
			_lazyCurrentUserApi = new Lazy<ICurrentUserApi>(() => new CurrentUserApi(client));
			_lazyUsersApi = new Lazy<IUsersApi>(() => new UsersApi(client));
			_lazyGroupsApi = new Lazy<IGroupsApi>(() => new GroupsApi(client));
			_lazyRolesApi = new Lazy<IRolesApi>(() => new RolesApi(client));
			_lazyInventoryRolesApi = new Lazy<IInventoryRolesApi>(() => new InventoryRolesApi(client));
			_lazyDevicePermissionsApi = new Lazy<IDevicePermissionsApi>(() => new DevicePermissionsApi(client));
		}
		
		public ICurrentUserApi CurrentUserApi => _lazyCurrentUserApi.Value;
		public IUsersApi UsersApi => _lazyUsersApi.Value;
		public IGroupsApi GroupsApi => _lazyGroupsApi.Value;
		public IRolesApi RolesApi => _lazyRolesApi.Value;
		public IInventoryRolesApi InventoryRolesApi => _lazyInventoryRolesApi.Value;
		public IDevicePermissionsApi DevicePermissionsApi => _lazyDevicePermissionsApi.Value;
	}

	public class AuditsFactory: IAuditsFactory
	{
		private readonly Lazy<IAuditsApi> _lazyAuditsApi;

		internal AuditsFactory(HttpClient client)
		{
			_lazyAuditsApi = new Lazy<IAuditsApi>(() => new AuditsApi(client));
		}
		
		public IAuditsApi AuditsApi => _lazyAuditsApi.Value;
	}

	public class RealtimeNotificationsFactory: IRealtimeNotificationsFactory
	{
		private readonly Lazy<IRealtimeNotificationApi> _lazyRealtimeNotificationApi;

		internal RealtimeNotificationsFactory(HttpClient client)
		{
			_lazyRealtimeNotificationApi = new Lazy<IRealtimeNotificationApi>(() => new RealtimeNotificationApi(client));
		}
		
		public IRealtimeNotificationApi RealtimeNotificationApi => _lazyRealtimeNotificationApi.Value;
	}

	public class EventsFactory: IEventsFactory
	{
		private readonly Lazy<IEventsApi> _lazyEventsApi;
		private readonly Lazy<IAttachmentsApi> _lazyAttachmentsApi;

		internal EventsFactory(HttpClient client)
		{
			_lazyEventsApi = new Lazy<IEventsApi>(() => new EventsApi(client));
			_lazyAttachmentsApi = new Lazy<IAttachmentsApi>(() => new AttachmentsApi(client));
		}
		
		public IEventsApi EventsApi => _lazyEventsApi.Value;
		public IAttachmentsApi AttachmentsApi => _lazyAttachmentsApi.Value;
	}

	public class Notifications20Factory: INotifications20Factory
	{
		private readonly Lazy<ISubscriptionsApi> _lazySubscriptionsApi;
		private readonly Lazy<ITokensApi> _lazyTokensApi;

		internal Notifications20Factory(HttpClient client)
		{
			_lazySubscriptionsApi = new Lazy<ISubscriptionsApi>(() => new SubscriptionsApi(client));
			_lazyTokensApi = new Lazy<ITokensApi>(() => new TokensApi(client));
		}
		
		public ISubscriptionsApi SubscriptionsApi => _lazySubscriptionsApi.Value;
		public ITokensApi TokensApi => _lazyTokensApi.Value;
	}

	public class RetentionsFactory: IRetentionsFactory
	{
		private readonly Lazy<IRetentionRulesApi> _lazyRetentionRulesApi;

		internal RetentionsFactory(HttpClient client)
		{
			_lazyRetentionRulesApi = new Lazy<IRetentionRulesApi>(() => new RetentionRulesApi(client));
		}
		
		public IRetentionRulesApi RetentionRulesApi => _lazyRetentionRulesApi.Value;
	}

	public class IdentityFactory: IDentityFactory
	{
		private readonly Lazy<IIdentityApi> _lazyIdentityApi;
		private readonly Lazy<IExternalIDsApi> _lazyExternalIDsApi;

		internal IdentityFactory(HttpClient client)
		{
			_lazyIdentityApi = new Lazy<IIdentityApi>(() => new IdentityApi(client));
			_lazyExternalIDsApi = new Lazy<IExternalIDsApi>(() => new ExternalIDsApi(client));
		}
		
		public IIdentityApi IdentityApi => _lazyIdentityApi.Value;
		public IExternalIDsApi ExternalIDsApi => _lazyExternalIDsApi.Value;
	}

	public class DeviceControlFactory: IDeviceControlFactory
	{
		private readonly Lazy<IOperationsApi> _lazyOperationsApi;
		private readonly Lazy<IBulkOperationsApi> _lazyBulkOperationsApi;
		private readonly Lazy<IDeviceCredentialsApi> _lazyDeviceCredentialsApi;
		private readonly Lazy<INewDeviceRequestsApi> _lazyNewDeviceRequestsApi;

		internal DeviceControlFactory(HttpClient client)
		{
			_lazyOperationsApi = new Lazy<IOperationsApi>(() => new OperationsApi(client));
			_lazyBulkOperationsApi = new Lazy<IBulkOperationsApi>(() => new BulkOperationsApi(client));
			_lazyDeviceCredentialsApi = new Lazy<IDeviceCredentialsApi>(() => new DeviceCredentialsApi(client));
			_lazyNewDeviceRequestsApi = new Lazy<INewDeviceRequestsApi>(() => new NewDeviceRequestsApi(client));
		}
		
		public IOperationsApi OperationsApi => _lazyOperationsApi.Value;
		public IBulkOperationsApi BulkOperationsApi => _lazyBulkOperationsApi.Value;
		public IDeviceCredentialsApi DeviceCredentialsApi => _lazyDeviceCredentialsApi.Value;
		public INewDeviceRequestsApi NewDeviceRequestsApi => _lazyNewDeviceRequestsApi.Value;
	}

	public class InventoryFactory: INventoryFactory
	{
		private readonly Lazy<IManagedObjectsApi> _lazyManagedObjectsApi;
		private readonly Lazy<IBinariesApi> _lazyBinariesApi;
		private readonly Lazy<IChildOperationsApi> _lazyChildOperationsApi;

		internal InventoryFactory(HttpClient client)
		{
			_lazyManagedObjectsApi = new Lazy<IManagedObjectsApi>(() => new ManagedObjectsApi(client));
			_lazyBinariesApi = new Lazy<IBinariesApi>(() => new BinariesApi(client));
			_lazyChildOperationsApi = new Lazy<IChildOperationsApi>(() => new ChildOperationsApi(client));
		}
		
		public IManagedObjectsApi ManagedObjectsApi => _lazyManagedObjectsApi.Value;
		public IBinariesApi BinariesApi => _lazyBinariesApi.Value;
		public IChildOperationsApi ChildOperationsApi => _lazyChildOperationsApi.Value;
	}
}
