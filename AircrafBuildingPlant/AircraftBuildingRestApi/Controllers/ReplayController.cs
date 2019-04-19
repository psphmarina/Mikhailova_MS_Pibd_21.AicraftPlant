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
    public class ReplayController : ApiController
    {
        private readonly IReplayService _service;
        public ReplayController(IReplayService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetWarehousesLoad()
        {
            var list = _service.GetWarehousesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetCustomerOrders(ReplayBindingModel model)
        {
            var list = _service.GetCustomerAircraftOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveProductPrice(ReplayBindingModel model)
        {
            _service.SaveAircraftPrice(model);
        }
        [HttpPost]
        public void SaveWarehousesLoad(ReplayBindingModel model)
        {
            _service.SaveWarehousesLoad(model);
        }
        [HttpPost]
        public void SaveCustomerOrders(ReplayBindingModel model)
        {
            _service.SaveCustomerOrders(model);
        }
    }
}
