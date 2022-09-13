namespace EscuelaRelacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionUno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstudianteGrupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EstudianteID = c.Int(nullable: false),
                        GrupoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteID, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.GrupoID, cascadeDelete: true)
                .Index(t => t.EstudianteID)
                .Index(t => t.GrupoID);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Aula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstudianteGrupoes", "GrupoID", "dbo.Grupoes");
            DropForeignKey("dbo.EstudianteGrupoes", "EstudianteID", "dbo.Estudiantes");
            DropIndex("dbo.EstudianteGrupoes", new[] { "GrupoID" });
            DropIndex("dbo.EstudianteGrupoes", new[] { "EstudianteID" });
            DropTable("dbo.Grupoes");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.EstudianteGrupoes");
        }
    }
}
