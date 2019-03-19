using AircraftBuildingPlantModel;
using AircraftPlantServiceDAL.BindingModel;
using AircraftPlantServiceDAL.Interfaces;
using AircraftPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceImplementList.Implementations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<AircraftOrderViewModel> GetList()
        {
            List<AircraftOrderViewModel> result = new List<AircraftOrderViewModel>();
            for (int i = 0; i < source.AircraftOrders.Count; ++i)
            {
                string customerFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.AircraftOrders[i].CustomerId)
                    {
                       customerFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string aircraftName = string.Empty;
                for (int j = 0; j < source.Aircrafts.Count; ++j)
                {
                    if (source.Aircrafts[j].Id == source.AircraftOrders[i].AircraftId)
                    {
                        aircraftName = source.Aircrafts[j].AircraftName;
                        break;
                    }
                }
                result.Add(new AircraftOrderViewModel
                {
                    Id = source.AircraftOrders[i].Id,
                    CustomerId = source.AircraftOrders[i].CustomerId,
                    CustomerFIO = customerFIO,
                    AircraftId = source.AircraftOrders[i].AircraftId,
                    AircraftName = aircraftName,
                    Count = source.AircraftOrders[i].Count,
                    Sum = source.AircraftOrders[i].Sum,
                    DateCreate = source.AircraftOrders[i].DateCreate.ToLongDateString(),
                    DateImplement = source.AircraftOrders[i].DateImplement?.ToLongDateString(),
                    Status = source.AircraftOrders[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateOrder(AircraftOrderBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.AircraftOrders.Count; ++i)
            {
                if (source.AircraftOrders[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
            source.AircraftOrders.Add(new AircraftOrder
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                AircraftId = model.AircraftId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = AircraftOrderStatus.Принят
            });
        }
        public void TakeOrderInWork(AircraftOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.AircraftOrders.Count; ++i)
            {
                if (source.AircraftOrders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.AircraftOrders[index].Status != AircraftOrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.AircraftOrders[index].DateImplement = DateTime.Now;
            source.AircraftOrders[index].Status = AircraftOrderStatus.Выполняется;
        }
        public void FinishOrder(AircraftOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.AircraftOrders.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден"); 
            }
            if (source.AircraftOrders[index].Status != AircraftOrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.AircraftOrders[index].Status = AircraftOrderStatus.Готов;
        }
        public void PayOrder(AircraftOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.AircraftOrders.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.AircraftOrders[index].Status != AircraftOrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.AircraftOrders[index].Status = AircraftOrderStatus.Оплачен;
        }
    }
}
