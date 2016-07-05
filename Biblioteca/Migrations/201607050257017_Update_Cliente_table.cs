namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Cliente_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "ClienteIdade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "ClienteIdade");
        }
    }
}
