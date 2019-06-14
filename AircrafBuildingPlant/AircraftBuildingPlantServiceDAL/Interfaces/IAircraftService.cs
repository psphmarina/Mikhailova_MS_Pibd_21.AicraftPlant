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
    [CustomInterface("Интерфейс для работы с самолётами")]
    public interface IAircraftService
    {
        [CustomMethod("Метод получения списка самолётов")]
        List<AircraftViewModel> GetList();

        [CustomMethod("Метод получения самолёта по id")]
        AircraftViewModel GetElement(int id);

        [CustomMethod("Метод добавления самолёта")]
        void AddElement(AircraftBindingModel model);

        [CustomMethod("Метод изменения данных по самолёту")]
        void UpdElement(AircraftBindingModel model);

        [CustomMethod("Метод удаления самолёта")]
        void DelElement(int id);
    }
}
