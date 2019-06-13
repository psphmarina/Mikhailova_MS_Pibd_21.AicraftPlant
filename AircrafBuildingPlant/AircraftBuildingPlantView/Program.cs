using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceImplementList.Implementations;
using AircraftPlantServiceImplementDataBase;
using AircraftPlantServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AircraftBuildingPlantView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }


        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AircraftDbContext>(new
HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomertService, CustomerServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElementService, ElementServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAircraftService, AircraftServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseService, WarehouseServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
