using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerManager.UI.Models

{
    public class IdentityResourceViewModel
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        [Display(Name = "Show In Discovery Document")]
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public List<IdentityClaim> UserClaims { get; set; }
    }
}
