using AircraftBuildingPlantServiceDAL.Attributies;
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчётами")]
    public interface IReplayService
    {
        [CustomMethod("Метод получения цены")]
        void SaveAircraftPrice(ReplayBindingModel model);

        [CustomMethod("Метод получения отчётов по загруженности складов")]
        List<WarehousesLoadViewModel> GetWarehousesLoad();

        [CustomMethod("Метод получения отчётов по загруженности складов")]
        void SaveWarehousesLoad(ReplayBindingModel model);

        [CustomMethod("Метод получения заказов по клиентам")]
        List<CustomerAircraftOrdersModel> GetCustomerAircraftOrders(ReplayBindingModel model);

        [CustomMethod("Метод получения заказов по клиентам")]
        void SaveCustomerOrders(ReplayBindingModel model);
    }
}
