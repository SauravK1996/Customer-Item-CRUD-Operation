using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API.ViewModel
{
    public class CreateSalesOrderViewModel
    {
        public string Custid { get; set; }
        public List<string> ItemIdList { get; set; }
    }
}
