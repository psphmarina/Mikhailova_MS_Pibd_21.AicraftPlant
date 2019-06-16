using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantModel
{
    public class Executor
    {
        public int Id { get; set; }
        [Required]
        public string ExecutorFIO { get; set; }
        [ForeignKey("ExecutorId")]
        public virtual List<AircraftOrder> Orders { get; set; }
    }
}
