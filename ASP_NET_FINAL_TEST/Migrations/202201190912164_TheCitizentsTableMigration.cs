namespace ASP_NET_FINAL_TEST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheCitizentsTableMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        FatherName = c.String(),
                        Gender = c.String(),
                        BornedInVillage = c.Boolean(nullable: false),
                        BirthDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citizens");
        }
    }
}
