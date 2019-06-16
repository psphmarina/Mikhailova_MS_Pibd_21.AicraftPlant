using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.Interfaces
{
    public interface IReplayService
    {
        void SaveAircraftPrice(ReplayBindingModel model);
        List<WarehousesLoadViewModel> GetWarehousesLoad();
        void SaveWarehousesLoad(ReplayBindingModel model);
        List<CustomerAircraftOrdersModel> GetCustomerAircraftOrders(ReplayBindingModel model);
        void SaveCustomerOrders(ReplayBindingModel model);
    }
}
