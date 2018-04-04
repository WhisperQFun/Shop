using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Context;
using Shop.Data;
using Shop.Models;

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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            return View();
        }

        public async Task<IActionResult> Add(AddItemModel model)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item {name = model.name, description = model.description,type_item = model.type_item, is_avalible = model.is_avalible,cost = model.cost,image = model.image };
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
                
            }
            return View(model);
        }
    }
}