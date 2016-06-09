namespace DinnerTimeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IngredientProductType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            AddColumn("dbo.Ingredients", "ProductType_Id", c => c.Int());
            AddColumn("dbo.Products", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "Measurement_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "ProductType_Id");
            CreateIndex("dbo.Products", "Measurement_Id");
            AddForeignKey("dbo.Ingredients", "ProductType_Id", "dbo.ProductTypes", "Id");
            AddForeignKey("dbo.Products", "Measurement_Id", "dbo.Measurements", "Id");
            DropColumn("dbo.Ingredients", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Product_Id", c => c.Int());
            DropForeignKey("dbo.Products", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.Ingredients", "ProductType_Id", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "Measurement_Id" });
            DropIndex("dbo.Ingredients", new[] { "ProductType_Id" });
            DropColumn("dbo.Products", "Measurement_Id");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Ingredients", "ProductType_Id");
            CreateIndex("dbo.Ingredients", "Product_Id");
            AddForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products", "Id");
        }
    }
}
