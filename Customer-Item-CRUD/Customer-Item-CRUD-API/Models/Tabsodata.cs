using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Item_CRUD_API.Models
{
    public partial class Tabsodata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Sodataid { get; set; }
        public decimal Sordid { get; set; }
        public decimal Itemid { get; set; }
        public decimal Itemrate { get; set; }
        public string Dataexst { get; set; }

        public virtual Tabitem Item { get; set; }
        public virtual Tabsorder Sord { get; set; }
    }
}
