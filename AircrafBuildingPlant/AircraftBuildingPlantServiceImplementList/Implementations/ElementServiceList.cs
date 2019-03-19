﻿using AircraftBuildingPlantModel;
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
    public class ElementServiceList : IElementService
    {
        private DataListSingleton source;
        public ElementServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ElementViewModel> GetList()
        {
            List<ElementViewModel> result = new List<ElementViewModel>();
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                result.Add(new ElementViewModel
                {
                    Id = source.Elements[i].Id,
                    ElementName = source.Elements[i].ElementName
                });
            }

            return result;
        }
        public ElementViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].Id == id)
                {
                    return new ElementViewModel
                    {
                        Id = source.Elements[i].Id,
                        ElementName = source.Elements[i].ElementName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ElementBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].Id > maxId)
                {
                    maxId = source.Elements[i].Id;
                }
                if (source.Elements[i].ElementName == model.ElementName)
                {
                    throw new Exception("Уже есть запчасть с таким названием");
                }
            }
            source.Elements.Add(new Element
            {
                Id = maxId + 1,
                ElementName = model.ElementName
            });
        }
        public void UpdElement(ElementBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Elements[i].ElementName == model.ElementName &&
                source.Elements[i].Id != model.Id)
                {
                    throw new Exception("Уже есть запчасть с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Elements[index].ElementName = model.ElementName;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].Id == id)
                {
                    source.Elements.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
