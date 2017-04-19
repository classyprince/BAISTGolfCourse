namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicantMemberBuild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MembershipID = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 70),
                        EmailAddress = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 600),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        PasswordHash = c.String(nullable: false, maxLength: 10),
                        Address1 = c.String(nullable: false, maxLength: 150),
                        Address2 = c.String(nullable: false, maxLength: 150),
                        City = c.String(nullable: false, maxLength: 50),
                        Province = c.String(nullable: false, maxLength: 60),
                        PostalCode = c.String(nullable: false, maxLength: 8),
                        Phone = c.String(nullable: false, maxLength: 15),
                        AlternatePhone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID)
                .Index(t => t.ApplicantID);
            
            AddColumn("dbo.Applicants", "EmailAddress", c => c.String(nullable: false, maxLength: 80));
            AddColumn("dbo.Applicants", "Password", c => c.String(nullable: false, maxLength: 600));
            AddColumn("dbo.Applicants", "PasswordHash", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Applicants", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "Address1", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Applicants", "Address2", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Applicants", "City", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Applicants", "Province", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Applicants", "PostalCode", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Applicants", "Phone", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Applicants", "AlternatePhone", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Applicants", "ShareHolder1ID", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "ShareHolder2ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "ShareHolder1ID");
            CreateIndex("dbo.Applicants", "ShareHolder2ID");
            AddForeignKey("dbo.Applicants", "ShareHolder2ID", "dbo.Members", "ID");
            AddForeignKey("dbo.Applicants", "ShareHolder1ID", "dbo.Members", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "ShareHolder1ID", "dbo.Members");
            DropForeignKey("dbo.Members", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "ShareHolder2ID", "dbo.Members");
            DropIndex("dbo.Members", new[] { "ApplicantID" });
            DropIndex("dbo.Applicants", new[] { "ShareHolder2ID" });
            DropIndex("dbo.Applicants", new[] { "ShareHolder1ID" });
            DropColumn("dbo.Applicants", "ShareHolder2ID");
            DropColumn("dbo.Applicants", "ShareHolder1ID");
            DropColumn("dbo.Applicants", "AlternatePhone");
            DropColumn("dbo.Applicants", "Phone");
            DropColumn("dbo.Applicants", "PostalCode");
            DropColumn("dbo.Applicants", "Province");
            DropColumn("dbo.Applicants", "City");
            DropColumn("dbo.Applicants", "Address2");
            DropColumn("dbo.Applicants", "Address1");
            DropColumn("dbo.Applicants", "DateCreated");
            DropColumn("dbo.Applicants", "DateOfBirth");
            DropColumn("dbo.Applicants", "PasswordHash");
            DropColumn("dbo.Applicants", "Password");
            DropColumn("dbo.Applicants", "EmailAddress");
            DropTable("dbo.Members");
        }
    }
}
