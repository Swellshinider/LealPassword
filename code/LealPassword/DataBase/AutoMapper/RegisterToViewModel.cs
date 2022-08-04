using AutoMapper;

namespace LealPassword.DataBase.AutoMapper
{
    public class RegisterToViewModel : Profile
    {
        public RegisterToViewModel()
        {
            CreateMap<Model.Account, Entity.Account>();
            CreateMap<Entity.Account, Model.Account>();
        }
    }
}