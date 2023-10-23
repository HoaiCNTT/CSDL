using BT5.DAL;
using BT5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5.BAL
{
    internal class AreaBAL
    {
        AreaDAL dal = new AreaDAL();
        public List<AreaBEL> ReadAreaList()
        {
            List<AreaBEL> lstArea = dal.ReadAreaList();
            return lstArea;
        }
    }
}
