﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    [DataContract]
    public class AircraftOrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public int AircraftId { get; set; }
        [DataMember]
        public string AircraftName { get; set; }
        [DataMember]
        public int? ExecutorId { get; set; }
        [DataMember]
        public string ExecutorName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
