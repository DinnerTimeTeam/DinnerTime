using System.Collections.Generic;
using DinnerTimeLib;

namespace DinnerTimeData.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DinnerTimeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DinnerTimeContext context)
        {
            context.Brand.AddOrUpdate(
                x => x.Id,
                new Brand { Id = 1, Name = "ICA" },
                new Brand { Id = 2, Name = "Arla" },
                new Brand { Id = 3, Name = "Zeta" },
                new Brand { Id = 4, Name = "Coop Extra" },
                new Brand { Id = 5, Name = "Eldorado" },
                new Brand { Id = 6, Name = "Barilla" },
                new Brand { Id = 7, Name = "Kungsörnen" },
                new Brand { Id = 8, Name = "ICA Basic" }
            );

            context.Categories.AddOrUpdate(
                x => x.Id,
                new Category { Id = 1, Name = "Pasta" },
                new Category { Id = 2, Name = "Mejeri" },
                new Category { Id = 3, Name = "Chark" },
                new Category { Id = 4, Name = "Frukt & Grönt" }
            );

            context.Users.AddOrUpdate(
                x => x.Id,
                new User { Id = 1, Email = "niklas@dinnertime.com", Password = "password" },
                new User { Id = 2, Email = "anton@dinnertime.com", Password = "password" },
                new User { Id = 3, Email = "andre@dinnertime.com", Password = "password" }
            );

            context.Households.AddOrUpdate(
                x => x.Id,
                new Household { Id = 1, Users = new List<User> { context.Users.Find(1), context.Users.Find(2), context.Users.Find(3) }, Name = "Tallis" }
            );

            context.Measurements.AddOrUpdate(
                x => x.Id,
                new Measurement { Id = 1, Name = "Weight" },
                new Measurement { Id = 2, Name = "Volume" },
                new Measurement { Id = 3, Name = "Amount" }
            );

            context.ProductTypes.AddOrUpdate(
                x => x.Id,
                new ProductType { Id = 1, Name = "Spaghetti", Category = context.Categories.Find(1) }
            );

            context.Products.AddOrUpdate(
                x => x.Id,
                new Product { Id = 1, Brand = context.Brand.Find(8), Name = "Spaghetti", Measurement = context.Measurements.Find(1), Quantity = 1000, EAN = "7318690082361", Type = context.ProductTypes.Find(1) }
            );

            context.Ingredients.AddOrUpdate(
                x => x.Id,
                new Ingredient { Id = 1, Measurement = context.Measurements.Find(1), ProductType = context.ProductTypes.Find(1), Quantity = 500 }
            );

            context.Instructions.AddOrUpdate(
                x => x.Id,
                new Instruction { Id = 1, Index = 1, Description = "Koka pasta" },
                new Instruction { Id = 2, Index = 2, Description = "Ät" }
            );

            context.Recipes.AddOrUpdate(
                x => x.Id,
                new Recipe { Id = 1, Name = "Spaghetti", Ingredients = new List<Ingredient> { context.Ingredients.Find(1) }, Instructions = new List<Instruction> { context.Instructions.Find(1), context.Instructions.Find(2) } }
            );
        }
    }
}
