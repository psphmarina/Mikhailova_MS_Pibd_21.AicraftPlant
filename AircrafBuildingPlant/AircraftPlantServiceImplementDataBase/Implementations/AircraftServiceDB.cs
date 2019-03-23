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
    public class AircraftServiceDB : IAircraftService
    {
        private AircraftDbContext context;
        public AircraftServiceDB(AircraftDbContext context)
        {
            this.context = context;
        }
        public List<AircraftViewModel> GetList()
        {
            List<AircraftViewModel> result = context.Aircrafts.Select(rec => new
           AircraftViewModel
            {
                Id = rec.Id,
                AircraftName = rec.AircraftName,
                Price = rec.Price,
                AircraftElements = context.AircraftElements
            .Where(recPC => recPC.AircraftId == rec.Id)
           .Select(recPC => new AircraftElementViewModel
           {
               Id = recPC.Id,
               AircraftId = recPC.AircraftId,
               ElementId = recPC.ElementId,
               ElementName = recPC.Element.ElementName,
               Count = recPC.Count
           })
           .ToList()
            })
            .ToList();
            return result;
        }

        public AircraftViewModel GetElement(int id)
        {
            Aircraft element = context.Aircrafts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new AircraftViewModel
                {
                    Id = element.Id,
                    AircraftName = element.AircraftName,
                    Price = element.Price,
                    AircraftElements = context.AircraftElements
                           .Where(recPC => recPC.AircraftId == element.Id)
                           .Select(recPC => new AircraftElementViewModel
                           {
                               Id = recPC.Id,
                               AircraftId = recPC.AircraftId,
                               ElementId = recPC.ElementId,
                               ElementName = recPC.Element.ElementName,
                               Count = recPC.Count
                           })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(AircraftBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Aircraft element = context.Aircrafts.FirstOrDefault(rec =>
                   rec.AircraftName == model.AircraftName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Aircraft
                    {
                        AircraftName = model.AircraftName,
                        Price = model.Price
                    };
                    context.Aircrafts.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupElements = model.AircraftElements
                     .GroupBy(rec => rec.ElementId)
                    .Select(rec => new
                    {
                        ElementId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    // добавляем компоненты
                    foreach (var groupElement in groupElements)
                    {
                        context.AircraftElements.Add(new AircraftElement
                        {
                            AircraftId = element.Id,
                            ElementId = groupElement.ElementId,
                            Count = groupElement.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(AircraftBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Aircraft element = context.Aircrafts.FirstOrDefault(rec =>
                   rec.AircraftName == model.AircraftName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Aircrafts.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.AircraftName = model.AircraftName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.AircraftElements.Select(rec =>
                   rec.ElementId).Distinct();
                    var updateElements = context.AircraftElements.Where(rec =>
                   rec.AircraftId == model.Id && compIds.Contains(rec.ElementId));
                    foreach (var updateElement in updateElements)
                    {
                        updateElement.Count =
                       model.AircraftElements.FirstOrDefault(rec => rec.Id == updateElement.Id).Count;
                    }
                    context.SaveChanges();
                    context.AircraftElements.RemoveRange(context.AircraftElements.Where(rec =>
                    rec.AircraftId == model.Id && !compIds.Contains(rec.ElementId)));
                    context.SaveChanges();
                    // новые записи
                    var groupElements = model.AircraftElements
                    .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.ElementId)
                   .Select(rec => new
                   {
                       ElementId = rec.Key,
                       Count = rec.Sum(r => r.Count)
                   });
                    foreach (var groupElement in groupElements)
                    {
                        AircraftElement elementPC =
                       context.AircraftElements.FirstOrDefault(rec => rec.AircraftId == model.Id &&
                       rec.ElementId == groupElement.ElementId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupElement.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.AircraftElements.Add(new AircraftElement
                            {
                                AircraftId = model.Id,
                                ElementId = groupElement.ElementId,
                                Count = groupElement.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Aircraft element = context.Aircrafts.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.AircraftElements.RemoveRange(context.AircraftElements.Where(rec =>
                        rec.AircraftId == id));
                        context.Aircrafts.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
