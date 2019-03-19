using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.BindingModel
{
    public class AircraftBindingModel
    {
        public int Id { get; set; }
        public string AircraftName { get; set; }
        public decimal Price { get; set; }
        public List<AircraftElementBindingModel> AircraftElements { get; set; }
    }
}
