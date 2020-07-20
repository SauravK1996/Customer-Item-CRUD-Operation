using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Item_CRUD_MVC.Models;
using Customer_Item_CRUD_MVC.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Item_CRUD_MVC.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesRepository _repository;
        public SalesOrderController(ISalesRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(new SalesOrder());
        }

        public async Task<ActionResult> GetAllSalesOrder()
        {
            var data = await _repository.GetAllAsync(SD.SalesAPIPath);
            return Json(new { data});
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(ItemNameAndPrice modal)
        {

            if (modal != null)
            {
                await _repository.CreateAsync(SD.SalesAPIPath, modal);//, HttpContext.Session.GetString("JWToken"));
            }

            return RedirectToAction("Index");
           
            //return Json(modal);
        }
        
        [HttpPatch]
        public async Task<ActionResult> DeleteSalesOrder(decimal id)
        {

            var status = await _repository.DeleteSalesOrderAsync(SD.SalesAPIPath, id);//, HttpContext.Session.GetString("JWToken"));
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete not Successful" });
        }
    }
}