namespace DinnerTimeData
{
    using DinnerTimeLib;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DinnerTimeContext : DbContext
    {
        // Your context has been configured to use a 'DinnerTimeContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DinnerTimeData.DinnerTimeContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DinnerTimeContext' 
        // connection string in the application configuration file.
        public DinnerTimeContext()
            : base("name=DinnerTimeContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

    }
}