using AircraftBuildingPlantServiceDAL.Attributies;
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftBuildingPlantServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с компонентами")]
    public interface IElementService
    {
        [CustomMethod("Метод получения списка компонентов")]
        List<ElementViewModel> GetList();

        [CustomMethod("Метод получения компонента по id")]
        ElementViewModel GetElement(int id);

        [CustomMethod("Метод добавления компонента")]
        void AddElement(ElementBindingModel model);

        [CustomMethod("Метод изменения данных по компоненту")]
        void UpdElement(ElementBindingModel model);

        [CustomMethod("Метод удаления компонента")]
        void DelElement(int id);
    }
}
