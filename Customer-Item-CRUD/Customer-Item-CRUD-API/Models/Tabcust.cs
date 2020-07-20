using System;
using System.Collections.Generic;

namespace Customer_Item_CRUD_API.Models
{
    public partial class Tabcust
    {
        public Tabcust()
        {
            Tabsorders = new HashSet<Tabsorder>();
        }

        public decimal Custid { get; set; }
        public string Custname { get; set; }

        public virtual ICollection<Tabsorder> Tabsorders { get; set; }
    }
}
