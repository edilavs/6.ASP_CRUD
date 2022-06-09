using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private AppDbContext _context;
        
        public SliderController (AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Sliders.ToList();
            return View(model);
        }
         public IActionResult Create()
         {
             return View();
         }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {

            if (!ModelState.IsValid)
                return View();

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return View();
        }
    }
}
