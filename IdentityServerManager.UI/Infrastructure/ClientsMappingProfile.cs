namespace IdentityServerManager.UI.Infrastructure
{

    using AutoMapper;
    using IdentityServer4.EntityFramework.Entities;
    using IdentityServerManager.UI.Models;

    public class ClientsMappingProfile : Profile
    {
        public ClientsMappingProfile()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();

        }
    }
}
