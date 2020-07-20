using Customer_Item_CRUD_MVC.Models;
using Customer_Item_CRUD_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, decimal id);//, string token);
        Task<IEnumerable<T>> GetAllAsync(string url);//, string token);
        Task<bool> CreateAsync(string url, ItemNameAndPrice objToCreate);//, string token);
        Task<bool> UpdateAsync(string url, UpdateItemRateViewModel updateItemRate);//, string token);
        Task<bool> DeleteAsync(string url);//, string token);
        Task<bool> DeleteSalesOrderAsync(string url,decimal id);//, string token);
        //Task<CustomerItemList> CustomerItemList();
    }
}
