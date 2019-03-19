using AircraftBuildingPlantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Customer> Customers { get; set; }
        public List<Element> Elements { get; set; }
        public List<AircraftOrder> AircraftOrders { get; set; }
        public List<Aircraft> Aircrafts { get; set; }
        public List<AircraftElement> AircraftElements { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseElement> WarehouseElements { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Elements = new List<Element>();
            AircraftOrders = new List<AircraftOrder>();
            Aircrafts = new List<Aircraft>();
            AircraftElements = new List<AircraftElement>();
            Warehouses = new List<Warehouse>();
            WarehouseElements = new List<WarehouseElement>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
