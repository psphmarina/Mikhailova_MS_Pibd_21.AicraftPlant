using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    [DataContract]
    public class WarehouseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string WarehouseName { get; set; }
        [DataMember]
        public List<WarehouseElementViewModel> WarehouseElements { get; set; }
    }
}
