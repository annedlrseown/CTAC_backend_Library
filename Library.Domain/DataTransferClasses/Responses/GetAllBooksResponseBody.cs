using System.Collections.Generic;

namespace Library.Domain.DataTransferClasses.Responses
{
    public class GetAllBooksResponseBody
    {
        public IEnumerable<Book> Books { get; set; }
    }
}