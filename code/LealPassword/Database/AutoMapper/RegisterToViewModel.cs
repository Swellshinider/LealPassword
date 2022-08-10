using AutoMapper;

namespace LealPassword.Database.AutoMapper
{
    internal class RegisterToViewModel : Profile
    {
        public RegisterToViewModel()
        {
            CreateMap<Model.Register, Entity.Register>();
            CreateMap<Entity.Register, Model.Register>();
        }
    }
}