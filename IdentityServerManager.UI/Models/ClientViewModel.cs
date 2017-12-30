using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServerManager.UI.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        [Required]
        [StringLength(200)]
        [Display(Name = "Id")]
        public string ClientId { get; set; }
        [Display(Name = "Protocol Type")]
        public string ProtocolType { get; set; } = ProtocolTypes.OpenIdConnect;
        public List<ClientSecret> ClientSecrets { get; set; }
        [Display(Name = "Require Client Secret")]
        public bool RequireClientSecret { get; set; } = true;
        [Required]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string ClientName { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(2000)]
        [Display(Name = "Uri")]
        public string ClientUri { get; set; }
        [StringLength(2000)]
        [Display(Name = "Logo Uri")]
        public string LogoUri { get; set; }
        [Display(Name = "Require Consent")]
        public bool RequireConsent { get; set; } = true;
        [Display(Name = "Allow Remember Consent")]
        public bool AllowRememberConsent { get; set; } = true;
        [Display(Name = "Always Include User Claims In Id Token")]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public List<ClientGrantType> AllowedGrantTypes { get; set; }
        [Display(Name = "Require Pkce")]
        public bool RequirePkce { get; set; }
        [Display(Name = "Allow Plain Text Pkce")]
        public bool AllowPlainTextPkce { get; set; }
        [Display(Name = "Allow Access Tokens Via Browser")]
        public bool AllowAccessTokensViaBrowser { get; set; }
        public List<ClientRedirectUri> RedirectUris { get; set; }
        public List<ClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }
        [StringLength(2000)]
        [Display(Name = "FrontChannel Logout Uri")]
        public string FrontChannelLogoutUri { get; set; }
        [Display(Name = "FrontChannel Logout Session Required")]
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;
        [StringLength(2000)]
        [Display(Name = "BackChannel Logout Uri")]
        public string BackChannelLogoutUri { get; set; }
        [Display(Name = "BackChannel Logout Session Required")]
        public bool BackChannelLogoutSessionRequired { get; set; } = true;
        [Display(Name = "Allow Offline Access")]
        public bool AllowOfflineAccess { get; set; }
        public List<ClientScope> AllowedScopes { get; set; }
        [Display(Name = "Identity Token Lifetime")]
        public int IdentityTokenLifetime { get; set; } = 300;
        [Display(Name = "Access Token Lifetime")]
        public int AccessTokenLifetime { get; set; } = 3600;
        [Display(Name = "Authorization Code Lifetime")]
        public int AuthorizationCodeLifetime { get; set; } = 300;
        [Display(Name = "Consent Lifetime")]
        public int? ConsentLifetime { get; set; } = null;
        [Display(Name = "Absolute Refresh Token Lifetime")]
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;
        [Display(Name = "Sliding Refresh Token Lifetime")]
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        [Display(Name = "Refresh Token Usage")]
        public int RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;
        [Display(Name = "Update Access Token Claims On Refresh")]
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        [Display(Name = "Refresh Token Expiration")]
        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;
        [Display(Name = "Access Token Type")]
        public int AccessTokenType { get; set; } = (int)0; // AccessTokenType.Jwt;
        [Display(Name = "Enable Local Login")]
        public bool EnableLocalLogin { get; set; } = true;
        public List<ClientIdPRestriction> IdentityProviderRestrictions { get; set; }
        [Display(Name = "Include Jwt Id")]
        public bool IncludeJwtId { get; set; }
        public List<ClientClaim> Claims { get; set; }
        [Display(Name = "Always Send Client Claims")]
        public bool AlwaysSendClientClaims { get; set; }
        [StringLength(200)]
        [Display(Name = "Client Claims Prefix")]
        public string ClientClaimsPrefix { get; set; } = "client_";
        [StringLength(200)]
        [Display(Name = "PairWise Subject Salt")]
        public string PairWiseSubjectSalt { get; set; }
        public List<ClientCorsOrigin> AllowedCorsOrigins { get; set; }
        public List<ClientProperty> Properties { get; set; }
        public List<string> IdentityProtocolTypes { get; set; }

    }
}