namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RejectionReason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "RejectionReason", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "RejectionReason");
        }
    }
}
