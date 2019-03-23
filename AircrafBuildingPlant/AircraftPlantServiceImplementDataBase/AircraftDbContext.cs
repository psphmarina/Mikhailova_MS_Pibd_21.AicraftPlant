using AircraftBuildingPlantModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceImplementDataBase
{
    public class AircraftDbContext : DbContext
    {
        public AircraftDbContext() : base("AbstractDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<AircraftOrder> AircraftOrders { get; set; }
        public virtual DbSet<Aircraft> Aircrafts { get; set; }
        public virtual DbSet<AircraftElement> AircraftElements { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseElement> WarehouseElements { get; set; }
    }
}
