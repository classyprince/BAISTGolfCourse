namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Gender");
            DropColumn("dbo.Applicants", "Gender");
        }
    }
}
