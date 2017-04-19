namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 70),
                        EmailAddress = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 600),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        PasswordSalt = c.String(nullable: false, maxLength: 10),
                        Address1 = c.String(nullable: false, maxLength: 150),
                        Address2 = c.String(maxLength: 150),
                        Gender = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 50),
                        Province = c.String(nullable: false, maxLength: 60),
                        PostalCode = c.String(nullable: false, maxLength: 8),
                        Phone = c.String(nullable: false, maxLength: 15),
                        AlternatePhone = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
