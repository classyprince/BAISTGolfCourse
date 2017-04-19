namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldToApplicant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "HasShareHolderOneConfirmed", c => c.Boolean());
            AddColumn("dbo.Applicants", "HasShareHolderTwoConfirmed", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "HasShareHolderTwoConfirmed");
            DropColumn("dbo.Applicants", "HasShareHolderOneConfirmed");
        }
    }
}
