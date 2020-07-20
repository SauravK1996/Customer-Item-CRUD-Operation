using Customer_Item_CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API.Dtos
{
    public class TabsorderDto
    {
        public TabsorderDto()
        {
            Tabsodatas = new HashSet<Tabsodata>();
        }

        public decimal Sordid { get; set; }
        public DateTime Sorddate { get; set; }
        public decimal Custid { get; set; }
        public decimal Sordamnt { get; set; }
        public string Dataexst { get; set; }

        public virtual Tabcust Cust { get; set; }
        public virtual ICollection<Tabsodata> Tabsodatas { get; set; }
    }
}
