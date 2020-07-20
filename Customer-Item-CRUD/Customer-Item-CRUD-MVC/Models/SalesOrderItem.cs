using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Models
{
    public class SalesOrderItem
    {
        public SalesOrder salesOrderViewModel { get; set; }
        public List<Item> ItemList { get; set; }
    }
}
