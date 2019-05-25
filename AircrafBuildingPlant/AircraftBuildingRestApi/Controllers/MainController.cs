using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using AircraftBuildingRestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AircraftBuildingRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;
        private readonly IExecutorService _serviceExecutor;
        public MainController(IMainService service, IExecutorService
       serviceExecutor)
        {
            _service = service;
            _serviceExecutor = serviceExecutor;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void CreateOrder(AircraftOrderBindingModel model)
        {
            _service.CreateOrder(model);
        }
        [HttpPost]
        public void PayOrder(AircraftOrderBindingModel model)
        {
            _service.PayOrder(model);
        }
        [HttpPost]
        public void PutElementOnWarehouse(WarehouseElementBindingModel model)
        {
            _service.PutElementOnWarehouse(model);
        }
        [HttpPost]
        public void StartWork()
        {
            List<AircraftOrderViewModel> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                ExecutorViewModel impl = _serviceExecutor.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkExecutor(_service, _serviceExecutor, impl.Id, order.Id);
            }
        }
    }
}
