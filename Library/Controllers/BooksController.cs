using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Domain.DataTransferClasses.Requests;
using Library.Domain.DataTransferClasses.Responses;
using Library.Domain.Interfaces.Services;

namespace Library.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;
        private readonly ITranslator _translator;

        public BooksController(
            IBookService bookService,
            ITranslator translator)
        {
            _bookService = bookService;
            _translator = translator;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var books = _bookService.GetAllBooks();
            var response = books
                .Select(book => _translator.Translate(book));

            var responseBody = new GetAllBooksResponseBody
            {
                Books = response
            };
            return Ok(responseBody);
        }

        [Route("{bookId}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]int bookId)
        {
            var book = _bookService.GetBook(bookId);
            if (book == null)
            {
                return NotFound();
            }

            var response = _translator.TranslateToDtc(book);

            return Ok(response);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateBookRequestBody request)
        {
            int bookId;
            try
            {
                var book = _translator.TranslateToService(request);
                bookId = _bookService.CreateBook(book);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return Created($"/api/books/{bookId}", new CreateBookResponseBody
            {
                BookId = bookId
            });
        }

        [Route("{bookId}")]
        [HttpPut]
        public IHttpActionResult Put([FromUri]int bookId, [FromBody]string value)
        {
            return Ok(new {});
        }

        [Route("{bookId}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _bookService.RemoveBook(id);
        }
    }
}
