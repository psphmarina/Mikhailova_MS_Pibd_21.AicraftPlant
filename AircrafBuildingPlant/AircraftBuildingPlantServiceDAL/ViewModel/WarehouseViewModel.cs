using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseElementViewModel> WarehouseElements { get; set; }
    }
}
