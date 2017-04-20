namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerScores", "ReservationID", "dbo.Reservations");
            DropIndex("dbo.PlayerScores", new[] { "ReservationID" });
            AlterColumn("dbo.PlayerScores", "ReservationID", c => c.Int());
            CreateIndex("dbo.PlayerScores", "ReservationID");
            AddForeignKey("dbo.PlayerScores", "ReservationID", "dbo.Reservations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerScores", "ReservationID", "dbo.Reservations");
            DropIndex("dbo.PlayerScores", new[] { "ReservationID" });
            AlterColumn("dbo.PlayerScores", "ReservationID", c => c.Int(nullable: false));
            CreateIndex("dbo.PlayerScores", "ReservationID");
            AddForeignKey("dbo.PlayerScores", "ReservationID", "dbo.Reservations", "ID", cascadeDelete: true);
        }
    }
}
