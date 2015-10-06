using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /Movies/
        // The Index method searches the database for the searchString parameter which is a movie name
        // If there is no search given then the index displays all the titles with the user's username in
        // the userId field.
        // TODO: The search string needs to be updated so that it only returns that user's items.  Currently it does not check
        // for userId
        public ActionResult Index(string searchString)
        {

            var movies = from m in db.Movies select m;
        
            if(!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));

            }
            if (User.Identity.Name != "")
            {
                movies = movies.Where(s => s.userId == User.Identity.Name);
            }
            else
            {
                movies = movies.Where(s => s.userId == "1");
            }
            ViewBag.Title = User.Identity.Name;
            return View(movies);
        }

        //
        // GET: /Movies/Details/5
        // This is the method that's called when the user clicks on a title from index in order to 
        // bring up a more detailed account of the entry.
        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /Movies/Create
        // This method gets called when the user clickes on the "add Movie" button in index.
        // TODO: This method has been superseded by the Create method below and should not be called
        // Test that it doesn't get called and then delete it.
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movies/Create
        // This method gets called when the user clickes on the "add Movie" button in index.
        // TODO:  Check the security of the create method against code injections.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            movie.userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /Movies/Edit/5
        // Allows users to edit movies that they have already created
        // TODO:  This method is depreciated and should be deleted.
        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movies/Edit/5
        // Allows users to edit movies that they have already created
        // TODO:  Test that users cannot find a way to edit movies that don't belong to them.
        // TODO:  Test the security of the edit page.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Movies/Delete/5
        // TODO:  This method is depreciated and should be deleted.
        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movies/Delete/5
        // Allows users to delete movies that they have already created
        // TODO:  Test that users cannot find a way to delete movies that don't belong to them.
        // TODO:  Test the security of the delete page.
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
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}