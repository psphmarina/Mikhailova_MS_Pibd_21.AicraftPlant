using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    public class AircraftViewModel
    {
        public int Id { get; set; }
        public string AircraftName { get; set; }
        public decimal Price { get; set; }
        public List<AircraftElementViewModel> AircraftElements { get; set; }
    }
}
