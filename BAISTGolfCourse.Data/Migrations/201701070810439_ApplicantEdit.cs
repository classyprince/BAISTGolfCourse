namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicantEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Applicants", "LastName", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "LastName", c => c.String());
            AlterColumn("dbo.Applicants", "FirstName", c => c.String());
        }
    }
}
