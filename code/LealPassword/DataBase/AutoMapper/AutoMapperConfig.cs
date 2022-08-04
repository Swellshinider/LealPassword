using AutoMapper;

namespace LealPassword.DataBase.AutoMapper
{
    internal static class AutoMapperConfig
    {
        internal static void RegisterMappings()
        {
            Mapper.Reset();
            Mapper.Initialize(config =>
            {
                config.AddProfiles(new[] { "LealPassword" });
            });
        }
    }
}