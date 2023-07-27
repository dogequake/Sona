using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sona.Models;
using Sona.ViewModels;

namespace Sona.Controllers
{
    public class OrdersController : Controller
    {
        private readonly SonaDbContext _context;

        public OrdersController(SonaDbContext context)
        {
            _context = context;
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            List<Order> listOrder = await _context.Orders.ToListAsync();
            List<Room> listRoom = await _context.Rooms.ToListAsync();
            List<Testimonial> listTestimonial = await _context.Testimonials.ToListAsync();
            List<News> listNews = await _context.News.ToListAsync();

            DataViewModel newView = new DataViewModel(listOrder, listRoom, listTestimonial, listNews);

            return View(newView);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCheckin,DateCheckout,CountGuest,CountRoom,NameClient,PhonenumClient")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return Redirect("../Home/Index");
            }
            return View(order);
        }
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
