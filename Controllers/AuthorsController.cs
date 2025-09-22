using EF_core_empty_controler__Day_3_.Models;
using EF_core_empty_controler__Day_3_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;
using System.Runtime.InteropServices;

namespace EF_core_empty_controler__Day_3_.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly AuthorRepository _repo;

        public AuthorsController(AuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Author> lstAuthor = await _repo.GetAll();
            return View(lstAuthor);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
 ;

            await _repo.CreateAsync(author);
            return RedirectToAction(nameof(Index));
        }


        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
           var auth=await _repo.GetByIdAsync(id);
            return View(auth);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Author author)
        {
     
            await _repo.UpdateAsync(author);
            return RedirectToAction(nameof(Index)); ;
        }

        //Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var details = await _repo.GetByIdAsync(id);
            return View(details);
        }

        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _repo.GetByIdAsync(id));
            
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Deletes(int id)
        {

            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        // DELETE: api/author/{id}



        //private readonly bookauthorContext _context;
        //public AuthorsController(bookauthorContext context)
        //{
        //    _context = context;
        //}
        //public IActionResult Index()
        //{
        //    IEnumerable<Author> listauthors = _context.Authors.Include(a => a.Books).ToList();
        //    return View(listauthors);
        //}

        ////Details
        //[HttpGet("Authors/Details/{authid}")]
        //public IActionResult Details(int Authid)
        //{

        //    var Auth = _context.Authors.SingleOrDefault(b => b.authid == Authid) ?? throw new KeyNotFoundException("Authorid not found");
        //    return View(Auth);
        //}

        ////create
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult Create(Author newauthor)
        //{
        //    _context.Authors.Add(newauthor);    //to add the new value
        //    _context.SaveChanges();   // it will help to save the change
        //    return RedirectToAction("Index");
        //}


        ////edit
        //[HttpGet]
        //public IActionResult edit(int id)
        //{
        //    var Auth = _context.Authors.FirstOrDefault(b => b.authid == id) ?? throw new KeyNotFoundException("Authorid not found");
        //    return View(Auth);

        //}

        //[HttpPost]
        //public IActionResult edit(int id, Author newauth)
        //{
        //    Author currauthor = _context.Authors.FirstOrDefault(a => a.authid == id);
        //    currauthor.authname = newauth.authname;
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        ////delete
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var Auth = _context.Authors.FirstOrDefault(b => b.authid == id) ?? throw new KeyNotFoundException("Authorid not found");
        //    return View(Auth);
        //}

        //[HttpPost, ActionName("Delete")]

        //public IActionResult Deleteconfirmed(int id)
        //{
        //    var Auth = _context.Authors.FirstOrDefault(b => b.authid == id) ?? throw new KeyNotFoundException("Authorid not found");
        //    _context.Authors.Remove(Auth);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}