using System.Collections.Generic;
using Library.Domain.Services;

namespace Library.Domain.Interfaces.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int bookId);
        int CreateBook(Book book);
        void RemoveBook(int bookId);
    }
}