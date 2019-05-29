﻿using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftPlantServiceImplementDataBase;
using AircraftPlantServiceImplementDataBase.Implementations;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            APIClient.Connect();
            MailClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        
    }
}
