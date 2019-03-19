using JewerlyServiceDAL.BindingModel;
using JewerlyServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyServiceDAL.Interfaces
{
    interface IJewelService
    {
        List<JewelViewModel> GetList();
       JewelViewModel GetElement(int id);
        void AddElement(JewelBindingModel model);
        void UpdElement(JewelBindingModel model);
        void DelElement(int id);
    }
}
