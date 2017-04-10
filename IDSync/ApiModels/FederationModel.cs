using System; 
using System.ComponentModel.DataAnnotations; 

namespace IDSync.ApiModels
{

    public class FederationModel
    {
        [Required(ErrorMessage = "WSFedEndpoint is a Required field.")] 
        [RegularExpression("^https?://", ErrorMessage = "WSFedEndpoint is required and must be start with https://.")]
        public string WSFedEndpoint { get; set; }
        public string AdditionalWSFedEndpoint { get; set; }
        public string ClaimsProviderName { get; set; }
        public string ClaimsAccepted { get; set; }
        public string ConflictWithPublishedPolicy { get; set; }
        public string EncryptClaims { get; set; }
        public string Enabled { get; set; }
        public string EncryptionCertificate { get; set; }
        [Required(ErrorMessage = "Identifier is a Required field.")]
        public string Identifier { get; set; }
        public DateTime LastMonitoredTime { get; set; }
        public DateTime LastPublishedPolicyCheckSuccessful { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string MetadataUrl { get; set; }
        public string MonitoringEnabled { get; set; }
        [Required(ErrorMessage = "Name is a Required field.")]
        public string Name { get; set; }
        public string NotBeforeSkew { get; set; }
        public string EnableJWT { get; set; }
        public string AlwaysRequireAuthentication { get; set; }
        public string Notes { get; set; }
        public string OrganizationInfo { get; set; }
        public string ImpersonationAuthorizationRules { get; set; }
        public string AdditionalAuthenticationRules { get; set; }
        public string ProxyEndpointMappings { get; set; }
        public string ProxyTrustedEndpointsx { get; set; }
        public string ProtocolProfile { get; set; }
        public string RequestSigningCertificate { get; set; }
        public string EncryptedNameIdRequired { get; set; }
        public string SignedSamlRequestsRequired { get; set; }
        public string SamlEndpoints { get; set; }
        public string SamlResponseSignature { get; set; }
        public string SignatureAlgorithm { get; set; }
        public string TokenLifetime { get; set; }
        public string AllowedClientTypes { get; set; }
        public string IssueOAuthRefreshTokensTo { get; set; }
        public string AutoUpdateEnabled { get; set; }
    }

    public class AdfsClientModel {
        [Required(ErrorMessage = "RedirectUri is a Required field.")]
        [RegularExpression("^(http|https)://", ErrorMessage = "RedirectUri is required and must be start with http:// or https://.")]
        public string RedirectUri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string BuiltIn { get; set; }
        public string Enabled { get; set; }
        public string ClientType { get; set; }
        public string ADUserPrincipalName { get; set; }
        public string ClientSecret { get; set; }
        public string JWTSigningCertificateRevocationCheck { get; set; }
        public string JWTSigningKeys { get; set; }
        public string JWKSUri { get; set; }
    }
}
