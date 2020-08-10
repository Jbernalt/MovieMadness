using CovidMovieMadness.DAL;
using CovidMovieMadness.Models;
using CovidMovieMadness.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidMovieMadness.Controllers
{
    public class HomeController : Controller
    {
        private MovieMadnessContext db = new MovieMadnessContext();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "postid_desc" : "";
            ViewBag.DateSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            List<Post> posts = db.Posts.Include("Movie").Include("Comments").OrderByDescending(p => p.PostID).ToList();
            switch (sortOrder)
            {
                case "postid_desc":
                    posts = db.Posts.OrderByDescending(p => p.PostID).ToList();
                    break;
                case "rating":
                    posts = db.Posts.OrderBy(p => p.Rating).ToList();
                    break;
                case "rating_desc":
                    posts = db.Posts.OrderByDescending(p => p.Rating).ToList();
                    break;
                default:
                    posts = db.Posts.OrderBy(p => p.PostID).ToList();
                    break;
            }
            return View(posts);
        }

        public ActionResult GetToComment(int? id, int PostID)
        {
            return RedirectToAction("Index", "Movie", new { id = id, PostID = PostID});
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