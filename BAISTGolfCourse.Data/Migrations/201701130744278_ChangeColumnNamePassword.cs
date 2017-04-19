namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNamePassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "PasswordSalt", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Applicants", "PasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "PasswordHash", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Applicants", "PasswordSalt");
            DropColumn("dbo.Applicants", "Status");
        }
    }
}
