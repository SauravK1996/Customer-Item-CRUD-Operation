using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Item_CRUD_API.Models
{
    public partial class Tabsorder
    {
        public Tabsorder()
        {
            Tabsodatas = new HashSet<Tabsodata>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Sordid { get; set; }
        public DateTime Sorddate { get; set; }
        public decimal Custid { get; set; }
        public decimal Sordamnt { get; set; }
        public string Dataexst { get; set; }

        public virtual Tabcust Cust { get; set; }
        public virtual ICollection<Tabsodata> Tabsodatas { get; set; }
    }
}
