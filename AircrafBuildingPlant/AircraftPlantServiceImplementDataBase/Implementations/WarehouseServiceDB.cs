using AircraftBuildingPlantModel;
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceImplementDataBase.Implementations
{
    public class WarehouseServiceDB : IWarehouseService
    {
        private AircraftDbContext context;
        public WarehouseServiceDB(AircraftDbContext context)
        {
            this.context = context;
        }
        public List<WarehouseViewModel> GetList()
        {
            List<WarehouseViewModel> result = context.Warehouses.Select(rec => new
           WarehouseViewModel
            {
                Id = rec.Id,
                WarehouseName = rec.WarehouseName
            })
            .ToList();
            return result;
        }
        public WarehouseViewModel GetElement(int id)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new WarehouseViewModel
                {
                    Id = element.Id,
                    WarehouseName = element.WarehouseName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(WarehouseBindingModel model)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.WarehouseName ==
           model.WarehouseName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Warehouses.Add(new Warehouse
            {
                WarehouseName = model.WarehouseName
            });
            context.SaveChanges();
        }
        public void UpdElement(WarehouseBindingModel model)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.WarehouseName ==
           model.WarehouseName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.WarehouseName = model.WarehouseName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Warehouses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
