namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOptionalFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "Address2", c => c.String(maxLength: 150));
            AlterColumn("dbo.Applicants", "AlternatePhone", c => c.String(maxLength: 15));
            AlterColumn("dbo.Members", "Address2", c => c.String(maxLength: 150));
            AlterColumn("dbo.Members", "AlternatePhone", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "AlternatePhone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Members", "Address2", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Applicants", "AlternatePhone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Applicants", "Address2", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
