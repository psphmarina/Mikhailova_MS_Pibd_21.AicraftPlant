using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using AircraftBuildingPlantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlantServiceImplementDataBase.Implementations
{
    public class ExecutorServiceDB : IExecutorService
    {
        private AircraftDbContext context;
        public ExecutorServiceDB(AircraftDbContext context)
        {
            this.context = context;
        }
        public List<ExecutorViewModel> GetList()
        {
            List<ExecutorViewModel> result = context.Executors
            .Select(rec => new ExecutorViewModel
            {
                Id = rec.Id,
                ExecutorFIO = rec.ExecutorFIO
            })
            .ToList();
            return result;
        }
        public ExecutorViewModel GetElement(int id)
        {
            AircraftBuildingPlantModel.Executor element = context.Executors.FirstOrDefault(rec => rec.Id ==
           id);
            if (element != null)
            {
                return new ExecutorViewModel
                {
                    Id = element.Id,
                    ExecutorFIO = element.ExecutorFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ExecutorBindingModel model)
        {
            AircraftBuildingPlantModel.Executor element = context.Executors.FirstOrDefault(rec =>
           rec.ExecutorFIO == model.ExecutorFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Executors.Add(new Executor
            {
                ExecutorFIO = model.ExecutorFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(ExecutorBindingModel model)
        {
            Executor element = context.Executors.FirstOrDefault(rec =>
            rec.ExecutorFIO == model.ExecutorFIO &&
           rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
        element = context.Executors.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ExecutorFIO = model.ExecutorFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Executor element = context.Executors.FirstOrDefault(rec => rec.Id ==
           id);
            if (element != null)
            {
                context.Executors.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public ExecutorViewModel GetFreeWorker()
        {
            var ordersWorker = context.Executors
            .Select(x => new
            {
                ImplId = x.Id,
                Count = context.AircraftOrders.Where(o => o.Status == AircraftOrderStatus.Выполняется
     && o.ExecutorId == x.Id).Count()
            })
            .OrderBy(x => x.Count)
            .FirstOrDefault();
            if (ordersWorker != null)
            {
                return GetElement(ordersWorker.ImplId);
            }
            return null;
        }

    }
}
