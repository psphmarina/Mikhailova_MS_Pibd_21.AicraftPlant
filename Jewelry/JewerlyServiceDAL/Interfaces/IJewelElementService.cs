using JewerlyServiceDAL.BindingModel;
using JewerlyServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyServiceDAL.Interfaces
{
    interface IJewelElementService
    {
        List<JewelElementViewModel> GetList();
        JewelElementViewModel GetElement(int id);
        void AddElement(JewelElementBindingModel model);
        void UpdElement(JewelElementBindingModel model);
        void DelElement(int id);
    }
}
