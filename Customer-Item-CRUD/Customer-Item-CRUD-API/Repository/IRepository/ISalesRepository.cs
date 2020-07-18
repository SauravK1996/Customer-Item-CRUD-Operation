using Customer_Item_CRUD_API.Models;
using Customer_Item_CRUD_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API.Repository.IRepository
{
    public interface ISalesRepository
    {
        ICollection<SalesOrderViewModel> GetSalesOrderList();
        SalesOrderItemViewModel GetSalesItemOrder(decimal salesOrderId);
        Tabsorder GetSalesOrder(decimal salesOrderId);
        Tabsodata GetSalesOrderItem(decimal ItemId,decimal salesOrderId);
        bool SalesOrderExists(int salesOrderId);
        decimal CreateSalesOrder(Tabsorder salesOrder);
        void CreateSalesOrderItemList(Tabsodata tabsodata);
        bool DeleteSalesOrder(int salesOrderId);
        bool UpdateSalesOrder(Tabsorder tabsorder);
        bool DeleteSalesItem(decimal itemId,decimal salesOrderId);
        bool UpdateSalesItem(Tabsodata tabsodata);
        decimal ItemPrice(decimal itemId);
        bool Save();
    }
}
