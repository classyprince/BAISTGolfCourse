namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeApplicantOptional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Members", new[] { "ApplicantID" });
            AlterColumn("dbo.Members", "ApplicantID", c => c.Int());
            CreateIndex("dbo.Members", "ApplicantID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "ApplicantID" });
            AlterColumn("dbo.Members", "ApplicantID", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "ApplicantID");
        }
    }
}
