using Customer_Item_CRUD_API.Models;
using Customer_Item_CRUD_API.Repository.IRepository;
using Customer_Item_CRUD_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API.Repository
{
    
    public class SalesRepository : ISalesRepository
    {
        private readonly CustomerItemDBContext _db;
        public SalesRepository(CustomerItemDBContext db)
        {
            _db = db;
        }

        public decimal CreateSalesOrder(Tabsorder salesOrder)
        {
            _db.Tabsorders.Add(salesOrder);
            bool value = Save();
            return (from record in _db.Tabsorders orderby record.Sordid select record.Sordid).Last();

        }
        public void CreateSalesOrderItemList(Tabsodata tabsodata)
        {
            _db.Tabsodatas.Add(tabsodata);
            bool value = Save();
        }

        public bool DeleteSalesOrder(int salesOrderId)
        {
            Tabsorder salesOrder = _db.Tabsorders.FirstOrDefault(i => i.Sordid == salesOrderId);
            salesOrder.Dataexst = "del";

            List<Tabsodata> salesOrderWithItemList = _db.Tabsodatas.Where(i => i.Sordid == salesOrderId).ToList();

            foreach(Tabsodata tabsodata in salesOrderWithItemList)
            {
                tabsodata.Dataexst = "del";
            }
            
            return Save();
        }

        public ICollection<SalesOrderViewModel> GetSalesOrderList()
        {
            var salesList = (from sale in _db.Tabsorders
                             where sale.Dataexst == "ext"
                             select new SalesOrderViewModel
                             {
                                 Sordid = sale.Sordid,
                                 Customer = sale.Cust.Custname,
                                 Sorddate = sale.Sorddate.ToString("dd/MM/yyyy"),
                                 Sordamnt = sale.Sordamnt
                             }).ToList();
            return salesList;
        }

        public SalesOrderItemViewModel GetSalesItemOrder(decimal salesOrderId)
        {
            var saleOrderItemViewModel = new SalesOrderItemViewModel 
            {
                ItemList = (from item in _db.Tabsodatas
                            where item.Dataexst == "ext" & item.Sordid == salesOrderId
                            select new ItemViewModel
                            {
                                Itemid = item.Itemid,
                                Itemname = item.Item.Itemname,
                                Itemrate = item.Itemrate
                            }).ToList(),

                salesOrderViewModel = (from sale in _db.Tabsorders
                                       where sale.Dataexst == "ext" & sale.Sordid == salesOrderId
                                       select new SalesOrderViewModel
                                       {
                                           Sordid = sale.Sordid,
                                           Customer = sale.Cust.Custname,
                                           Sorddate = sale.Sorddate.ToString("dd/MM/yyyy"),
                                           Sordamnt = sale.Sordamnt
                                       }).FirstOrDefault()
        };

            return saleOrderItemViewModel;
        }
        public bool SalesOrderExists(int salesOrderId)
        {
            bool value = _db.Tabsorders.Any(c => c.Sordid == salesOrderId);
            return value;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public decimal ItemPrice(decimal itemId)
        {
            return _db.Tabitems.Where(i => i.Itemid == itemId).Select(r => r.Itemrate).FirstOrDefault();
        }

        public bool DeleteSalesItem(decimal itemId, decimal salesOrderId)
        {
            var value = _db.Tabsodatas.Where(i => i.Itemid == itemId).Where(s=>s.Sordid == salesOrderId).FirstOrDefault();
            value.Dataexst = "del";
            return Save();
        }

        public bool UpdateSalesItem(Tabsodata tabsodata)
        {
            _db.Tabsodatas.Update(tabsodata);
            return Save();
        }

        public Tabsorder GetSalesOrder(decimal salesOrderId)
        {
            return _db.Tabsorders.FirstOrDefault(i => i.Sordid == salesOrderId);
        }

        public bool UpdateSalesOrder(Tabsorder tabsorder)
        {
            _db.Tabsorders.Update(tabsorder);
            return Save();
        }

        public Tabsodata GetSalesOrderItem(decimal itemId,decimal salesOrderId)
        {
            return _db.Tabsodatas.Where(s => s.Sordid == salesOrderId).Where(i => i.Itemid == itemId).FirstOrDefault();
        }
    }
}
