using Microsoft.AspNet.Identity.EntityFramework;

namespace DinnerTimeData
{
    using DinnerTimeLib;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DinnerTimeContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DinnerTimeContext()
            : base("name=DinnerTimeContext")
        {
        }

        public static DinnerTimeContext Create()
        {
            return new DinnerTimeContext();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

    }
}