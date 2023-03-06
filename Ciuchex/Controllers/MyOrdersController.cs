using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ciuchex.Data;
using Ciuchex.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Ciuchex.Controllers
{
    [Authorize]
    public class MyOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders
                .Where(o => o.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .Include(o => o.IdentityUser)
                .Include(o => o.CartItems);


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

       
    }
}
