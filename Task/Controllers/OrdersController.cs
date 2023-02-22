using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task.Models;
using Task.Models.db;
using Task.ViewModels;

namespace Task.Controllers
{
    public class OrdersController : Controller
    {
        public OrdersController(TaskDbContext context) 
        {
            _Context = context;
        }

        public TaskDbContext _Context { get; }

        public IActionResult Main()
        {
            var ItemList = _Context.Items.Select(Item => new ItemViewModel
            {
                CreatedDate = Item.CreatedDate,
                Description = Item.Description,
                Id = Item.Id,
                Price = Item.Price,
                Title = Item.Title
            }).ToList();
            return View(ItemList);
        }
        [HttpPost]
        public IActionResult AddOrder(string modal)
            {
            try
            {
                OrderViewModal OrderViewModal = JsonConvert.DeserializeObject<OrderViewModal>(modal);
                var Items = OrderViewModal.Items.Split(',').Select<string, int>(int.Parse).ToList();
                var quantitys = OrderViewModal.quantity.Split(',').Select<string, int>(int.Parse).ToList();
                var iteration = 0;
                var Order = new Order
                {
                    CustomerName = OrderViewModal.CustomerName,
                    ItemCount = OrderViewModal.ItemCount,
                    TotalOrder = OrderViewModal.TotalOrder,
                    CreatineDate = DateTime.Now,
                };
                _Context.Orders.Add(Order);
                _Context.SaveChanges();
                foreach (var item in Items)
                {
                    _Context.Item_Orders.Add(new Item_Order { ItemId = item, OrderId = Order.Id, quantity = quantitys[iteration] });
                    iteration++;
                }
                _Context.SaveChanges();
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
           
        }
    }
}
