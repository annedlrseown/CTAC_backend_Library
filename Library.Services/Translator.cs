using Library.Domain.DataTransferClasses;
using Library.Domain.DataTransferClasses.Requests;
using Library.Domain.DataTransferClasses.Responses;
using Library.Domain.Interfaces.Services;

namespace Library.Services
{
    public class Translator : ITranslator
    {
        public Book Translate(Domain.Services.Book book)
        {
            return new Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
                Pages = book.Pages,
                Genre = book.Genre,
                Isbn = book.Isbn,
                Price = book.Price,
                DatePurchased = book.DatePurchased,
                WantToPurchase = book.WantToPurchase
            };
        }

        public GetBookResponseBody TranslateToDtc(Domain.Services.Book book)
        {
            return new GetBookResponseBody
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Pages = book.Pages,
                Genre = book.Genre,
                Isbn = book.Isbn,
                Price = book.Price,
                DatePurchased = book.DatePurchased,
                WantToPurchase = book.WantToPurchase
            };
        }

        public Domain.Services.Book TranslateToService(CreateBookRequestBody request)
        {
            return new Domain.Services.Book
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                Pages = request.Pages,
                Genre = request.Genre,
                Isbn = request.Isbn,
                Price = request.Price,
                DatePurchased = request.DatePurchased,
                WantToPurchase = request.WantToPurchase
            };
        }
    }
}