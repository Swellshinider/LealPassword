using AutoMapper;

namespace LealPassword.Database.AutoMapper
{
    internal class CardToViewModel : Profile
    {
        public CardToViewModel()
        {
            CreateMap<Model.Card, Entity.Card>();
            CreateMap<Entity.Card, Model.Card>();
        }
    }
}