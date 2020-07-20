using Customer_Item_CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Repository.IRepository
{
    public interface IItemRepository : IRepository<SalesOrderItem>
    {
        
    }
}
