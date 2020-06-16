using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Interfaces.DataLayer;
using Library.Domain.Interfaces.Services;
using Library.Domain.Services;

namespace Library.Services
{

    public class BookService: IBookService
    {
        private readonly IBookStorage _bookStorage;

        public BookService(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int bookId)
        {
            var book = _bookStorage.SelectBookById(bookId);
            return book;
        }

        public int CreateBook(Book book)
        {
            Validate(book);

            var bookId = _bookStorage.InsertBook(book);
            return bookId;
        }

        public void RemoveBook(int bookId)
        {
            _bookStorage.Delete(bookId);
        }

        private void Validate(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException("Missing Title");
            }
        }
    }
}
