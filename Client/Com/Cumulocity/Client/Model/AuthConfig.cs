//
// AuthConfig.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Parameters determining the authentication process. <br />
/// </summary>
///
public sealed class AuthConfig 
{

	/// <summary> 
	/// SSO specific. Describes the fields in the access token from the external server containing user information. <br />
	/// </summary>
	///
	[JsonPropertyName("accessTokenToUserDataMapping")]
	public AccessTokenToUserDataMapping? PAccessTokenToUserDataMapping { get; set; }

	/// <summary> 
	/// SSO specific. Token audience. <br />
	/// </summary>
	///
	[JsonPropertyName("audience")]
	public string? Audience { get; set; }

	[JsonPropertyName("authorizationRequest")]
	public RequestRepresentation? AuthorizationRequest { get; set; }

	/// <summary> 
	/// For basic authentication case only. <br />
	/// </summary>
	///
	[JsonPropertyName("authenticationRestrictions")]
	public BasicAuthenticationRestrictions? AuthenticationRestrictions { get; set; }

	/// <summary> 
	/// SSO specific. Information for the UI about the name displayed on the external server login button. <br />
	/// </summary>
	///
	[JsonPropertyName("buttonName")]
	public string? ButtonName { get; set; }

	/// <summary> 
	/// SSO specific. The identifier of the Cumulocity IoT tenant on the external authorization server. <br />
	/// </summary>
	///
	[JsonPropertyName("clientId")]
	public string? ClientId { get; set; }

	/// <summary> 
	/// The authentication configuration grant type identifier. <br />
	/// </summary>
	///
	[JsonPropertyName("grantType")]
	public GrantType? PGrantType { get; set; }

	/// <summary> 
	/// Unique identifier of this login option. <br />
	/// </summary>
	///
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary> 
	/// SSO specific. External token issuer. <br />
	/// </summary>
	///
	[JsonPropertyName("issuer")]
	public string? Issuer { get; set; }

	[JsonPropertyName("logoutRequest")]
	public RequestRepresentation? LogoutRequest { get; set; }

	/// <summary> 
	/// Indicates whether the configuration is only accessible to the management tenant. <br />
	/// </summary>
	///
	[JsonPropertyName("onlyManagementTenantAccess")]
	public bool? OnlyManagementTenantAccess { get; set; }

	/// <summary> 
	/// SSO specific. Describes the process of internal user creation during login with the external authorization server. <br />
	/// </summary>
	///
	[JsonPropertyName("onNewUser")]
	public OnNewUser? POnNewUser { get; set; }

	/// <summary> 
	/// The name of the authentication provider. <br />
	/// </summary>
	///
	[JsonPropertyName("providerName")]
	public string? ProviderName { get; set; }

	/// <summary> 
	/// SSO specific. URL used for redirecting to the Cumulocity IoT platform. <br />
	/// </summary>
	///
	[JsonPropertyName("redirectToPlatform")]
	public string? RedirectToPlatform { get; set; }

