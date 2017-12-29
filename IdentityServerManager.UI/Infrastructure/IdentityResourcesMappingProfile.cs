using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using IdentityServerManager.UI.Models;

namespace IdentityServerManager.UI.Infrastructure
{
    public class IdentityResourcesMappingProfile : Profile
    {
        public IdentityResourcesMappingProfile()
        {
            CreateMap<IdentityResource, IdentityResourceViewModel>().ReverseMap();
        }
    }
}
