using lifbi.bookers.logic;
using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lifbi.bookers.ui.asp.Controllers
{
    public class BookController : Controller
    {
        public BookController()
        {
            core = new Core();
        }
        private readonly Core core;

        // GET: Book
        public ActionResult Index()
        {
            var books = core.Repository.GetAll<Book>();
            var count = books.Count();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = core.Repository.GetByID<Book>(id);

            //Variante 1: Query im Speicher
            //int allBooks = core.Repository.GetAll<Stock>().Where(s => s.Book.ID == id).Sum(b => b.Amount);

            //Variante 2: Query über EF
            int allBooks = core.Repository.Query<Stock>().Where(s => s.Book.ID == id).Sum(b => b.Amount);
            var model = (book, allBooks);
            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                core.Repository.Add<Book>(book);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetByID<Book>(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book b)
        {
            try
            {
                // TODO: Add update logic here
                core.Repository.Add<Book>(b);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = core.Repository.GetByID<Book>(id);
            core.Repository.Delete<Book>(book);
            core.Repository.Save();

            return RedirectToAction("Index");
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book b)
        {
            try
            {
                // TODO: Add delete logic here

                var book = core.Repository.GetByID<Book>(id);
                core.Repository.Delete<Book>(book);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
