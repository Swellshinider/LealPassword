using AutoMapper;

namespace LealPassword.DataBase.AutoMapper
{
    public class AccountToViewModel : Profile
    {
        public AccountToViewModel()
        {
            CreateMap<Model.Register, Entity.Register>();
            CreateMap<Entity.Register, Model.Register>();
        }
    }
}