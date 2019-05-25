namespace AircraftPlantServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secmigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExecutorFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AircraftOrders", "ExecutorId", c => c.Int());
            CreateIndex("dbo.AircraftOrders", "ExecutorId");
            AddForeignKey("dbo.AircraftOrders", "ExecutorId", "dbo.Executors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AircraftOrders", "ExecutorId", "dbo.Executors");
            DropIndex("dbo.AircraftOrders", new[] { "ExecutorId" });
            DropColumn("dbo.AircraftOrders", "ExecutorId");
            DropTable("dbo.Executors");
        }
    }
}
