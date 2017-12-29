using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using IdentityServerManager.UI.Models;

namespace IdentityServerManager.UI.Infrastructure
{
    public class ApiResourcesMappingProfile : Profile
    {
        public ApiResourcesMappingProfile()
        {
            CreateMap<ApiResource, ApiResourceViewModel>().ReverseMap();

        }
    }
}
