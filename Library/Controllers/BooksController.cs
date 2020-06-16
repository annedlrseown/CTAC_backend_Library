using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Domain.DataTransferClasses;
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
        public GetAllBooksResponseBody Get()
        {
            var books = _bookService.GetAllBooks();
            var response = books
                .Select(book => _translator.Translate(book));

            return new GetAllBooksResponseBody
            {
                Books = response
            };
        }

        [Route("{bookId}")]
        [HttpGet]
        public GetBookResponseBody Get([FromUri]int bookId)
        {
            var book = _bookService.GetBook(bookId);
            var response = _translator.TranslateToDtc(book);

            return response;
        }

        [Route("")]
        [HttpPost]
        public CreateBookResponseBody Post([FromBody]CreateBookRequestBody request)
        {
            var book = _translator.TranslateToService(request);
            var bookId = _bookService.CreateBook(book);

            return new CreateBookResponseBody
            {
                BookId = bookId
            };
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
