using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<AircraftOrderViewModel> GetList();
        void CreateOrder(AircraftOrderBindingModel model);
        void TakeOrderInWork(AircraftOrderBindingModel model);
        void FinishOrder(AircraftOrderBindingModel model);
        void PayOrder(AircraftOrderBindingModel model);
        void PutElementOnWarehouse(WarehouseElementBindingModel model);
    }
}
