using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
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
    }
}
