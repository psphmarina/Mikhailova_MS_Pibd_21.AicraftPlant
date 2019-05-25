﻿using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AircraftBuildingRestApi.Services
{
    public class WorkExecutor
    {
        private readonly IMainService _service;
        private readonly IExecutorService _serviceExecutor;
        private readonly int _implementerId;
        private readonly int _orderId;
        // семафор
        static Semaphore _sem = new Semaphore(3, 3);
        Thread myThread;
        public WorkExecutor(IMainService service, IExecutorService
       serviceExecutor, int implementerId, int orderId)
        {
            _service = service;
            _serviceExecutor = serviceExecutor;
            _implementerId = implementerId;
            _orderId = orderId;
            try
            {
                _service.TakeOrderInWork(new AircraftOrderBindingModel
                {
                    Id = _orderId,
                    ExecutorId = _implementerId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }
        public void Work()
        {
            try
            {
                // забиваем мастерскую
                _sem.WaitOne();
                // Типа выполняем
                Thread.Sleep(10000);
                _service.FinishOrder(new AircraftOrderBindingModel
            {
                    Id = _orderId
 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую
                _sem.Release();
            }
        }
    }
}