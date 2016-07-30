namespace DinnerTimeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleHouseholds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Household_Id", "dbo.Households");
            DropIndex("dbo.AspNetUsers", new[] { "Household_Id" });
            AddColumn("dbo.Households", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Households", "User_Id");
            AddForeignKey("dbo.Households", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Household_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Household_Id", c => c.Int());
            DropForeignKey("dbo.Households", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Households", new[] { "User_Id" });
            DropColumn("dbo.Households", "User_Id");
            CreateIndex("dbo.AspNetUsers", "Household_Id");
            AddForeignKey("dbo.AspNetUsers", "Household_Id", "dbo.Households", "Id");
        }
    }
}
