﻿using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceImplementList.Implementations;
using System;
using System.Collections.Generic;
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
            currentContainer.RegisterType<ICustomertService, CustomerServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElementService, ElementServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAircraftService, AircraftServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseService, WarehouseServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
