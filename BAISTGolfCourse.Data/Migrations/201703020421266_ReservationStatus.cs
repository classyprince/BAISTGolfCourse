namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Status", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Status");
        }
    }
}
