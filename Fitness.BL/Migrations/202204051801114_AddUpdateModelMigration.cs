namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateModelMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "CalloriesInMinute", c => c.Double(nullable: false));
            AddColumn("dbo.Eatings", "Food_Id", c => c.Int());
            AddColumn("dbo.Foods", "Callories", c => c.Double(nullable: false));
            CreateIndex("dbo.Eatings", "Food_Id");
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
            DropColumn("dbo.Activities", "CaloriesInMinute");
            DropColumn("dbo.Foods", "Calories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Calories", c => c.Double(nullable: false));
            AddColumn("dbo.Activities", "CaloriesInMinute", c => c.Double(nullable: false));
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            DropColumn("dbo.Foods", "Callories");
            DropColumn("dbo.Eatings", "Food_Id");
            DropColumn("dbo.Activities", "CalloriesInMinute");
        }
    }
}
