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
    public class AircraftServiceList : IAircraftService
    {
        private DataListSingleton source;

        public AircraftServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<AircraftViewModel> GetList()
        {
            List<AircraftViewModel> result = source.Aircrafts
                .Select(rec => new AircraftViewModel
                {
                    Id = rec.Id,
                    AircraftName = rec.AircraftName,
                    Price = rec.Price,
                    AircraftElements = source.AircraftElements
                        .Where(recPC => recPC.AircraftId == rec.Id)
                        .Select(recPC => new AircraftElementViewModel
                        {
                            Id = recPC.Id,
                            AircraftId = recPC.AircraftId,
                            ElementId = recPC.ElementId,
                            ElementName = source.Elements.FirstOrDefault(recC =>
    recC.Id == recPC.ElementId)?.ElementName,
                            Count = recPC.Count
                        })
                         .ToList()
                })
                  .ToList();
            return result;
        }

        public AircraftViewModel GetElement(int id)
        {
            Aircraft element = source.Aircrafts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new AircraftViewModel
                {
                    Id = element.Id,
                    AircraftName = element.AircraftName,
                    Price = element.Price,
                    AircraftElements = source.AircraftElements
                .Where(recPC => recPC.AircraftId == element.Id)
                .Select(recPC => new AircraftElementViewModel
                {
                    Id = recPC.Id,
                    AircraftId = recPC.AircraftId,
                    ElementId = recPC.ElementId,
                    ElementName = source.Elements.FirstOrDefault(recC =>
    recC.Id == recPC.ElementId)?.ElementName,
                    Count = recPC.Count
                })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(AircraftBindingModel model)
        {
            Aircraft element = source.Aircrafts.FirstOrDefault(rec => rec.AircraftName == model.AircraftName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Aircrafts.Count > 0 ? source.Aircrafts.Max(rec => rec.Id) :
            0;
            source.Aircrafts.Add(new Aircraft
            {
                Id = maxId + 1,
                AircraftName = model.AircraftName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.AircraftElements.Count > 0 ?
            source.AircraftElements.Max(rec => rec.Id) : 0;
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
                source.AircraftElements.Add(new AircraftElement
                {
                    Id = ++maxPCId,
                    AircraftId = maxId + 1,
                    ElementId = groupElement.ElementId,
                    Count = groupElement.Count
                });
            }
        }

        public void UpdElement(AircraftBindingModel model)
        {
            Aircraft element = source.Aircrafts.FirstOrDefault(rec => rec.AircraftName ==
model.AircraftName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Aircrafts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.AircraftName = model.AircraftName;
            element.Price = model.Price;
            int maxPCId = source.AircraftElements.Count > 0 ?
            source.AircraftElements.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.AircraftElements.Select(rec =>
            rec.ElementId).Distinct();
            var updateElements = source.AircraftElements.Where(rec => rec.AircraftId ==
            model.Id && compIds.Contains(rec.ElementId));
            foreach (var updateElement in updateElements)
            {
                updateElement.Count = model.AircraftElements.FirstOrDefault(rec =>
                rec.Id == updateElement.Id).Count;
            }
            source.AircraftElements.RemoveAll(rec => rec.AircraftId == model.Id &&
            !compIds.Contains(rec.ElementId));
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
                AircraftElement elementPC = source.AircraftElements.FirstOrDefault(rec
                => rec.AircraftId == model.Id && rec.ElementId == groupElement.ElementId);
                if (elementPC != null)
                {
                    elementPC.Count += groupElement.Count;
                }
                else
                {
                    source.AircraftElements.Add(new AircraftElement
                    {
                        Id = ++maxPCId,
                        AircraftId = model.Id,
                        ElementId = groupElement.ElementId,
                        Count = groupElement.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Aircraft element = source.Aircrafts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.AircraftElements.RemoveAll(rec => rec.AircraftId == id);
                source.Aircrafts.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
