using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Customer_Item_CRUD_API.Dtos;
using Customer_Item_CRUD_API.Models;
using Customer_Item_CRUD_API.Repository.IRepository;
using Customer_Item_CRUD_API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Item_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _repository;
        private readonly IMapper _mapper;
        public SalesController(ISalesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET: api/Sales -- Get the list of records from the Tabsorder
        [HttpGet]
        public IActionResult GetSalesOrderList()
        {
            var salesOrderList = _repository.GetSalesOrderList();
            if (salesOrderList == null)
                return NotFound();

            return Ok(salesOrderList);

        }

        //GET: api/Sales/1 -- Get the entire details of the customer along with list of items, price etc.
        [HttpGet("{salesOrderId}")]
        public IActionResult GetSalesItemOrder(int salesOrderId)
        {
            var salesItemList = _repository.GetSalesItemOrder(salesOrderId);
            if (salesItemList.ItemList.Count() == 0 || salesItemList.salesOrderViewModel == null)
                return NotFound();

            return Ok(salesItemList);
        }

        //PATCH: api/Sales -- delete record from the Tabsorder
        [HttpPatch("{salesOrderId}")]
        public IActionResult DeleteSalesOrder(int salesOrderId)
        {
            if (!_repository.SalesOrderExists(salesOrderId))
            {
                return NotFound();
            }

            if (!_repository.DeleteSalesOrder(salesOrderId))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting the record.");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        //Post:api/Sales -- create a fresh sales order record
        [HttpPost]
        public IActionResult CreateOrder(CreateSalesOrderViewModel createSalesOrder)//Tabsorder salesOrder, Tabsodata salesOrderItem)
        {
            if (createSalesOrder == null)
            {
                return BadRequest(ModelState);
            }

            //convert custId from string to decimal
            decimal custiId = decimal.Parse(createSalesOrder.Custid);

            //convert itemId from string to decimal
            List<decimal> itemIdList = new List<decimal>();
            foreach (var itemId in createSalesOrder.ItemIdList)
            {
                itemIdList.Add(decimal.Parse(itemId));
            }

            //creating a list of prices of item
            List<decimal> itemRateList = new List<decimal>();
            foreach (var itemId in itemIdList)
            {
                itemRateList.Add(_repository.ItemPrice(itemId));
            }

            //total amount of the selected items
            decimal totalItemRate = itemRateList.Sum();

            Tabsorder tabsorder = new Tabsorder
            {
                Sorddate = DateTime.UtcNow.Date,
                Custid = custiId,
                Sordamnt = totalItemRate,
                Dataexst = "ext"
            };

            var currentInsertedSalesOrderId = _repository.CreateSalesOrder(tabsorder);

            List<Tabsodata> tabsodatas = new List<Tabsodata>();

            foreach (var salesorderItemData in itemIdList)
            {
                _repository.CreateSalesOrderItemList(
                    new Tabsodata
                    {
                        Sordid = currentInsertedSalesOrderId,
                        Itemid = salesorderItemData,
                        Itemrate = _repository.ItemPrice(salesorderItemData),
                        Dataexst = "ext"
                    });
            }

            return NoContent();
        }

        //DELETE: api/Sales/2/5 --update Tabsodata as well as Taborder
        [HttpDelete("{itemId}/{salesOrderId}")]
        public IActionResult DeleteSalesItem(decimal itemId, decimal salesOrderId)
        {
            //var salesId = decimal.Parse(salesOrderId);
            if (!_repository.DeleteSalesItem(itemId, salesOrderId))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting the sales item data.");
                return StatusCode(500, ModelState);
            }

            //get the price of deleted item to update the total amount of the sales order table
            var priceOfDeletedItem = _repository.ItemPrice(itemId);

            //get the sales order to update the total order amount for the deleted item
            var salesOrder = _repository.GetSalesOrder(salesOrderId);
            salesOrder.Sordamnt = salesOrder.Sordamnt - priceOfDeletedItem;


            //update the total amount in the database
            if (!_repository.UpdateSalesOrder(salesOrder))
            {
                ModelState.AddModelError("", $"Something went wrong while updating the sales order data.");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        //PUT: api/Sales/2/5 --update item price from the Tabsodata as well as Taborder
        [HttpPut("{itemId}/{salesOrderId}")]
        public IActionResult UpdateSalesItem(decimal itemId, decimal salesOrderId, [FromBody] ItemDto itemDto)
        {
            var itemRate = decimal.Parse(itemDto.ItemRate);

            var salesOrderItemData = _repository.GetSalesOrderItem(itemId, salesOrderId);

            //old price of the item taken from the database
            var oldPriceOfItem = salesOrderItemData.Itemrate;

            //update the item price with new item rate
            salesOrderItemData.Itemrate = itemRate;

            //update the amount of item in the repository
            if (!_repository.UpdateSalesItem(salesOrderItemData))
            {
                ModelState.AddModelError("", $"Something went wrong while updating the sales order with item data.");
                return StatusCode(500, ModelState);
            }

            var salesOrder = _repository.GetSalesOrder(salesOrderId);
            salesOrder.Sordamnt = salesOrder.Sordamnt - oldPriceOfItem + itemRate;


            //update the total amount in the database
            if (!_repository.UpdateSalesOrder(salesOrder))
            {
                ModelState.AddModelError("", $"Something went wrong while updating the sales order data.");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}