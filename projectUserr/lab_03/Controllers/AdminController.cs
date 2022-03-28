using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_03.Models;

namespace lab_03.Controllers
{
    public class AdminController : Controller
    {
        projectEntities1 ctx = new projectEntities1();
        // GET: Admin
        public ActionResult AddBook()
        {
            return View();
        }
        public ActionResult Products()
        {
            List<movie> movie = ctx.movies.ToList();
            return View(movie);
        }

        public ActionResult ProductDetails(string id)
        {
            movie movie = ctx.movies.Where(t=>t.ID == id).SingleOrDefault();
         
            ViewBag.productId = id;

            //passsin data / model to view
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}