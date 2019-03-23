using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    public class CustomerAircraftOrdersModel
    {
        public string CustomerName { get; set; }
        public string DateCreate { get; set; }
        public string AircraftName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
