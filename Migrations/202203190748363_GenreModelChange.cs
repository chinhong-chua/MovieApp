namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "Movie_Id" });
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Genres", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Movie_Id", c => c.Int());
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.Genres", "Movie_Id");
            AddForeignKey("dbo.Genres", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
