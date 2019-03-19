using JewerlyServiceDAL.BindingModel;
using JewerlyServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyServiceDAL.Interfaces
{
    interface IMainService
    {
        List<JewelOrderViewModel> GetList();
        void CreateOrder(JewelOrderBindingModel model);
        void TakeOrderInWork(JewelOrderBindingModel model);
        void FinishOrder(JewelOrderBindingModel model);
        void PayOrder(JewelOrderBindingModel model);
    }
}
