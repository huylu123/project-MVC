using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_03.Models;

namespace lab_03.Controllers
{
    public class HomeController : Controller
    {
        projectEntities1 ctx = new projectEntities1();

        public ActionResult Index()
        {

            List<movie> movies = ctx.movies.ToList();

            List<movie> top5movies = ctx.movies.OrderBy(x => x.price ).Take(5).ToList();
            ViewBag.top5movie = top5movies;

            //passing data (model) to view
            return View(movies);
        }

        public ActionResult ListMovie()
        {

            List<movie> movies = ctx.movies.ToList();

            //passing data (model) to view
            return View(movies);
        }
        public ActionResult ProductDetails(string id)
        {
            //movie movie = ctx.movies.Where(t => t.ID == id).SingleOrDefault();
            movie movie = ctx.movies.Find(id);
            ViewBag.productId = id;

            List<movie> movies = ctx.movies.ToList();

            List<movie> top3movies = ctx.movies.OrderBy(x => x.price).Take(3).ToList();
            ViewBag.top3movie = top3movies;

            //passsin data / model to view
            return View(movie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}