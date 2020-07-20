using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Models
{
    public class CustomerItemList
    {
        public ICollection<Customer> CustomersMyProperty { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
