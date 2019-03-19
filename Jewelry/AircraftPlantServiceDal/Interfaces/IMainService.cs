using AircraftPlantServiceDAL.BindingModel;
using AircraftPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<AircraftOrderViewModel> GetList();
        void CreateOrder(AircraftOrderBindingModel model);
        void TakeOrderInWork(AircraftOrderBindingModel model);
        void FinishOrder(AircraftOrderBindingModel model);
        void PayOrder(AircraftOrderBindingModel model);
    }
}
