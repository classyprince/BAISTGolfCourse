namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicantEditMore : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Applicants", "LastName", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "LastName", c => c.String(maxLength: 70));
            AlterColumn("dbo.Applicants", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
