using Library.Domain.Services;

namespace Library.Domain.Interfaces.DataLayer
{
    public interface IBookStorage
    {
        int InsertBook(Book book);
    }
}