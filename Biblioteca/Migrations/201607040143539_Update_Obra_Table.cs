namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Obra_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Obra", "Autor_AutorId", c => c.Int());
            AddColumn("dbo.Obra", "Editora_EditoraId", c => c.Int());
            CreateIndex("dbo.Obra", "Autor_AutorId");
            CreateIndex("dbo.Obra", "Editora_EditoraId");
            AddForeignKey("dbo.Obra", "Autor_AutorId", "dbo.Autor", "AutorId");
            AddForeignKey("dbo.Obra", "Editora_EditoraId", "dbo.Editora", "EditoraId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Obra", "Editora_EditoraId", "dbo.Editora");
            DropForeignKey("dbo.Obra", "Autor_AutorId", "dbo.Autor");
            DropIndex("dbo.Obra", new[] { "Editora_EditoraId" });
            DropIndex("dbo.Obra", new[] { "Autor_AutorId" });
            DropColumn("dbo.Obra", "Editora_EditoraId");
            DropColumn("dbo.Obra", "Autor_AutorId");
        }
    }
}
