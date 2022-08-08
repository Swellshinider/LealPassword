using AutoMapper;

namespace LealPassword.DataBase.AutoMapper
{
    internal static class AutoMapperConfig
    {
        internal static void RegisterMappings()
        {
            Program._diagnosticsList.Debug("Registering mapps");
            Mapper.Reset();
            Program._diagnosticsList.Debug("Mapps reset");
            Mapper.Initialize(config =>
            {
                config.AddProfiles(new[] { "LealPassword" });
            });
            Program._diagnosticsList.Debug("Mapper initialized");
        }
    }
}