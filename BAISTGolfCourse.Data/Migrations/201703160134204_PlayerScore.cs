namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerScore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerScores",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        GolfCourseID = c.Int(nullable: false),
                        HoleID = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GolfCourses", t => t.GolfCourseID)
                .ForeignKey("dbo.Holes", t => t.HoleID)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .Index(t => t.MemberID)
                .Index(t => t.GolfCourseID)
                .Index(t => t.HoleID);
            
            CreateTable(
                "dbo.GolfCourses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 300),
                        Address = c.String(maxLength: 150),
                        Country = c.String(maxLength: 150),
                        City = c.String(maxLength: 100),
                        YearFounded = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Holes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerScores", "MemberID", "dbo.Members");
            DropForeignKey("dbo.PlayerScores", "HoleID", "dbo.Holes");
            DropForeignKey("dbo.PlayerScores", "GolfCourseID", "dbo.GolfCourses");
            DropIndex("dbo.PlayerScores", new[] { "HoleID" });
            DropIndex("dbo.PlayerScores", new[] { "GolfCourseID" });
            DropIndex("dbo.PlayerScores", new[] { "MemberID" });
            DropTable("dbo.Holes");
            DropTable("dbo.GolfCourses");
            DropTable("dbo.PlayerScores");
        }
    }
}
