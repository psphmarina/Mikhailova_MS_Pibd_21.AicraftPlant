using AircraftPlantServiceDAL.Interfaces;
using AircraftPlantServiceImplementList.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AircraftPlantView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomertService, CustomerServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElementService, ElementServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAircraftService, AircraftServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
            HierarchicalLifetimeManager()); 
            return currentContainer;
        }
    }
}
