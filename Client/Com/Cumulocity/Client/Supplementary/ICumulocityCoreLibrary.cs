//
// ICumulocityCoreLibrary.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System;
using System.Net.Http;
using Client.Com.Cumulocity.Client.Api;

namespace Client.Com.Cumulocity.Client.Supplementary;

public interface ICumulocityCoreLibrary 
{
	IApplicationsFactory Applications { get; }
	IMeasurementsFactory Measurements { get; }
	IAlarmsFactory Alarms { get; }
	ITenantsFactory Tenants { get; }
	IUsersFactory Users { get; }
	IAuditsFactory Audits { get; }
	IRealtimeNotificationsFactory RealtimeNotifications { get; }
	IEventsFactory Events { get; }
	INotifications20Factory Notifications20 { get; }
	IRetentionsFactory Retentions { get; }
	IDentityFactory Identity { get; }
	IDeviceControlFactory DeviceControl { get; }
	INventoryFactory Inventory { get; }

	public interface IApplicationsFactory
	{
		public IApplicationsApi ApplicationsApi { get; }
		public IApplicationVersionsApi ApplicationVersionsApi { get; }
		public IApplicationBinariesApi ApplicationBinariesApi { get; }
		public IBootstrapUserApi BootstrapUserApi { get; }
		public ICurrentApplicationApi CurrentApplicationApi { get; }
	}

	public interface IMeasurementsFactory
	{
		public IMeasurementsApi MeasurementsApi { get; }
	}

	public interface IAlarmsFactory
	{
		public IAlarmsApi AlarmsApi { get; }
	}

	public interface ITenantsFactory
	{
		public ITenantsApi TenantsApi { get; }
		public ITenantApplicationsApi TenantApplicationsApi { get; }
		public ITrustedCertificatesApi TrustedCertificatesApi { get; }
		public IDeviceStatisticsApi DeviceStatisticsApi { get; }
		public IUsageStatisticsApi UsageStatisticsApi { get; }
		public IOptionsApi OptionsApi { get; }
		public ILoginOptionsApi LoginOptionsApi { get; }
		public ISystemOptionsApi SystemOptionsApi { get; }
	}

	public interface IUsersFactory
	{
		public ICurrentUserApi CurrentUserApi { get; }
		public IUsersApi UsersApi { get; }
		public IGroupsApi GroupsApi { get; }
		public IRolesApi RolesApi { get; }
		public IInventoryRolesApi InventoryRolesApi { get; }
		public IDevicePermissionsApi DevicePermissionsApi { get; }
	}

	public interface IAuditsFactory
	{
		public IAuditsApi AuditsApi { get; }
	}

	public interface IRealtimeNotificationsFactory
	{
		public IRealtimeNotificationApi RealtimeNotificationApi { get; }
	}

	public interface IEventsFactory
	{
		public IEventsApi EventsApi { get; }
		public IAttachmentsApi AttachmentsApi { get; }
	}

	public interface INotifications20Factory
	{
		public ISubscriptionsApi SubscriptionsApi { get; }
		public ITokensApi TokensApi { get; }
	}

	public interface IRetentionsFactory
	{
		public IRetentionRulesApi RetentionRulesApi { get; }
	}

	public interface IDentityFactory
	{
		public IIdentityApi IdentityApi { get; }
		public IExternalIDsApi ExternalIDsApi { get; }
	}

	public interface IDeviceControlFactory
	{
		public IOperationsApi OperationsApi { get; }
		public IBulkOperationsApi BulkOperationsApi { get; }
		public IDeviceCredentialsApi DeviceCredentialsApi { get; }
		public INewDeviceRequestsApi NewDeviceRequestsApi { get; }
	}

	public interface INventoryFactory
	{
		public IManagedObjectsApi ManagedObjectsApi { get; }
		public IBinariesApi BinariesApi { get; }
		public IChildOperationsApi ChildOperationsApi { get; }
	}
}
