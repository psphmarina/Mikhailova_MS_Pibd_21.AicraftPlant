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
    [CustomInterface("Интерфейс для работы с работниками")]
    public interface IExecutorService
    {
        [CustomMethod("Метод получения списка работников")]
        List<ExecutorViewModel> GetList();

        [CustomMethod("Метод получения работника по id")]
        ExecutorViewModel GetElement(int id);

        [CustomMethod("Метод добавления работника")]
        void AddElement(ExecutorBindingModel model);

        [CustomMethod("Метод изменения данных по работнику")]
        void UpdElement(ExecutorBindingModel model);

        [CustomMethod("Метод удаления работника")]
        void DelElement(int id);

        [CustomMethod("Метод для получения не занятых работников")]
        ExecutorViewModel GetFreeWorker();
    }
}
