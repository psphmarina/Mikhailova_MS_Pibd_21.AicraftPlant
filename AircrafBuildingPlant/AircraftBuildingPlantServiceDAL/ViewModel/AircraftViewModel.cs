using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    [DataContract]
    public class AircraftViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AircraftName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<AircraftElementViewModel> AircraftElements { get; set; }
    }
}
