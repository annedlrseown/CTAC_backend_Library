using System.Collections.Generic;
using Library.Domain.Services;

namespace Library.Domain.Interfaces.DataLayer
{
    public interface IBookStorage
    {
        int InsertBook(Book book);
        void Delete(int bookId);
        Book SelectBookById(int bookId);
        IEnumerable<Book> SelectAll();
    }
}