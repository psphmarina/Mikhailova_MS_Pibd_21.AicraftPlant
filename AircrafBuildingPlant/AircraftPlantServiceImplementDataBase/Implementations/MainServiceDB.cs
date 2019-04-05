
using AircraftBuildingPlantModel;
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private AircraftDbContext context;
        public MainServiceDB(AircraftDbContext context)
        {
            this.context = context;
        }
        public List<AircraftOrderViewModel> GetList()
        {
            List<AircraftOrderViewModel> result = context.AircraftOrders.Select(rec => new AircraftOrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                AircraftId = rec.AircraftId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
                AircraftName = rec.Aircraft.AircraftName
            })
            .ToList();
            return result;
        }
        public void CreateOrder(AircraftOrderBindingModel model)
        {
            context.AircraftOrders.Add(new AircraftOrder
            {
                CustomerId = model.CustomerId,
                AircraftId = model.AircraftId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = AircraftOrderStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeOrderInWork(AircraftOrderBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    AircraftOrder element = context.AircraftOrders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != AircraftOrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var aircraftElements = context.AircraftElements.Include(rec =>
 rec.Element).Where(rec => rec.AircraftId == element.AircraftId);
                    // списываем
                    foreach (var aircraftElement in aircraftElements)
                    {
                        int countOnWarehouses = aircraftElement.Count * element.Count;
                        var warehouseElements = context.WarehouseElements.Where(rec =>
                        rec.ElementId == aircraftElement.ElementId);
                        foreach (var warehouseElement in warehouseElements)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (warehouseElement.Count >= countOnWarehouses)
                            {
                                warehouseElement.Count -= countOnWarehouses;
                                countOnWarehouses = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnWarehouses -= warehouseElement.Count;
                                warehouseElement.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnWarehouses > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                           aircraftElement.Element.ElementName + " требуется " + aircraftElement.Count + ", не хватает " + countOnWarehouses);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = AircraftOrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(AircraftOrderBindingModel model)
        {
            AircraftOrder element = context.AircraftOrders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != AircraftOrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = AircraftOrderStatus.Готов;
            context.SaveChanges();
        }
        public void PayOrder(AircraftOrderBindingModel model)
        {
            AircraftOrder element = context.AircraftOrders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != AircraftOrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = AircraftOrderStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutElementOnWarehouse(WarehouseElementBindingModel model)
        {
            WarehouseElement element = context.WarehouseElements.FirstOrDefault(rec =>
           rec.WarehouseId == model.WarehouseId && rec.ElementId == model.ElementId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.WarehouseElements.Add(new WarehouseElement
                {
                    WarehouseId = model.WarehouseId,
                    ElementId = model.ElementId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
