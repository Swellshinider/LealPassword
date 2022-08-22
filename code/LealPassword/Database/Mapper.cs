using System.Collections.Generic;
using System.Linq;

namespace LealPassword.Database
{
    internal static class Mapper
    {
        #region Model converter
        internal static Model.Account Map(Entity.Account account)
        {
            var model = new Model.Account()
            {
                Username = account.Username,
                Password = account.Password,
                Cards = new List<Model.Card>(),
                Registers = new List<Model.Register>()
            };

            if (account.Registers != null)
                model.Registers.AddRange(from reg in account.Registers select Map(reg));

            if (account.Cards != null)
                model.Cards.AddRange(from crd in account.Cards select Map(crd));

            return model;
        }

        internal static Model.Register Map(Entity.Register register) => new Model.Register()
        {
            Id = register.Id,
            Name = register.Name,
            Tag = register.Tag,
            Password = register.Password,
            Description = register.Description,
            ImageKey = register.ImageKey,
            Email = register.Email,
        };

        internal static List<Model.Register> Map(List<Entity.Register> registers)
        {
            var modelList = new List<Model.Register>();

            foreach (var reg in registers)
                modelList.Add(Map(reg));

            return modelList;
        }

        internal static Model.Card Map(Entity.Card card) => new Model.Card()
        {
            Id = card.Id,
            CardName = card.CardName,
            OwnrName = card.OwnrName,
            DueDate = card.DueDate,
            Number = card.Number,
            SecurityNumber = card.SecurityNumber,
        };

        internal static List<Model.Card> Map(List<Entity.Card> cards)
        {
            var modelList = new List<Model.Card>();

            foreach (var card in cards)
                modelList.Add(Map(card));

            return modelList;
        }
        #endregion

        #region Entity converter
        internal static Entity.Account Map(Model.Account account)
        {
            var entity = new Entity.Account()
            {
                Username = account.Username,
                Password = account.Password,
                Cards = new List<Entity.Card>(),
                Registers = new List<Entity.Register>()
            };

            foreach (var reg in account.Registers)
                entity.Registers.Add(Map(reg));
            foreach (var crd in account.Cards)
                entity.Cards.Add(Map(crd));

            return entity;
        }

        internal static Entity.Register Map(Model.Register register) => new Entity.Register()
        {
            Id = register.Id,
            Name = register.Name,
            Tag = register.Tag,
            Password = register.Password,
            Description = register.Description,
            ImageKey = register.ImageKey,
            Email = register.Email,
        };

        internal static List<Entity.Register> Map(List<Model.Register> registers)
        {
            var modelList = new List<Entity.Register>();

            foreach (var reg in registers)
                modelList.Add(Map(reg));

            return modelList;
        }

        internal static Entity.Card Map(Model.Card card) => new Entity.Card()
        {
            Id = card.Id,
            CardName = card.CardName,
            OwnrName = card.OwnrName,
            DueDate = card.DueDate,
            Number = card.Number,
            SecurityNumber = card.SecurityNumber,
        };

        internal static List<Entity.Card> Map(List<Model.Card> cards)
        {
            var modelList = new List<Entity.Card>();

            foreach (var card in cards)
                modelList.Add(Map(card));

            return modelList;
        }
        #endregion
    }
}