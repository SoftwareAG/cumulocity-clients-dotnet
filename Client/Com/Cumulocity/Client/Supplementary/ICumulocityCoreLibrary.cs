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
		IApplicationsApi ApplicationsApi { get; }
		IApplicationVersionsApi ApplicationVersionsApi { get; }
		IApplicationBinariesApi ApplicationBinariesApi { get; }
		IBootstrapUserApi BootstrapUserApi { get; }
		ICurrentApplicationApi CurrentApplicationApi { get; }
	}

	public interface IMeasurementsFactory
	{
		IMeasurementsApi MeasurementsApi { get; }
	}

	public interface IAlarmsFactory
	{
		IAlarmsApi AlarmsApi { get; }
	}

	public interface ITenantsFactory
	{
		ITenantsApi TenantsApi { get; }
		ITenantApplicationsApi TenantApplicationsApi { get; }
		ITrustedCertificatesApi TrustedCertificatesApi { get; }
		IDeviceStatisticsApi DeviceStatisticsApi { get; }
		IUsageStatisticsApi UsageStatisticsApi { get; }
		IOptionsApi OptionsApi { get; }
		ILoginOptionsApi LoginOptionsApi { get; }
		ISystemOptionsApi SystemOptionsApi { get; }
	}

	public interface IUsersFactory
	{
		ICurrentUserApi CurrentUserApi { get; }
		IUsersApi UsersApi { get; }
		IGroupsApi GroupsApi { get; }
		IRolesApi RolesApi { get; }
		IInventoryRolesApi InventoryRolesApi { get; }
		IDevicePermissionsApi DevicePermissionsApi { get; }
	}

	public interface IAuditsFactory
	{
		IAuditsApi AuditsApi { get; }
	}

	public interface IRealtimeNotificationsFactory
	{
		IRealtimeNotificationApi RealtimeNotificationApi { get; }
	}

	public interface IEventsFactory
	{
		IEventsApi EventsApi { get; }
		IAttachmentsApi AttachmentsApi { get; }
	}

	public interface INotifications20Factory
	{
		ISubscriptionsApi SubscriptionsApi { get; }
		ITokensApi TokensApi { get; }
	}

	public interface IRetentionsFactory
	{
		IRetentionRulesApi RetentionRulesApi { get; }
	}

	public interface IDentityFactory
	{
		IIdentityApi IdentityApi { get; }
		IExternalIDsApi ExternalIDsApi { get; }
	}

	public interface IDeviceControlFactory
	{
		IOperationsApi OperationsApi { get; }
		IBulkOperationsApi BulkOperationsApi { get; }
		IDeviceCredentialsApi DeviceCredentialsApi { get; }
		INewDeviceRequestsApi NewDeviceRequestsApi { get; }
	}

	public interface INventoryFactory
	{
		IManagedObjectsApi ManagedObjectsApi { get; }
		IBinariesApi BinariesApi { get; }
		IChildOperationsApi ChildOperationsApi { get; }
	}
}
