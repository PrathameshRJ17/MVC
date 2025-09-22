using EF_core_empty_controler__Day_3_.Models;
using EF_core_empty_controler__Day_3_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EF_core_empty_controler__Day_3_.Controllers
{
    public class BooksController : Controller
    {

        private readonly bookauthorContext _context;
        public BooksController(bookauthorContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> listbooks = _context.Books.Include(a => a.author).ToList();
            return View(listbooks);
        }


        [HttpGet("Books/Details/{bookid}")]
        public IActionResult Details(int bookid)
        {


            var book = _context.Books.SingleOrDefault(b => b.bookid == bookid);
            Console.WriteLine(book?.title);
            return View(book);
        }

        //create
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Authid = new SelectList(_context.Authors.ToList(), "authid", "authname");
            return View();

        }

        [HttpPost]
        public IActionResult Create(Book newbook)
        {
            ViewBag.Authid = new SelectList(_context.Authors.ToList(), "authid", "authname");
            _context.Books.Add(newbook);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        //edit
        [HttpGet]
        public IActionResult Edit(int bid)
        {
            var newbook = _context.Books.FirstOrDefault(b => b.bookid == bid);
            ViewData["authid"] = new SelectList(_context.Authors.ToList(), "authid", "authname");
            //var newbook = _context.Books.FirstOrDefault(b => b.bookid == bid) ;
            return View(newbook);

        }

        [HttpPost]
        public IActionResult Edit(int id, Book newbook)
        {

            _context.Books.Update(newbook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.bookid == id) ?? throw new KeyNotFoundException("Authorid not found");
            return View(book);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult Deleteconfirmed(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.bookid == id) ?? throw new KeyNotFoundException("Authorid not found");
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}