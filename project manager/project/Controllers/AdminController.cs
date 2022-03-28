using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;

namespace project.Controllers
{
    
    public class AdminController : Controller
    {
        projectEntities ctx = new projectEntities();
        // GET: Admin

     

        public ActionResult Products()
        {
            List<movie> movies = ctx.movies.ToList();
            return View(movies);
        }

        public ActionResult Customer()
        {
            List<customer> customers = ctx.customers.ToList();
            return View(customers);
        }

        public ActionResult productDetails(string id)
        {
            movie movie = ctx.movies.Where(t => t.ID == id).SingleOrDefault();

            address addr = ctx.addresses.Where(x => x.ID == movie.mIdAdress).SingleOrDefault();
            cinemar cine = ctx.cinemars.Where(c => c.ID == movie.mIdCinemar).SingleOrDefault();

            movie.address = addr;
            movie.cinemar = cine;
            ViewBag.productId = id;

            //passsin data / model to view
            return View(movie);
        }

        public ActionResult CustomerDetails(int id)
        {
            customer customer = ctx.customers.Where(t => t.ID == id).SingleOrDefault();
            ViewBag.customerID = id;

            //passsin data / model to view
            return View(customer);
        }
        public ActionResult ProductDelete(string id)
        {

            movie movie = ctx.movies.Where(t => t.ID == id).SingleOrDefault();
            ctx.movies.Remove(movie);
            ctx.SaveChanges();

            //passsin data / model to view
            return RedirectToAction("Products");
        }

        public ActionResult CustomertDelete(int id)
        {

            customer customer = ctx.customers.Where(t => t.ID == id).SingleOrDefault();
           // ctx.movies.Remove(customer);
            ctx.SaveChanges();

            //passsin data / model to view
            return RedirectToAction("Products");
        }

        [HttpPost]
        public ActionResult SaveProduct(movie toy)
        {
            ctx.movies.Add(toy);
            ctx.SaveChanges();
            return RedirectToAction("Products");
        }
        public ActionResult AddProduct()
        {
            //Category cate = new Category();
            movie movie = new movie();
            List<address> addresses = ctx.addresses.ToList();
            ViewBag.addresses = addresses;
            List<cinemar> cinemars = ctx.cinemars.ToList();
            ViewBag.cinemars = cinemars;
            return View(movie);

        }

        [HttpGet]
        public ActionResult EditProduct(string id)
        {
            List<address> addresses = ctx.addresses.ToList();
            ViewBag.addresses = addresses;
            List<cinemar> cinemars = ctx.cinemars.ToList();
            ViewBag.cinemars = cinemars;

            movie movie = ctx.movies.Where(t => t.ID == id).SingleOrDefault();
            ViewBag.productId = id;

            //passsin data / model to view
            return View(movie);
        }
        [HttpPost]

        public ActionResult UpdateProduct(movie moive)
        {
            //search old entity
            movie oldmovie = ctx.movies.Where(t => t.ID == moive.ID).SingleOrDefault();

            // update
            oldmovie.releaseDate = moive.releaseDate;
            oldmovie.price = moive.price;
            oldmovie.des = moive.des;
            oldmovie.imgMovie = moive.imgMovie;   

            ctx.SaveChanges();

            return RedirectToAction("Products");
        }

    }
}