using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantModel
{
    /// <summary>
    /// Клиент магазина
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerFIO { get; set; }
        [ForeignKey("CustomerId")]
        public virtual List<AircraftOrder> AircraftOrders { get; set; }
    }
}
