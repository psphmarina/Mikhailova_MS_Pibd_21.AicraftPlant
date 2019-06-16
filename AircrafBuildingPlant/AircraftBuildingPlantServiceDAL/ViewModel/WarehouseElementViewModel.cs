using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    [DataContract]
    public class WarehouseElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int WarehouseId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public string ElementName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
