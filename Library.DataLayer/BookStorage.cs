using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Interfaces.DataLayer;
using Library.Domain.Services;

namespace Library.DataLayer
{
    public class BookStorage: IBookStorage
    {
        private static readonly Dictionary<int, Book> _yeOldeBookDepository = new Dictionary<int, Book>();

        public BookStorage()
        {
        }

        public int InsertBook(Book book)
        {
            int id;
            if (_yeOldeBookDepository.Keys.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = _yeOldeBookDepository.Max(x => x.Key) +1;
            }

            _yeOldeBookDepository.Add(id, book);

            return id;
        }

        public void Delete(int bookId)
        {
            if (_yeOldeBookDepository.ContainsKey(bookId))
            {
                _yeOldeBookDepository.Remove(bookId);
            }
        }

        public Book SelectBookById(int bookId)
        {
            if (_yeOldeBookDepository.ContainsKey(bookId))
            {
                var book = _yeOldeBookDepository[bookId];
                return book;
            }

            return null;
        }

        public IEnumerable<Book> SelectAll()
        {
            return _yeOldeBookDepository.Values;
        }
    }
}
