using AircraftPlantServiceDAL.BindingModel;
using AircraftPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceDAL.Interfaces
{
    public interface IAircraftElementService
    {
        List<AircraftElementViewModel> GetList();
        AircraftElementViewModel GetElement(int id);
        void AddElement(AircraftElementBindingModel model);
        void UpdElement(AircraftElementBindingModel model);
        void DelElement(int id);
    }
}