	[JsonPropertyName("refreshRequest")]
	public RequestRepresentation? RefreshRequest { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	/// <summary> 
	/// The session configuration properties are only available for OAuth internal. See <see href="https://cumulocity.com/guides/10.11.0/users-guide/administration/#oauth-internal" langword="Administration > Changing settings > OAuth internal" /> in the 10.11.0 user guide for more details. <br />
	/// </summary>
	///
	[JsonPropertyName("sessionConfiguration")]
	public OAuthSessionConfiguration? SessionConfiguration { get; set; }

	/// <summary> 
	/// SSO specific and authorization server dependent. Describes the method of access token signature verification on the Cumulocity IoT platform. <br />
	/// </summary>
	///
	[JsonPropertyName("signatureVerificationConfig")]
	public SignatureVerificationConfig? PSignatureVerificationConfig { get; set; }

	/// <summary> 
	/// SSO specific. Template name used by the UI. <br />
	/// </summary>
	///
	[JsonPropertyName("template")]
	public string? Template { get; set; }

	[JsonPropertyName("tokenRequest")]
	public RequestRepresentation? TokenRequest { get; set; }

	/// <summary> 
	/// The authentication configuration type. Note that the value is case insensitive. <br />
	/// </summary>
	///
	[JsonPropertyName("type")]
	public Type? PType { get; set; }

	/// <summary> 
	/// SSO specific. Points to the field in the obtained JWT access token that should be used as the username in the Cumulocity IoT platform. <br />
	/// </summary>
	///
	[JsonPropertyName("userIdConfig")]
	public UserIdConfig? PUserIdConfig { get; set; }

	/// <summary> 
	/// Indicates whether user data are managed internally by the Cumulocity IoT platform or by an external server. Note that the value is case insensitive. <br />
	/// </summary>
	///
	[JsonPropertyName("userManagementSource")]
	public UserManagementSource? PUserManagementSource { get; set; }

	/// <summary> 
	/// Information for the UI if the respective authentication form should be visible for the user. <br />
	/// </summary>
	///
	[JsonPropertyName("visibleOnLoginPage")]
	public bool? VisibleOnLoginPage { get; set; }

	/// <summary> 
	/// A configuration for authentication with an access token from the authorization server. <br />
	/// </summary>
	///
	[JsonPropertyName("externalTokenConfig")]
	public ExternalTokenConfig? PExternalTokenConfig { get; set; }

	public AuthConfig() 
	{
	}

	public AuthConfig(string providerName, Type type)
	{
		this.ProviderName = providerName;
		this.PType = type;
	}

	/// <summary> 
	/// The authentication configuration grant type identifier. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum GrantType 
	{
		[EnumMember(Value = "AUTHORIZATION_CODE")]
		AUTHORIZATIONCODE,
		[EnumMember(Value = "PASSWORD")]
		PASSWORD
	}

	/// <summary> 
	/// The authentication configuration type. Note that the value is case insensitive. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Type 
	{
		[EnumMember(Value = "BASIC")]
		BASIC,
		[EnumMember(Value = "OAUTH2")]
		OAUTH2,
		[EnumMember(Value = "OAUTH2_INTERNAL")]
		OAUTH2INTERNAL
	}

	/// <summary> 
	/// Indicates whether user data are managed internally by the Cumulocity IoT platform or by an external server. Note that the value is case insensitive. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum UserManagementSource 
	{
		[EnumMember(Value = "INTERNAL")]
		INTERNAL,
		[EnumMember(Value = "REMOTE")]
		REMOTE
	}

	/// <summary> 
	/// SSO specific. Describes the fields in the access token from the external server containing user information. <br />
	/// </summary>
	///
	public sealed class AccessTokenToUserDataMapping 
	{
	
		/// <summary> 
		/// The name of the field containing the user's email. <br />
		/// </summary>
		///
		[JsonPropertyName("emailClaimName")]
		public string? EmailClaimName { get; set; }
	
		/// <summary> 
		/// The name of the field containing the user's first name. <br />
		/// </summary>
		///
		[JsonPropertyName("firstNameClaimName")]
		public string? FirstNameClaimName { get; set; }
	
		/// <summary> 
		/// The name of the field containing the user's last name. <br />
		/// </summary>
		///
		[JsonPropertyName("lastNameClaimName")]
		public string? LastNameClaimName { get; set; }
	
		/// <summary> 
		/// The name of the field containing the user's phone number. <br />
		/// </summary>
		///
		[JsonPropertyName("phoneNumberClaimName")]
		public string? PhoneNumberClaimName { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}


	/// <summary> 
	/// SSO specific. Describes the process of internal user creation during login with the external authorization server. <br />
	/// </summary>
	///
	public sealed class OnNewUser 
	{
	
		/// <summary> 
		/// Modern version of configuration of default groups and applications. This ensures backward compatibility. <br />
		/// </summary>
		///
		[JsonPropertyName("dynamicMapping")]
		public DynamicMapping? PDynamicMapping { get; set; }
	
		/// <summary> 
		/// Modern version of configuration of default groups and applications. This ensures backward compatibility. <br />
		/// </summary>
		///
		public sealed class DynamicMapping 
		{
		
			/// <summary> 
			/// Configuration of the mapping. <br />
			/// </summary>
			///
			[JsonPropertyName("configuration")]
			public Configuration? PConfiguration { get; set; }
		
			/// <summary> 
			/// Represents rules used to assign groups and applications. <br />
			/// </summary>
			///
			[JsonPropertyName("mappings")]
			public List<Mappings> PMappings { get; set; } = new List<Mappings>();
		
			/// <summary> 
			/// Represents rules used to assign inventory roles. <br />
			/// </summary>
			///
			[JsonPropertyName("inventoryMappings")]
			public List<InventoryMappings> PInventoryMappings { get; set; } = new List<InventoryMappings>();
		
			/// <summary> 
			/// Configuration of the mapping. <br />
			/// </summary>
			///
			public sealed class Configuration 
			{
			
				/// <summary> 
				/// Indicates whether the mapping should be evaluated always or only during the first external login when the internal user is created. <br />
				/// </summary>
				///
				[JsonPropertyName("mapRolesOnlyForNewUser")]
				public bool? MapRolesOnlyForNewUser { get; set; }
			
				/// <summary> 
				/// If set to <c>true</c>, dynamic access mapping is only managed for global roles, applications and inventory roles which are listed in the configuration. Others remain unchanged. <br />
				/// </summary>
				///
				[JsonPropertyName("manageRolesOnlyFromAccessMapping")]
				public bool? ManageRolesOnlyFromAccessMapping { get; set; }
			
				public override string ToString()
				{
					return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
				}
			}
		
			/// <summary> 
			/// Represents information of mapping access to groups and applications. <br />
			/// </summary>
			///
			public sealed class Mappings 
			{
			
				/// <summary> 
				/// Represents a predicate for verification. It acts as a condition which is necessary to assign a user to the given groups, permit access to the specified applications or to assign specific inventory roles to device groups. <br />
				/// </summary>
				///
				[JsonPropertyName("when")]
				public JSONPredicateRepresentation? When { get; set; }
			
				/// <summary> 
				/// List of the applications' identifiers. <br />
				/// </summary>
				///
				[JsonPropertyName("thenApplications")]
				public List<int> ThenApplications { get; set; } = new List<int>();
			
				/// <summary> 
				/// List of the groups' identifiers. <br />
				/// </summary>
				///
				[JsonPropertyName("thenGroups")]
				public List<int> ThenGroups { get; set; } = new List<int>();
			
				public override string ToString()
				{
					return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
				}
			}
		
			/// <summary> 
			/// Represents information of mapping access to inventory roles. <br />
			/// </summary>
			///
			public sealed class InventoryMappings 
			{
			
				/// <summary> 
				/// Represents a predicate for verification. It acts as a condition which is necessary to assign a user to the given groups, permit access to the specified applications or to assign specific inventory roles to device groups. <br />
				/// </summary>
				///
				[JsonPropertyName("when")]
				public JSONPredicateRepresentation? When { get; set; }
			
				/// <summary> 
				/// List of the OAuth inventory assignments. <br />
				/// </summary>
				///
				[JsonPropertyName("thenInventoryRoles")]
				public List<ThenInventoryRoles> PThenInventoryRoles { get; set; } = new List<ThenInventoryRoles>();
			
				/// <summary> 
				/// Represents inventory roles for a specific device group. <br />
				/// </summary>
				///
				public sealed class ThenInventoryRoles 
				{
				
					/// <summary> 
					/// A unique identifier for the managed object for which the roles are assigned. <br />
					/// </summary>
					///
					[JsonPropertyName("managedObject")]
					public string? ManagedObject { get; set; }
				
					/// <summary> 
					/// List of the inventory roles' identifiers. <br />
					/// </summary>
					///
					[JsonPropertyName("roleIds")]
					public List<int> RoleIds { get; set; } = new List<int>();
				
					public override string ToString()
					{
						return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
					}
				}
			
				public override string ToString()
				{
					return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
				}
			}
		
			public override string ToString()
			{
				return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	/// <summary> 
	/// SSO specific and authorization server dependent. Describes the method of access token signature verification on the Cumulocity IoT platform. <br />
	/// </summary>
	///
	public sealed class SignatureVerificationConfig 
	{
	
		/// <summary> 
		/// AAD signature verification configuration. <br />
		/// </summary>
		///
		[JsonPropertyName("aad")]
		public Aad? PAad { get; set; }
	
		/// <summary> 
		/// ADFS manifest signature verification configuration. <br />
		/// </summary>
		///
		[JsonPropertyName("adfsManifest")]
		public AdfsManifest? PAdfsManifest { get; set; }
	
		/// <summary> 
		/// The address of the endpoint which is used to retrieve the public key used to verify the JWT access token signature. <br />
		/// </summary>
		///
		[JsonPropertyName("jwks")]
		public Jwks? PJwks { get; set; }
	
		/// <summary> 
		/// Describes the process of verification of JWT access token with the public keys embedded in the provided X.509 certificates. <br />
		/// </summary>
		///
		[JsonPropertyName("manual")]
		public Manual? PManual { get; set; }
	
		/// <summary> 
		/// AAD signature verification configuration. <br />
		/// </summary>
		///
		public sealed class Aad 
		{
		
			/// <summary> 
			/// URL used to retrieve the public key used for signature verification. <br />
			/// </summary>
			///
			[JsonPropertyName("publicKeyDiscoveryUrl")]
			public string? PublicKeyDiscoveryUrl { get; set; }
		
			public override string ToString()
			{
				return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
			}
		}
	
		/// <summary> 
		/// ADFS manifest signature verification configuration. <br />
		/// </summary>
		///
		public sealed class AdfsManifest 
		{
		
			/// <summary> 
			/// The URI to the manifest resource. <br />
			/// </summary>
			///
			[JsonPropertyName("manifestUrl")]
			public string? ManifestUrl { get; set; }
		
			public override string ToString()
			{
				return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
			}
		}
	
		/// <summary> 
		/// The address of the endpoint which is used to retrieve the public key used to verify the JWT access token signature. <br />
		/// </summary>
		///
		public sealed class Jwks 
		{
		
			/// <summary> 
			/// The URI to the public key resource. <br />
			/// </summary>
			///
			[JsonPropertyName("jwksUrl")]
			public string? JwksUrl { get; set; }
		
			public override string ToString()
			{
				return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
			}
		}
	
		/// <summary> 
		/// Describes the process of verification of JWT access token with the public keys embedded in the provided X.509 certificates. <br />
		/// </summary>
		///
		public sealed class Manual 
		{
		
			/// <summary> 
			/// The name of the field in the JWT access token containing the certificate identifier. <br />
			/// </summary>
			///
			[JsonPropertyName("certIdField")]
			public string? CertIdField { get; set; }
		
			/// <summary> 
			/// Indicates whether the certificate identifier should be read from the JWT access token. <br />
			/// </summary>
			///
			[JsonPropertyName("certIdFromField")]
			public bool? CertIdFromField { get; set; }
		
			/// <summary> 
			/// Details of the certificates. <br />
			/// </summary>
			///
			[JsonPropertyName("certificates")]
			public Certificates? PCertificates { get; set; }
		
			/// <summary> 
			/// Details of the certificates. <br />
			/// </summary>
			///
			public sealed class Certificates 
			{
			
				/// <summary> 
				/// The signing algorithm of the JWT access token. <br />
				/// </summary>
				///
				[JsonPropertyName("alg")]
				public Alg? PAlg { get; set; }
			
				/// <summary> 
				/// The public key certificate. <br />
				/// </summary>
				///
				[JsonPropertyName("publicKey")]
				public string? PublicKey { get; set; }
			
				/// <summary> 
				/// The validity start date of the certificate. <br />
				/// </summary>
				///
				[JsonPropertyName("validFrom")]
				public System.DateTime? ValidFrom { get; set; }
			
				/// <summary> 
				/// The expiry date of the certificate. <br />
				/// </summary>
				///
				[JsonPropertyName("validTill")]
				public System.DateTime? ValidTill { get; set; }
			
				/// <summary> 
				/// The signing algorithm of the JWT access token. <br />
				/// </summary>
				///
				[JsonConverter(typeof(EnumConverterFactory))]
				public enum Alg 
				{
					[EnumMember(Value = "RSA")]
					RSA,
					[EnumMember(Value = "PCKS")]
					PCKS
				}
			
			
				public override string ToString()
				{
					return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
				}
			}
		
			public override string ToString()
			{
				return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
			}
		}
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}


	/// <summary> 
	/// SSO specific. Points to the field in the obtained JWT access token that should be used as the username in the Cumulocity IoT platform. <br />
	/// </summary>
	///
	public sealed class UserIdConfig 
	{
	
		/// <summary> 
		/// Used only when <c>useConstantValue</c> is set to <c>true</c>. <br />
		/// </summary>
		///
		[JsonPropertyName("constantValue")]
		public string? ConstantValue { get; set; }
	
		/// <summary> 
		/// The name of the field containing the JWT. <br />
		/// </summary>
		///
		[JsonPropertyName("jwtField")]
		public string? JwtField { get; set; }
	
		/// <summary> 
		/// Not recommended. If set to <c>true</c>, all SSO users will share one account in the Cumulocity IoT platform. <br />
		/// </summary>
		///
		[JsonPropertyName("useConstantValue")]
		public bool? UseConstantValue { get; set; }
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}


	/// <summary> 
	/// A configuration for authentication with an access token from the authorization server. <br />
	/// </summary>
	///
	public sealed class ExternalTokenConfig 
	{
	
		/// <summary> 
		/// Indicates whether authentication is enabled or disabled. <br />
		/// </summary>
		///
		[JsonPropertyName("enabled")]
		public bool? Enabled { get; set; }
	
		/// <summary> 
		/// Points to the claim of the access token from the authorization server that must be used as the username in the Cumulocity IoT platform. <br />
		/// </summary>
		///
		[JsonPropertyName("userOrAppIdConfig")]
		public UserOrAppIdConfig? PUserOrAppIdConfig { get; set; }
	
		/// <summary> 
		/// If set to <c>true</c>, the access token is validated against the authorization server by way of introspection or user info request. <br />
		/// </summary>
		///
		[JsonPropertyName("validationRequired")]
		public bool? ValidationRequired { get; set; }
	
		/// <summary> 
		/// The method of validation of the access token. <br />
		/// </summary>
		///
		[JsonPropertyName("validationMethod")]
		public ValidationMethod? PValidationMethod { get; set; }
	
		[JsonPropertyName("tokenValidationRequest")]
		public RequestRepresentation? TokenValidationRequest { get; set; }
	
		/// <summary> 
		/// The frequency (in Minutes) in which Cumulocity sends a validation request to authorization server. The recommended frequency is 1 minute. <br />
		/// </summary>
		///
		[JsonPropertyName("accessTokenValidityCheckIntervalInMinutes")]
		public int? AccessTokenValidityCheckIntervalInMinutes { get; set; }
	
		/// <summary> 
		/// The method of validation of the access token. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum ValidationMethod 
		{
			[EnumMember(Value = "INTROSPECTION")]
			INTROSPECTION,
			[EnumMember(Value = "USERINFO")]
			USERINFO
		}
	
		/// <summary> 
		/// Points to the claim of the access token from the authorization server that must be used as the username in the Cumulocity IoT platform. <br />
		/// </summary>
		///
		public sealed class UserOrAppIdConfig 
		{
		
			/// <summary> 
			/// Used only if <c>useConstantValue</c> is set to <c>true</c>. <br />
			/// </summary>
			///
			[JsonPropertyName("constantValue")]
			public string? ConstantValue { get; set; }
		
			/// <summary> 
			/// The name of the field containing the JWT. <br />
			/// </summary>
			///
			[JsonPropertyName("jwtField")]
			public string? JwtField { get; set; }
		
			/// <summary> 
			/// Not recommended. If set to <c>true</c>, all users share a single account in the Cumulocity IoT platform. <br />
			/// </summary>
			///
			[JsonPropertyName("useConstantValue")]
			public bool? UseConstantValue { get; set; }
		
			public override string ToString()
			{
				return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
			}
		}
	
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
