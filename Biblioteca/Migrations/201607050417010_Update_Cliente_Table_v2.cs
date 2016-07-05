namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Cliente_Table_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "ClienteSexo", c => c.String());
            AlterColumn("dbo.Cliente", "ClienteEmail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "ClienteEmail", c => c.Int(nullable: false));
            DropColumn("dbo.Cliente", "ClienteSexo");
        }
    }
}
