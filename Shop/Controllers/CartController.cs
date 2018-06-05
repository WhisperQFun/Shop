using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Context;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class CartController : Controller
    {

        private shopContext _context;

        public CartController(shopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Cart cart_order = null;
            string cart_json = "";
            float sum = 0;
            CartModel model = new CartModel();
            if (Request.Cookies.ContainsKey("cart"))
            {
                cart_json = Request.Cookies["cart"];
                cart_order = JsonConvert.DeserializeObject<Cart>(cart_json);
            }
            foreach (Item value in cart_order.items)
            {
                sum = value.cost + sum;
            }
            model.cart = cart_order;
            model.total_cost =Convert.ToInt32(sum);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Order()
        {
            
            return View();
        }

        //[Authorize(Roles = "admin, user")]
        [Authorize]
        public async Task<IActionResult> Order(OrderModel model)
        {
            User user = _context.User.FirstOrDefault(u => u.Login == User.Identity.Name);
            Order order = null;
            Cart cart_order = null;
            string cart_json = "";
            float sum = 0;

            if (Request.Cookies.ContainsKey("cart"))
            {
                cart_json = Request.Cookies["cart"];
                cart_order = JsonConvert.DeserializeObject<Cart>(cart_json);
            }
            foreach (Item value in cart_order.items)
            {
                sum = value.cost + sum;
            }
            order = new Order();
            order.items = cart_json;
            order.timestamp = DateTime.Now.ToUniversalTime().ToString();
            order.description = model.description;
            order.cost = sum;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            order = _context.Orders.FirstOrDefault(u => u.user_id == user.UserId);
            return RedirectToAction("Shop", "Index");
        }
    }
}
