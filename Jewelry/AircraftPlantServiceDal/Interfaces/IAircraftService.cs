using AircraftPlantServiceDAL.BindingModel;
using AircraftPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceDAL.Interfaces
{
    public interface IAircraftService
    {
        List<AircraftViewModel> GetList();
        AircraftViewModel GetElement(int id);
        void AddElement(AircraftBindingModel model);
        void UpdElement(AircraftBindingModel model);
        void DelElement(int id);
    }
}
