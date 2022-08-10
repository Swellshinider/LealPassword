using AutoMapper;
using LealPassword.Diagnostics;

namespace LealPassword.Database.AutoMapper
{
    internal static class AutoMapperConfig
    {
        internal static void RegisterMapps(DiagnosticList diagnostic)
        {
            Mapper.Reset();
            diagnostic.Debug("Mapps reseted");
            Mapper.Initialize(config =>
            {
                config.AddProfiles(new[] { "LealPassword.Database" });
            });
            diagnostic.Debug("Mapps initialized");
        }
    }
}