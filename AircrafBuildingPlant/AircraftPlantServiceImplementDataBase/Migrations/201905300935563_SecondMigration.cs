namespace AircraftPlantServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageInfoes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MessageInfoes", new[] { "CustomerId" });
            DropColumn("dbo.Customers", "Mail");
            DropTable("dbo.MessageInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Mail", c => c.String());
            CreateIndex("dbo.MessageInfoes", "CustomerId");
            AddForeignKey("dbo.MessageInfoes", "CustomerId", "dbo.Customers", "Id");
        }
    }
}
