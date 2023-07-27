using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sona.Models;
using Sona.ViewModels;
using System.Diagnostics;

namespace Sona.Controllers
{
    public class HomeController : Controller
    {
        private readonly SonaDbContext _context;

        public HomeController(SonaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Order> listOrder = await _context.Orders.ToListAsync();
            List<Room> listRoom = await _context.Rooms.ToListAsync();
            List<Testimonial> listTestimonial = await _context.Testimonials.ToListAsync();
            List<News> listNews  = await _context.News.Include(u => u.Category).ToListAsync();


            DataViewModel newView = new DataViewModel(listOrder, listRoom, listTestimonial, listNews);

            return View(newView);
        }

        public async Task<IActionResult> Rooms()
        {
            List<Room> listRoom = await _context.Rooms.ToListAsync();

            return View(listRoom);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public async Task<IActionResult> News(int? page = 1)
        {
            if (page == null)
            {
                var sonaDbContext = _context.News;
                return View(await sonaDbContext.ToListAsync());
            }
            else 
            {
                int count = 9;
                var sonaDbContext = _context.News;
                int countNews = await sonaDbContext.CountAsync();
                int countPage = Convert.ToInt32(Math.Ceiling(countNews * 1.0 / count));

                List<News> listNews = await sonaDbContext
                    .Skip((Convert.ToInt32(page) - 1) * count)
                    .Take(count)
                    .ToListAsync();


                PaginationViewModel viewModel = new PaginationViewModel(countPage, listNews);
                return View(viewModel);
            }
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}