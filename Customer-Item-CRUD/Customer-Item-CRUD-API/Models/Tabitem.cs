using System;
using System.Collections.Generic;

namespace Customer_Item_CRUD_API.Models
{
    public partial class Tabitem
    {
        public Tabitem()
        {
            Tabsodatas = new HashSet<Tabsodata>();
        }

        public decimal Itemid { get; set; }
        public string Itemname { get; set; }
        public decimal Itemrate { get; set; }

        public virtual ICollection<Tabsodata> Tabsodatas { get; set; }
    }
}
