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
            List<AircraftViewModel> result = new List<AircraftViewModel>();
            for (int i = 0; i < source.Aircrafts.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<AircraftElementViewModel> productElements = new
               List<AircraftElementViewModel>();
                for (int j = 0; j < source.AircraftElements.Count; ++j)
                {
                    if (source.AircraftElements[j].AircraftId == source.Aircrafts[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.AircraftElements[j].ElementId ==
                           source.Elements[k].Id)
                            {
                                componentName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        productElements.Add(new AircraftElementViewModel
                        {
                            Id = source.AircraftElements[j].Id,
                            AircraftId = source.AircraftElements[j].AircraftId,
                            ElementId = source.AircraftElements[j].ElementId,
                            ElementName = componentName,
                            Count = source.AircraftElements[j].Count
                        });
                    }
                }
                result.Add(new AircraftViewModel
                {
                    Id = source.Aircrafts[i].Id,
                    AircraftName = source.Aircrafts[i].AircraftName,
                    Price = source.Aircrafts[i].Price,
                    AircraftElements = productElements
                });
            }
            return result;
        }
        public AircraftViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Aircrafts.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их  количество
                List<AircraftElementViewModel> productElements = new
    List<AircraftElementViewModel>();
                for (int j = 0; j < source.AircraftElements.Count; ++j)
                {
                    if (source.AircraftElements[j].AircraftId == source.Aircrafts[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.AircraftElements[j].ElementId ==
                           source.Elements[k].Id)
                            {
                                componentName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        productElements.Add(new AircraftElementViewModel
                        {
                            Id = source.AircraftElements[j].Id,
                            AircraftId = source.AircraftElements[j].AircraftId,
                            ElementId = source.AircraftElements[j].ElementId,
                            ElementName = componentName,
                            Count = source.AircraftElements[j].Count
                        });
                    }
                }
                if (source.Aircrafts[i].Id == id)
                {
                    return new AircraftViewModel
                    {
                        Id = source.Aircrafts[i].Id,
                        AircraftName = source.Aircrafts[i].AircraftName,
                        Price = source.Aircrafts[i].Price,
                        AircraftElements = productElements
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(AircraftBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Aircrafts.Count; ++i)
            {
                if (source.Aircrafts[i].Id > maxId)
                {
                    maxId = source.Aircrafts[i].Id;
                }
                if (source.Aircrafts[i].AircraftName == model.AircraftName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Aircrafts.Add(new Aircraft
            {
                Id = maxId + 1,
                AircraftName = model.AircraftName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.AircraftElements.Count; ++i)
            {
                if (source.AircraftElements[i].Id > maxPCId)
                {
                    maxPCId = source.AircraftElements[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.AircraftElements.Count; ++i)
            {
                for (int j = 1; j < model.AircraftElements.Count; ++j)
                {
                    if (model.AircraftElements[i].ElementId ==
                    model.AircraftElements[j].ElementId)
                    {
                        model.AircraftElements[i].Count +=
                        model.AircraftElements[j].Count;
                        model.AircraftElements.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.AircraftElements.Count; ++i)
            {
                source.AircraftElements.Add(new AircraftElement
                {
                    Id = ++maxPCId,
                    AircraftId = maxId + 1,
                    ElementId = model.AircraftElements[i].ElementId,
                    Count = model.AircraftElements[i].Count
                });
            }
        }
        public void UpdElement(AircraftBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Aircrafts.Count; ++i)
            {
                if (source.Aircrafts[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Aircrafts[i].AircraftName == model.AircraftName &&
                source.Aircrafts[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Aircrafts[index].AircraftName = model.AircraftName;
            source.Aircrafts[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.AircraftElements.Count; ++i)
            {
                if (source.AircraftElements[i].Id > maxPCId)
                {
                    maxPCId = source.AircraftElements[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.AircraftElements.Count; ++i)
            {
                if (source.AircraftElements[i].AircraftId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.AircraftElements.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.AircraftElements[i].Id ==
                       model.AircraftElements[j].Id)
                        {
                            source.AircraftElements[i].Count =
                           model.AircraftElements[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.AircraftElements.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.AircraftElements.Count; ++i)
            {
                if (model.AircraftElements[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.AircraftElements.Count; ++j)
                    {
                        if (source.AircraftElements[j].AircraftId == model.Id &&
                        source.AircraftElements[j].ElementId ==
                       model.AircraftElements[i].ElementId)
                        {
                            source.AircraftElements[j].Count +=
                           model.AircraftElements[i].Count;
                            model.AircraftElements[i].Id =
                           source.AircraftElements[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.AircraftElements[i].Id == 0)
                    {
                        source.AircraftElements.Add(new AircraftElement
                        {
                            Id = ++maxPCId,
                            AircraftId = model.Id,
                            ElementId = model.AircraftElements[i].ElementId,
                            Count = model.AircraftElements[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.AircraftElements.Count; ++i)
            {
                if (source.AircraftElements[i].AircraftId == id)
                {
                    source.AircraftElements.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Aircrafts.Count; ++i)
            {
                if (source.Aircrafts[i].Id == id)
                {
                    source.Aircrafts.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
