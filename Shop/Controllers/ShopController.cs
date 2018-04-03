using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Context;
using Shop.Data;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        private shopContext _context;

        public ShopController(shopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
			var items = _context.Items.ToList();
            return View(items);
        }

        public async Task<IActionResult> Add()
        {
            
            return View();
        }
    }
}