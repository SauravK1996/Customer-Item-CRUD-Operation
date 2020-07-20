using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Item_CRUD_MVC.Models;
using Customer_Item_CRUD_MVC.Repository.IRepository;
using Customer_Item_CRUD_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Item_CRUD_MVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IItemRepository _itemRepository;
        public ItemsController(ISalesRepository salesRepository, IItemRepository itemRepository)
        {
            _salesRepository = salesRepository;
            _itemRepository = itemRepository;
        }
        public async Task<IActionResult> Index(int id)
        {
            var salesOrderItem = await _itemRepository.GetAsync(SD.SalesAPIPath, id);
            return View(salesOrderItem);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItemRate(UpdateItemRateViewModel updateItemRate)
        {
            var itemId = int.Parse(updateItemRate.ItemId);

            await _itemRepository.UpdateAsync(SD.SalesAPIPath + itemId, updateItemRate);//, HttpContext.Session.GetString("JWToken"));

            return RedirectToAction("Index","SalesOrder");
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteSalesItem(int itemId, int salesOrderId)
        {
            //var salesOrderId = 
            //, HttpContext.Session.GetString("JWToken"));

            //return RedirectToAction("Index", "SalesOrder");

            var status = await _itemRepository.DeleteAsync(SD.SalesAPIPath + itemId + "/" + salesOrderId);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete not Successful" });
        }

    }
}