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
    [CustomInterface("Интерфейс для работы с складами")]
    public interface IWarehouseService
    {
        [CustomMethod("Метод получения списка складов")]
        List<WarehouseViewModel> GetList();

        [CustomMethod("Метод получения склада по id")]
        WarehouseViewModel GetElement(int id);

        [CustomMethod("Метод добавления склада")]
        void AddElement(WarehouseBindingModel model);

        [CustomMethod("Метод изменения данных по складу")]
        void UpdElement(WarehouseBindingModel model);

        [CustomMethod("Метод удаления склада")]
        void DelElement(int id);
    }
}
