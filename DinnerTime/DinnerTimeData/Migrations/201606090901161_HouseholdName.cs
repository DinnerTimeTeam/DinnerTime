namespace DinnerTimeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HouseholdName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Households", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Households", "Name");
        }
    }
}
