using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API.ViewModel
{
    public class SalesOrderItemViewModel
    {
        public SalesOrderViewModel salesOrderViewModel { get; set; }
        public List<ItemViewModel> ItemList { get; set; }
    }
}
