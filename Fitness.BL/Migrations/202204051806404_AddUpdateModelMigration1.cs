namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateModelMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            RenameColumn(table: "dbo.Eatings", name: "Food_Id", newName: "FoodId");
            AlterColumn("dbo.Eatings", "FoodId", c => c.Int(nullable: false));
            CreateIndex("dbo.Eatings", "FoodId");
            AddForeignKey("dbo.Eatings", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eatings", "FoodId", "dbo.Foods");
            DropIndex("dbo.Eatings", new[] { "FoodId" });
            AlterColumn("dbo.Eatings", "FoodId", c => c.Int());
            RenameColumn(table: "dbo.Eatings", name: "FoodId", newName: "Food_Id");
            CreateIndex("dbo.Eatings", "Food_Id");
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
        }
    }
}
