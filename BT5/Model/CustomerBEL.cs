using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5.Model
{
    internal class CustomerBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AreaBEL Area { get; set; }
        public string AreaName {
            get 
            {
                return Area.Name;
            }
        }
        List<CustomerBEL> lstCus=new List<CustomerBEL>();

    }
}
