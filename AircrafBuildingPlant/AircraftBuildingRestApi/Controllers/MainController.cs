using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
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
        public MainController(IMainService service)
        {
            _service = service;
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
        public void TakeOrderInWork(AircraftOrderBindingModel model)
        {
            _service.TakeOrderInWork(model);
        }
        [HttpPost]
 public void FinishOrder(AircraftOrderBindingModel model)
        {
            _service.FinishOrder(model);
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
    }
}
