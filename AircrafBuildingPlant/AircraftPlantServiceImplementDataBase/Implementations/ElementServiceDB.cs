
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
    public class ElementServiceDB : IElementService
    {
        private AircraftDbContext context;
        public ElementServiceDB(AircraftDbContext context)
        {
            this.context = context;
        }
        public List<ElementViewModel> GetList()
        {
            List<ElementViewModel> result = context.Elements.Select(rec => new
           ElementViewModel
            {
                Id = rec.Id,
                ElementName = rec.ElementName
            })
            .ToList();
            return result;
        }
        public ElementViewModel GetElement(int id)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ElementViewModel
                {
                    Id = element.Id,
                    ElementName = element.ElementName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ElementBindingModel model)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ElementName ==
           model.ElementName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Elements.Add(new Element
            {
                ElementName = model.ElementName
            });
            context.SaveChanges();
        }
        public void UpdElement(ElementBindingModel model)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ElementName ==
           model.ElementName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Elements.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ElementName = model.ElementName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Elements.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
