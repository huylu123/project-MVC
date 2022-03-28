using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_03.Models;

namespace lab_03.Controllers
{
    public class CartController : Controller
    {
        projectEntities1 ctx = new projectEntities1();
        // GET: Cart
 
        public ActionResult Index()
        {
            ViewBag.yourSessionId = HttpContext.Session.SessionID;
            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();
            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }
            float total = 0;

            foreach (ItemCart it in cart)
            {

                total += it.LineTotal;
            }

            ViewBag.Total = total;
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();
            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }

            string ID = Request.Form["ID"];

            movie movie = ctx.movies.Where(t => t.ID == ID).SingleOrDefault();
            int qty = Convert.ToInt32(Request.Form["txtQuantity"]);
            
            ItemCart item = new ItemCart()
            {
                movie = movie,
                Quantity = qty,
                LineTotal = (float)(qty * movie.price),
            };
            cart.Add(item);

            HttpContext.Session["yourcart"] = cart;



            return RedirectToAction("Index");
        }
      
        public ActionResult Top2movie()
        {

            List<movie> movies = ctx.movies.ToList();

            List<movie> top2movies = ctx.movies.OrderBy(x => x.price).Take(2).ToList();
            ViewBag.top2movie = top2movies;

            //passing data (model) to view
            return View(movies);
        }
      
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order order = new Order();
                order.OderDate = DateTime.Now;
               // order.CodeCus = (form["CodeCus"]);
                ctx.Orders.Add(order);
                foreach (var item in cart.Items)
                {
                    ticket ticket = new ticket();
                    ticket.ID = order.IDOrder;
                    ticket.IDMovie = item.movie.ID;
                    ticket.price = item.movie.price;
                    ctx.tickets.Add(ticket);
                }
                ctx.SaveChanges();
                return RedirectToAction("Success","Cart");
            }
            catch
            {
                return Content("error");
            }
        }
    }
}