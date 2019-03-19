using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryModel;

namespace JewelryServiceImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Customer> Customers { get; set; }
        public List<Element> Elements { get; set; }
        public List<JewelryOrder> JewelryOrders { get; set; }
        public List<Jewel> Jewels { get; set; }
        public List<JewelElement> JewelElements { get; set; }
        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Elements = new List<Element>();
            JewelryOrders = new List<JewelryOrder>();
            Jewels = new List<Jewel>();
            JewelElements = new List<JewelElement>();
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
