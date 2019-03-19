using AircraftBuildingPlantModel;
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceImplementList.Implementations
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
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.AircraftOrders[i].CustomerId)
                    {
                        clientFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string productName = string.Empty;
                for (int j = 0; j < source.Aircrafts.Count; ++j)
                {
                    if (source.Aircrafts[j].Id == source.AircraftOrders[i].AircraftId)
                    {
                        productName = source.Aircrafts[j].AircraftName;
                        break;
                    }
                }
                result.Add(new AircraftOrderViewModel
                {
                    Id = source.AircraftOrders[i].Id,
                    CustomerId = source.AircraftOrders[i].CustomerId,
                    CustomerFIO = clientFIO,
                    AircraftId = source.AircraftOrders[i].AircraftId,
                    AircraftName = productName,
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
                    maxId = source.AircraftOrders[i].Id;
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
            if (source.AircraftOrders[index].Status != AircraftOrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.AircraftOrders[index].Status = AircraftOrderStatus.Оплачен;
        }
    }
}
