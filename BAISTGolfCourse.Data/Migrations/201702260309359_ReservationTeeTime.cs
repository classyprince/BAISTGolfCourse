namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationTeeTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeeTimeID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TeeTimes", t => t.TeeTimeID)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .Index(t => t.TeeTimeID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.TeeTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Reservations", "TeeTimeID", "dbo.TeeTimes");
            DropIndex("dbo.Reservations", new[] { "MemberID" });
            DropIndex("dbo.Reservations", new[] { "TeeTimeID" });
            DropTable("dbo.TeeTimes");
            DropTable("dbo.Reservations");
        }
    }
}
