using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CovidMovieMadness.DAL;
using CovidMovieMadness.Models;
using CovidMovieMadness.ViewModels;

namespace CovidMovieMadness.Controllers
{
    public class MovieController : Controller
    {
        private MovieMadnessContext db = new MovieMadnessContext();

        // GET: Movie
        public ActionResult Index(int? id, int? postID)
        {
            var viewModel = new MovieIndexData();
            viewModel.Movies = db.Movies;
            Movie movie = db.Movies.Find(id);

            if (id != null)
            {
                ViewBag.MovieID = id.Value;
                viewModel.Posts = viewModel.Movies.Where(m => m.MovieID == id.Value).Single().Posts;
            }

            if (postID != null)
            {
                ViewBag.PostID = postID.Value;
                viewModel.Comments = viewModel.Posts.Where(x => x.PostID == postID).Single().Comments;
            }

            return View(viewModel);
            //return View(db.Movies.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Genre,Name,Year,PostID")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(movie);
        }

        public ActionResult CreatePost(int? id)
        {
            return RedirectToAction("Create", "Post", new { id = id });
        }

        public ActionResult DeletePost(int? id)
        {
            return RedirectToAction("Delete", "Post", new { id = id });
        }

        public ActionResult EditPost(int? id, int id2)
        {
            return RedirectToAction("Edit", "Post", new { id = id , id2 = id2});
        }
        public ActionResult CreateComment(int? id, int id2)
        {
            return RedirectToAction("Create", "Comment", new { id = id, id2 = id2});
        }

        public ActionResult DeleteComment(int? id, int id2, int PostID)
        {
            return RedirectToAction("Delete", "Comment", new { id = id , id2 = id2, PostID = PostID});
        }

        public ActionResult EditComment(int? id, int id2, int PostID)
        {
            return RedirectToAction("Edit", "Comment", new { id = id, id2 = id2, PostID = PostID });
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Genre,Name,Year,PostID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
