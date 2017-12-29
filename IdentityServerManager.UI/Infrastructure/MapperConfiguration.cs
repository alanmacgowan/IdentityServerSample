using AutoMapper;

namespace IdentityServerManager.UI.Infrastructure
{
    public static class MapperConfiguration
    {

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ClientsMappingProfile>();
                cfg.AddProfile<ApiResourcesMappingProfile>();
            });
        }

    }

}