using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantModel
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class AircraftElement
    {
        public int Id { get; set; }
        public int AircraftId { get; set; }
        public int ElementId { get; set; }
        public int Count { get; set; }
        public virtual Element Element { get; set; }
        public virtual Aircraft Aircraft { get; set; }
    }
}
