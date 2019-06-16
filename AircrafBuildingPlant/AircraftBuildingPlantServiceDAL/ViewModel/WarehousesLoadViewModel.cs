﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.ViewModel
{
    public class WarehousesLoadViewModel
    {
        public string WarehouseName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Elements { get; set; }
    }
}
