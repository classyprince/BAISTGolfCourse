namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSaltMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PasswordSalt", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Members", "PasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "PasswordHash", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Members", "PasswordSalt");
        }
    }
}
