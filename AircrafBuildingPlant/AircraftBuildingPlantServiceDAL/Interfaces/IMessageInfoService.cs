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
    [CustomInterface("Интерфейс для работы MessageInfo ")]
    public interface IMessageInfoService
    {
        [CustomMethod("Метод получения списка")]
        List<MessageInfoViewModel> GetList();

        [CustomMethod("Метод получения по id")]
        MessageInfoViewModel GetElement(int id);

        [CustomMethod("Метод добавления")]
        void AddElement(MessageInfoBindingModel model);
    }
}
