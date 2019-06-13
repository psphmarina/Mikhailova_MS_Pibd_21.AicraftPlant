using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantModel
{
    public class WarehouseElement
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ElementId { get; set; }
        public int Count { get; set; }
        public virtual Element Element { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
