namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevampArch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerScores", "GolfCourseID", "dbo.GolfCourses");
            DropIndex("dbo.PlayerScores", new[] { "GolfCourseID" });
            DropPrimaryKey("dbo.Reservations");
            AddColumn("dbo.PlayerScores", "ReservationID", c => c.Int(nullable: false));
            AddColumn("dbo.GolfCourses", "Rating", c => c.Double(nullable: false));
            AddColumn("dbo.GolfCourses", "Slope", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TeeTimes", "GolfCourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Reservations", "ID");
            CreateIndex("dbo.PlayerScores", "ReservationID");
            CreateIndex("dbo.TeeTimes", "GolfCourseID");
            AddForeignKey("dbo.PlayerScores", "ReservationID", "dbo.Reservations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TeeTimes", "GolfCourseID", "dbo.GolfCourses", "ID");
            DropColumn("dbo.PlayerScores", "GolfCourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayerScores", "GolfCourseID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TeeTimes", "GolfCourseID", "dbo.GolfCourses");
            DropForeignKey("dbo.PlayerScores", "ReservationID", "dbo.Reservations");
            DropIndex("dbo.TeeTimes", new[] { "GolfCourseID" });
            DropIndex("dbo.PlayerScores", new[] { "ReservationID" });
            DropPrimaryKey("dbo.Reservations");
            DropColumn("dbo.TeeTimes", "GolfCourseID");
            DropColumn("dbo.Reservations", "ID");
            DropColumn("dbo.GolfCourses", "Slope");
            DropColumn("dbo.GolfCourses", "Rating");
            DropColumn("dbo.PlayerScores", "ReservationID");
            AddPrimaryKey("dbo.Reservations", new[] { "MemberID", "TeeTimeID" });
            CreateIndex("dbo.PlayerScores", "GolfCourseID");
            AddForeignKey("dbo.PlayerScores", "GolfCourseID", "dbo.GolfCourses", "ID");
        }
    }
}
