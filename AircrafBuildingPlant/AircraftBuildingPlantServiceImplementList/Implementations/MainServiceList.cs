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
            List<AircraftOrderViewModel> result = source.AircraftOrders
            .Select(rec => new AircraftOrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                AircraftId = rec.AircraftId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = source.Customers.FirstOrDefault(recC => recC.Id ==
                rec.CustomerId)?.CustomerFIO,
                AircraftName = source.Aircrafts.FirstOrDefault(recP => recP.Id ==
                rec.AircraftId)?.AircraftName,
            })
.ToList();
            return result;
        }

        public void CreateOrder(AircraftOrderBindingModel model)
        {
            int maxId = source.AircraftOrders.Count > 0 ? source.AircraftOrders.Max(rec => rec.Id) : 0;
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
            AircraftOrder element = source.AircraftOrders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != AircraftOrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var aircraftElements = source.AircraftElements.Where(rec => rec.AircraftId
            == element.AircraftId);
            foreach (var aircraftElement in aircraftElements)
            {
                int countOnWarehouses = source.WarehouseElements
                .Where(rec => rec.ElementId == aircraftElement.ElementId)
                .Sum(rec => rec.Count);
                if (countOnWarehouses < aircraftElement.Count * element.Count)
                {
                    var componentName = source.Elements.FirstOrDefault(rec => rec.Id ==
                    aircraftElement.ElementId);
                    throw new Exception("Не достаточно компонента " +
                    componentName?.ElementName + " требуется " + (aircraftElement.Count * element.Count) +
                    ", в наличии " + countOnWarehouses);
                }
            }
            // списываем
            foreach (var aircraftElement in aircraftElements)
            {
                int countOnWarehouses = aircraftElement.Count * element.Count;
                var warehouseElements = source.WarehouseElements.Where(rec => rec.ElementId
                == aircraftElement.ElementId);
                foreach (var warehouseElement in warehouseElements)
                {
                    // компонентов на одном слкаде может не хватать
                    if (warehouseElement.Count >= countOnWarehouses)
                    {
                        warehouseElement.Count -= countOnWarehouses;
                        break;
                    }
                    else
                    {
                        countOnWarehouses -= warehouseElement.Count;
                        warehouseElement.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = AircraftOrderStatus.Выполняется;
        }
        public void FinishOrder(AircraftOrderBindingModel model)
        {
            AircraftOrder element = source.AircraftOrders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != AircraftOrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = AircraftOrderStatus.Готов;
        }
        public void PayOrder(AircraftOrderBindingModel model)
        {
            AircraftOrder element = source.AircraftOrders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != AircraftOrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = AircraftOrderStatus.Оплачен;
        }

        public void PutElementOnWarehouse(WarehouseElementBindingModel model)
        {
            WarehouseElement element = source.WarehouseElements.FirstOrDefault(rec =>
            rec.WarehouseId == model.WarehouseId && rec.ElementId == model.ElementId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.WarehouseElements.Count > 0 ?
                source.WarehouseElements.Max(rec => rec.Id) : 0;
                source.WarehouseElements.Add(new WarehouseElement
                {
                    Id = ++maxId,
                    WarehouseId = model.WarehouseId,
                    ElementId = model.ElementId,
                    Count = model.Count
                });
            }
        }
    }
}
