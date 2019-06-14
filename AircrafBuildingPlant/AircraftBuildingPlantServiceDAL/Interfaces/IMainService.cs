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
    [CustomInterface("Основной интерфейс")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<AircraftOrderViewModel> GetList();

        [CustomMethod("Метод получения списка свободных заказов")]
        List<AircraftOrderViewModel> GetFreeOrders();

        [CustomMethod("Метод создания заказов")]
        void CreateOrder(AircraftOrderBindingModel model);

        [CustomMethod("Метод передачи заказа в работу")]
        void TakeOrderInWork(AircraftOrderBindingModel model);

        [CustomMethod("Метод выполнения заказа")]
        void FinishOrder(AircraftOrderBindingModel model);

        [CustomMethod("Метод оплаты заказа")]
        void PayOrder(AircraftOrderBindingModel model);

        [CustomMethod("Метод пополнения склада")]
        void PutElementOnWarehouse(WarehouseElementBindingModel model);
    }
}
