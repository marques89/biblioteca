namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_all_tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emprestimo", "EmprestimoStatus", c => c.String());
            DropColumn("dbo.Autor", "AutorTitulo");
            DropColumn("dbo.Autor", "AutorSexo");
            DropColumn("dbo.Autor", "AutorEmail");
            DropColumn("dbo.Autor", "AutorRemovido");
            DropColumn("dbo.Autor", "AutorCadastro");
            DropColumn("dbo.Cliente", "ClienteIdade");
            DropColumn("dbo.Cliente", "ClienteSexo");
            DropColumn("dbo.Cliente", "ClienteEmail");
            DropColumn("dbo.Cliente", "ClienteRemovido");
            DropColumn("dbo.Cliente", "ClienteCadastro");
            DropColumn("dbo.Editora", "EditoraFundacao");
            DropColumn("dbo.Editora", "EditoraFundador");
            DropColumn("dbo.Editora", "EditoraEmail");
            DropColumn("dbo.Editora", "EditoraLocalSede");
            DropColumn("dbo.Editora", "EditoraRemovido");
            DropColumn("dbo.Editora", "EditoraCadastro");
            DropColumn("dbo.Emprestimo", "Situacao");
            DropColumn("dbo.Emprestimo", "ObraCadastro");
            DropColumn("dbo.Obra", "ObraRemovida");
            DropColumn("dbo.Obra", "ObraCadastro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Obra", "ObraCadastro", c => c.String());
            AddColumn("dbo.Obra", "ObraRemovida", c => c.Int(nullable: false));
            AddColumn("dbo.Emprestimo", "ObraCadastro", c => c.String());
            AddColumn("dbo.Emprestimo", "Situacao", c => c.String());
            AddColumn("dbo.Editora", "EditoraCadastro", c => c.String());
            AddColumn("dbo.Editora", "EditoraRemovido", c => c.Int(nullable: false));
            AddColumn("dbo.Editora", "EditoraLocalSede", c => c.String());
            AddColumn("dbo.Editora", "EditoraEmail", c => c.String());
            AddColumn("dbo.Editora", "EditoraFundador", c => c.String());
            AddColumn("dbo.Editora", "EditoraFundacao", c => c.String());
            AddColumn("dbo.Cliente", "ClienteCadastro", c => c.String());
            AddColumn("dbo.Cliente", "ClienteRemovido", c => c.Int(nullable: false));
            AddColumn("dbo.Cliente", "ClienteEmail", c => c.String());
            AddColumn("dbo.Cliente", "ClienteSexo", c => c.String());
            AddColumn("dbo.Cliente", "ClienteIdade", c => c.String());
            AddColumn("dbo.Autor", "AutorCadastro", c => c.String());
            AddColumn("dbo.Autor", "AutorRemovido", c => c.Int(nullable: false));
            AddColumn("dbo.Autor", "AutorEmail", c => c.String());
            AddColumn("dbo.Autor", "AutorSexo", c => c.String());
            AddColumn("dbo.Autor", "AutorTitulo", c => c.String());
            DropColumn("dbo.Emprestimo", "EmprestimoStatus");
        }
    }
}
