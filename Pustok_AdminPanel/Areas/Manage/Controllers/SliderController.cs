using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Helpers;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController (AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            this._env = env;
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
            if (slider.ImageFile!=null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File format must be /png or /jpeg");
                   
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File Size is not correct");
                    
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required!");
            }
            if (!ModelState.IsValid)
                return View();

           

            slider.Image = FileManager.Save(_env.WebRootPath,"upload/sliders",slider.ImageFile);


            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
