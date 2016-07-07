namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_obra : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Obra", "ObraAno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Obra", "ObraAno", c => c.String());
        }
    }
}
