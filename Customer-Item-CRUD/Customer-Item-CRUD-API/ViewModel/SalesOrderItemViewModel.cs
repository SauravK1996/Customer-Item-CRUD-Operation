using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API.ViewModel
{
    public class SalesOrderItemViewModel
    {
        //public decimal Sordid { get; set; }
        //public string Sorddate { get; set; }
        //public string Customer { get; set; }
        //public decimal Sordamnt { get; set; }

        public SalesOrderViewModel salesOrderViewModel { get; set; }
        public List<ItemViewModel> ItemList { get; set; }
    }
}
