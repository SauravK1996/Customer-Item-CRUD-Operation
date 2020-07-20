using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Models
{
    public class ItemNameAndPrice
    {
        public string CustId { get; set; }
        public List<string> ItemIdList { get; set; }
    }
}
