namespace AircraftPlantServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AircraftElements",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AircraftId = c.Int(nullable: false),
                    ElementId = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aircraft", t => t.AircraftId, cascadeDelete: true)
                .ForeignKey("dbo.Elements", t => t.ElementId, cascadeDelete: true)
                .Index(t => t.AircraftId)
                .Index(t => t.ElementId);

            CreateTable(
                "dbo.Aircraft",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AircraftName = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Elements",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ElementName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AircraftOrders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    AircraftId = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                    Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Status = c.Int(nullable: false),
                    DateCreate = c.DateTime(nullable: false),
                    DateImplement = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aircraft", t => t.AircraftId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.AircraftId);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerFIO = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.WarehouseElements",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    WarehouseId = c.Int(nullable: false),
                    ElementId = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Elements", t => t.ElementId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.ElementId);

            CreateTable(
                "dbo.Warehouses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    WarehouseName = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.WarehouseElements", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseElements", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.AircraftOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AircraftOrders", "AircraftId", "dbo.Aircraft");
            DropForeignKey("dbo.AircraftElements", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.AircraftElements", "AircraftId", "dbo.Aircraft");
            DropIndex("dbo.WarehouseElements", new[] { "ElementId" });
            DropIndex("dbo.WarehouseElements", new[] { "WarehouseId" });
            DropIndex("dbo.AircraftOrders", new[] { "AircraftId" });
            DropIndex("dbo.AircraftOrders", new[] { "CustomerId" });
            DropIndex("dbo.AircraftElements", new[] { "ElementId" });
            DropIndex("dbo.AircraftElements", new[] { "AircraftId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.WarehouseElements");
            DropTable("dbo.Customers");
            DropTable("dbo.AircraftOrders");
            DropTable("dbo.Elements");
            DropTable("dbo.Aircraft");
            DropTable("dbo.AircraftElements");
        }
    }
}
