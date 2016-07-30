namespace DinnerTimeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleHouseholds1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Households", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Households", new[] { "User_Id" });
            CreateTable(
                "dbo.UserHouseholds",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Household_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Household_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Households", t => t.Household_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Household_Id);
            
            DropColumn("dbo.Households", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Households", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserHouseholds", "Household_Id", "dbo.Households");
            DropForeignKey("dbo.UserHouseholds", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserHouseholds", new[] { "Household_Id" });
            DropIndex("dbo.UserHouseholds", new[] { "User_Id" });
            DropTable("dbo.UserHouseholds");
            CreateIndex("dbo.Households", "User_Id");
            AddForeignKey("dbo.Households", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
