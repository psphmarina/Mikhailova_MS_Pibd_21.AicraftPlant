using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    [DataContract]
    public class AircraftElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int AircraftId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
