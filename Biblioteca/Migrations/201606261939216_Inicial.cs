namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Obra",
                c => new
                    {
                        ObraId = c.Int(nullable: false, identity: true),
                        ObraTitulo = c.String(),
                        ObraIsbn = c.String(),
                        ObraAno = c.String(),
                        ObraStatus = c.Int(nullable: false),
                        ObraRemovida = c.Int(nullable: false),
                        ObraCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObraId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Obra");
        }
    }
}
