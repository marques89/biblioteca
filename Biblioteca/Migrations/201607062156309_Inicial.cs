namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        AutorNome = c.String(),
                        AutorTitulo = c.String(),
                        AutorSexo = c.String(),
                        AutorEmail = c.String(),
                        AutorRemovido = c.Int(nullable: false),
                        AutorCadastro = c.String(),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteNome = c.String(),
                        ClienteCpf = c.String(),
                        ClienteIdade = c.String(),
                        ClienteTelefone = c.String(),
                        ClienteSexo = c.String(),
                        ClienteEmail = c.String(),
                        ClienteRemovido = c.Int(nullable: false),
                        ClienteCadastro = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
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
                        EditoraCadastro = c.String(),
                    })
                .PrimaryKey(t => t.EditoraId);
            
            CreateTable(
                "dbo.Emprestimo",
                c => new
                    {
                        EmprestimoId = c.Int(nullable: false, identity: true),
                        DataRetirada = c.String(),
                        DataDevolucao = c.String(),
                        Situacao = c.String(),
                        ObraCadastro = c.String(),
                        Cliente_ClienteId = c.Int(),
                        Obra_ObraId = c.Int(),
                    })
                .PrimaryKey(t => t.EmprestimoId)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId)
                .ForeignKey("dbo.Obra", t => t.Obra_ObraId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.Obra_ObraId);
            
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
                        ObraCadastro = c.String(),
                        Autor_AutorId = c.Int(),
                        Editora_EditoraId = c.Int(),
                    })
                .PrimaryKey(t => t.ObraId)
                .ForeignKey("dbo.Autor", t => t.Autor_AutorId)
                .ForeignKey("dbo.Editora", t => t.Editora_EditoraId)
                .Index(t => t.Autor_AutorId)
                .Index(t => t.Editora_EditoraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprestimo", "Obra_ObraId", "dbo.Obra");
            DropForeignKey("dbo.Obra", "Editora_EditoraId", "dbo.Editora");
            DropForeignKey("dbo.Obra", "Autor_AutorId", "dbo.Autor");
            DropForeignKey("dbo.Emprestimo", "Cliente_ClienteId", "dbo.Cliente");
            DropIndex("dbo.Obra", new[] { "Editora_EditoraId" });
            DropIndex("dbo.Obra", new[] { "Autor_AutorId" });
            DropIndex("dbo.Emprestimo", new[] { "Obra_ObraId" });
            DropIndex("dbo.Emprestimo", new[] { "Cliente_ClienteId" });
            DropTable("dbo.Obra");
            DropTable("dbo.Emprestimo");
            DropTable("dbo.Editora");
            DropTable("dbo.Cliente");
            DropTable("dbo.Autor");
        }
    }
}
