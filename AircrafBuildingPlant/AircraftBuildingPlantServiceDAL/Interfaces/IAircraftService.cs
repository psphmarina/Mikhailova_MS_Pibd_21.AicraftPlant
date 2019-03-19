using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.Interfaces
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
