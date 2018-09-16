using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace Restauranter.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;
        public HomeController(YourContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Review newReview)
        {
            if (ModelState.IsValid){
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else {
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.Reviews.ToList();
            ViewBag.reviews = AllReviews.OrderByDescending(a => a.Date);
            return View();
        }



        // [HttpGet]
        // [Route("")]
        // public IActionResult AllAdults()
        // {
        //     List<Review> ReturnedValues = _context.Reviews.Where(user => user.Age > 17).ToList();
        //     ViewBag.users = ReturnedValues;
        //     return View("Index");
        // }

    }
}

