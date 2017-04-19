namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationCompositeKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            AddPrimaryKey("dbo.Reservations", new[] { "MemberID", "TeeTimeID" });
            DropColumn("dbo.Reservations", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Reservations");
            AddPrimaryKey("dbo.Reservations", "ID");
        }
    }
}
