namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Editora_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Editora", "EditoraCadastro", c => c.DateTime(nullable: false));
            DropColumn("dbo.Editora", "AutorCadastro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Editora", "AutorCadastro", c => c.DateTime(nullable: false));
            DropColumn("dbo.Editora", "EditoraCadastro");
        }
    }
}
