using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.DataLayer;
using Library.Domain.Interfaces.Services;
using Library.Domain.Services;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private IBookService _bookService;

        public HomeController()
        {
            _bookService = new BookService(new BookStorage());
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            
            var books = _bookService.GetAllBooks();
            _bookService.CreateBook(new Book {Title = "Andrew"});

            return View(new HomeIndexModel
            {
                Books = books.ToList(),
            });
        }

        [Route("")]
        [HttpPost]
        public ActionResult CreateBook(HomeIndexModel model)
        {
            var id = _bookService.CreateBook(new Book
            {
                Title = model.Title
            });

            return Redirect("/");
        }
    }
}
