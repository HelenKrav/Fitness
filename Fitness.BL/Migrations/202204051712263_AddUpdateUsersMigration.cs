namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateUsersMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Gender_Id", newName: "GenderId");
            RenameIndex(table: "dbo.Users", name: "IX_Gender_Id", newName: "IX_GenderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_GenderId", newName: "IX_Gender_Id");
            RenameColumn(table: "dbo.Users", name: "GenderId", newName: "Gender_Id");
        }
    }
}
