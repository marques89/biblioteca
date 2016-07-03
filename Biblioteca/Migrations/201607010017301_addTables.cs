namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        AutorNome = c.String(),
                        AutorTitulacao = c.String(),
                        AutorEmail = c.String(),
                        AutorRemovido = c.Int(nullable: false),
                        AutorCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        EditoraId = c.Int(nullable: false, identity: true),
                        EditoraNome = c.String(),
                        EditoraFundacao = c.String(),
                        EditoraFundador = c.String(),
                        EditoraEmail = c.String(),
                        EditoraLocalSede = c.String(),
                        EditoraRemovido = c.Int(nullable: false),
                        AutorCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EditoraId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Editora");
            DropTable("dbo.Autor");
        }
    }
}
