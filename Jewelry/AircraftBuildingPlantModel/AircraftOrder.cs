using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantModel
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public class AircraftOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AircraftId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public AircraftOrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
