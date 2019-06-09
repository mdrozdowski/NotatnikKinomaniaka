namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewId = c.Int(nullable: false),
                        Title = c.String(),
                        DateOfProduction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Country = c.String(),
                        IsDirector = c.Boolean(nullable: false),
                        IsActor = c.Boolean(nullable: false),
                        Film_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .Index(t => t.Film_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonFilms",
                c => new
                    {
                        PersonFilmId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonFilmId)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.FilmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonFilms", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonFilms", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Films", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.People", "Film_Id", "dbo.Films");
            DropIndex("dbo.PersonFilms", new[] { "FilmId" });
            DropIndex("dbo.PersonFilms", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "Film_Id" });
            DropIndex("dbo.Films", new[] { "ReviewId" });
            DropTable("dbo.PersonFilms");
            DropTable("dbo.Reviews");
            DropTable("dbo.People");
            DropTable("dbo.Films");
        }
    }
}
