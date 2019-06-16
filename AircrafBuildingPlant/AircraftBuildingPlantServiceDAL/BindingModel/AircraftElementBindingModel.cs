using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.BindingModel
{
    [DataContract]
    public class AircraftElementBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int AircraftId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
