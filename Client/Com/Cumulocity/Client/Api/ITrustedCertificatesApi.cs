//
// ITrustedCertificatesApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// API methods for managing trusted certificates used to establish device connections via MQTT. <br />
/// More detailed information about trusted certificates and their role can be found in <see href="https://cumulocity.com/docs/device-management-application/managing-device-data/" langword="Device management > Device management application > Managing device data" /> in the Cumulocity IoT user documentation. <br />
/// ⓘ Info: The Accept header must be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public interface ITrustedCertificatesApi
{

	/// <summary> 
	/// Retrieve all stored certificates <br />
	/// Retrieve all the trusted certificates of a specific tenant (by a given ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND (is the current tenant) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the trusted certificates are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Tenant not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="currentPage">The current page of the paginated results. <br /></param>
	/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects. <br /></param>
	/// <param name="withTotalElements">When set to <c>true</c>, the returned result will contain in the statistics object the total number of elements. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	/// <param name="withTotalPages">When set to <c>true</c>, the returned result will contain in the statistics object the total number of pages. Only applicable on <see href="https://en.wikipedia.org/wiki/Range_query_(database)" langword="range queries" />. <br /></param>
	///
	Task<TrustedCertificateCollection?> GetTrustedCertificates(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Add a new certificate <br />
	/// Add a new trusted certificate to a specific tenant (by a given ID) which can be further used by the devices to establish connections with the Cumulocity IoT platform. <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND (is the current tenant) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 The certificate was added to the tenant. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Tenant not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 409 Duplicate – A certificate with the same fingerprint already exists. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – Invalid certificate data. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="addToTrustStore">If set to <c>true</c> the certificate is added to the truststore. <br />The truststore contains all trusted certificates. A connection to a device is only established if it connects to Cumulocity IoT with a certificate in the truststore. <br /></param>
	///
	Task<TrustedCertificate?> AddTrustedCertificate(UploadedTrustedCertificate body, string tenantId, string? xCumulocityProcessingMode = null, bool? addToTrustStore = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Add multiple certificates <br />
	/// Add multiple trusted certificates to a specific tenant (by a given ID) which can be further used by the devices to establish connections with the Cumulocity IoT platform. <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND (is the current tenant) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 The certificates were added to the tenant. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Tenant not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 409 Duplicate – A certificate with the same fingerprint already exists. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – Invalid certificates data. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	/// <param name="addToTrustStore">If set to <c>true</c> the certificate is added to the truststore. <br />The truststore contains all trusted certificates. A connection to a device is only established if it connects to Cumulocity IoT with a certificate in the truststore. <br /></param>
	///
	Task<TrustedCertificateCollection?> AddTrustedCertificates(UploadedTrustedCertificateCollection body, string tenantId, bool? addToTrustStore = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve a stored certificate <br />
	/// Retrieve the data of a stored trusted certificate (by a given fingerprint) of a specific tenant (by a given ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND (is the current tenant OR is the management tenant) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the trusted certificate is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="fingerprint">Unique identifier of a trusted certificate. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> GetTrustedCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Update a stored certificate <br />
	/// Update the data of a stored trusted certificate (by a given fingerprint) of a specific tenant (by a given ID). <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND (is the current tenant OR is the management tenant) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The certificate was updated on the tenant. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Certificate not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – invalid payload. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="fingerprint">Unique identifier of a trusted certificate. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> UpdateTrustedCertificate(TrustedCertificate body, string tenantId, string fingerprint, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Remove a stored certificate <br />
	/// Remove a stored trusted certificate (by a given fingerprint) from a specific tenant (by a given ID).When a trusted certificate is deleted, the established MQTT connection to all devices that are using the corresponding certificate are closed. <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND (is the current tenant OR is the management tenant) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 The trusted certificate was removed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Certificate not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="fingerprint">Unique identifier of a trusted certificate. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> RemoveTrustedCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Provide the proof of possession for an already uploaded certificate <br />
	/// Provide the proof of possession for a specific uploaded certificate (by a given fingerprint) for a specific tenant (by a given ID). <br />
	/// 
	/// <br />  <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND is the current tenant 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The provided signed verification code check was successful. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 400 The provided signed verification code is not correct. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Trusted certificate not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Proof of possession for the certificate was not confirmed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="fingerprint">Unique identifier of a trusted certificate. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> ProveCertificatePossession(UploadedTrustedCertSignedVerificationCode body, string tenantId, string fingerprint, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Confirm an already uploaded certificate <br />
	/// Confirm an already uploaded certificate (by a given fingerprint) for a specific tenant (by a given ID). <br />
	/// 
	/// <br />  <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND is the management tenant 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The certificate is confirmed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Trusted certificate not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 The verification was not successful. Certificate not confirmed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="fingerprint">Unique identifier of a trusted certificate. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> ConfirmCertificate(string tenantId, string fingerprint, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Generate a verification code for the proof of possession operation for the given certificate <br />
	/// Generate a verification code for the proof of possession operation for the certificate (by a given fingerprint). <br />
	/// 
	/// <br />  <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND is the current tenant 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The verification code was generated. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Trusted certificate not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="fingerprint">Unique identifier of a trusted certificate. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> GenerateVerificationCode(string tenantId, string fingerprint, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Verify a certificate chain <br />
	/// Verify a device certificate chain against a specific tenant using file upload or by HTTP headers.The tenant ID is <c>optional</c> and this api will try to resolve the tenant from the chain if not found in the request header.For file upload, the max chain length support is 10 and for a header it is 5. <br />
	/// If CRL (certificate revocation list) check is enabled on the tenant and the certificate chain is identified to be revoked during validation the further validation of the chain stops and returns unauthorized. <br />
	/// ⓘ Info: File upload takes precedence over HTTP headers if both are passed. <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_MANAGEMENT_READ) AND (is the current tenant OR is current management tenant) OR (is authenticated AND is current user service user) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The certificate chain is valid and not revoked. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 400 Unable to parse certificate chain. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 One or more certificates in the chain are revoked or the certificate chain is not valid. Revoked certificates are checked first, then the validity of the certificate chain. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 The tenant ID does not exist. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId"></param>
	/// <param name="file">File to be uploaded. <br /></param>
	/// <param name="xCumulocityTenantId">Used to send a tenant ID. <br /></param>
	/// <param name="xCumulocityClientCertChain">Used to send a certificate chain in the header. Separate the chain with <c>,</c> and also each 64 bit block with <c> </c> (a space character). <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<VerifyCertificateChain?> ValidateChain(string tenantId, byte[] file, string? xCumulocityTenantId = null, string? xCumulocityClientCertChain = null, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Get revoked certificates <br />
	/// This endpoint downloads current CRL file containing list of revoked certificate ina binary file format with <c>content-type</c> as <c>application/pkix-crl</c>. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The CRL file of the current tenant. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<System.IO.Stream> DownloadCrl(string tenantId, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Add revoked certificates <br />
	/// ⓘ Info: A certificate revocation list (CRL) is a list of digital certificatesthat have been revoked by the issuing certificate authority (CA) before expiration date.In Cumulocity IoT, a CRL check can be in online or offline mode or both. <br />
	/// An endpoint to add revoked certificate serial numbers for offline CRL check via payload or file. <br />
	/// For payload, a JSON object required with list of CRL entries, for example: <br />
	/// <![CDATA[
	///   {
	///    "crls": [
	///      {
	///        "serialNumberInHex": "1000",
	///        "revocationDate": "2023-01-11T16:12:36.288Z"
	///      }
	///     ]
	///    }
	/// ]]>
	/// Each entry is composed of: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>serialNumberInHex: Needs to be in <c>Hexadecimal Value</c>. e.g As (1000)^16 == (4096)^10, So we have to enter 1000.If duplicate serial number exists in payload, the existing entry stays</br> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description><c>revocationDate</c> - accepted Date format: <c>yyyy-MM-dd'T'HH:mm:ss.SSS'Z'</c>, for example: <c>2023-01-11T16:12:36.288Z</c>.This is an optional parameter and defaults to the current server UTC date time if not specified in the payload.If specified and the date is in future then those entries will be also defaulted to current date. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// For file upload, each file can hold at maximum 5000 revocation entries.Multiple upload is allowed.In case of duplicates, the latest (last uploaded) entry is considered. <br />
	/// See below for a sample CSV file: <br />
	/// | SERIAL NO.  | REVOCATION DATE ||--|--|| 1000 | 2023-01-11T16:12:36.288Z | <br />
	/// Each entry is composed of : <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>serialNumberInHex: Needs to be in <c>Hexadecimal Value</c>. e.g (1000)^16 == (4096)^10, So we have to enter 1000.If duplicate serial number exists in payload, the latest entry will be taken.</br> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>revocationDate: Accepted Date format: <c>yyyy-MM-dd'T'HH:mm:ss.SSS'Z'</c> e.g: 2023-01-11T16:12:36.288Z.This is an optional and will be default to current server UTC date time if not specified in payload.If specified and the date is in future then those entries will be skipped. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// The CRL setting for offline and online check can be enabled/disabled using <kbd><a href="#operation/putOptionResource">/tenant/options</a></kbd>.Keys are <c>crl.online.check.enabled</c> and <c>crl.offline.check.enabled</c> under the category <c>configuration</c>. <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND is the current tenant 
	/// 
	/// ⚠️ Important: According to CRL policy, added serial numbers cannot be reversed. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 CRLs updated successfully. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 400 Unsupported date time format. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> UpdateCRL(UpdateCRLEntries body, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Add revoked certificates <br />
	/// ⓘ Info: A certificate revocation list (CRL) is a list of digital certificatesthat have been revoked by the issuing certificate authority (CA) before expiration date.In Cumulocity IoT, a CRL check can be in online or offline mode or both. <br />
	/// An endpoint to add revoked certificate serial numbers for offline CRL check via payload or file. <br />
	/// For payload, a JSON object required with list of CRL entries, for example: <br />
	/// <![CDATA[
	///   {
	///    "crls": [
	///      {
	///        "serialNumberInHex": "1000",
	///        "revocationDate": "2023-01-11T16:12:36.288Z"
	///      }
	///     ]
	///    }
	/// ]]>
	/// Each entry is composed of: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>serialNumberInHex: Needs to be in <c>Hexadecimal Value</c>. e.g As (1000)^16 == (4096)^10, So we have to enter 1000.If duplicate serial number exists in payload, the existing entry stays</br> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description><c>revocationDate</c> - accepted Date format: <c>yyyy-MM-dd'T'HH:mm:ss.SSS'Z'</c>, for example: <c>2023-01-11T16:12:36.288Z</c>.This is an optional parameter and defaults to the current server UTC date time if not specified in the payload.If specified and the date is in future then those entries will be also defaulted to current date. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// For file upload, each file can hold at maximum 5000 revocation entries.Multiple upload is allowed.In case of duplicates, the latest (last uploaded) entry is considered. <br />
	/// See below for a sample CSV file: <br />
	/// | SERIAL NO.  | REVOCATION DATE ||--|--|| 1000 | 2023-01-11T16:12:36.288Z | <br />
	/// Each entry is composed of : <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>serialNumberInHex: Needs to be in <c>Hexadecimal Value</c>. e.g (1000)^16 == (4096)^10, So we have to enter 1000.If duplicate serial number exists in payload, the latest entry will be taken.</br> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>revocationDate: Accepted Date format: <c>yyyy-MM-dd'T'HH:mm:ss.SSS'Z'</c> e.g: 2023-01-11T16:12:36.288Z.This is an optional and will be default to current server UTC date time if not specified in payload.If specified and the date is in future then those entries will be skipped. <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// The CRL setting for offline and online check can be enabled/disabled using <kbd><a href="#operation/putOptionResource">/tenant/options</a></kbd>.Keys are <c>crl.online.check.enabled</c> and <c>crl.offline.check.enabled</c> under the category <c>configuration</c>. <br />
	/// 
	/// <br /> Required roles <br />
	///  (ROLE_TENANT_MANAGEMENT_ADMIN OR ROLE_TENANT_ADMIN) AND is the current tenant 
	/// 
	/// ⚠️ Important: According to CRL policy, added serial numbers cannot be reversed. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 204 CRLs updated successfully. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 400 Unsupported date time format. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="file">File to be uploaded. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> UpdateCRL(byte[] file, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Obtain device access token <br />
	/// Only those devices which are registered to use cert auth can authenticate via mTLS protocol and retrieve JWT token.To establish a Two-Way SSL (Mutual Authentication) connection, you must have the following: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>private_key <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>client certificate <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>certificate authority root certificate <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>certificate authority intermediate certificates (Optional) <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 Successfully retrieved device access token from device certificate. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 400 Unable to parse certificate chain. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 One or more certificates in the chain are revoked or the certificate chain is not valid. Revoked certificates are checked first, then the validity of the certificate chain. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Device access token feature is disabled. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 The verification was not successful. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="xSslCertChain">Used to send a certificate chain in the header. Separate the chain with <c> </c> (a space character) and also each 64 bit block with <c> </c> (a space character). <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<AccessToken?> ObtainAccessToken(string? xSslCertChain = null, CancellationToken cToken = default) ;
}
