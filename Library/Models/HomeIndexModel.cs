using System.Collections.Generic;
using Library.Domain.Services;

namespace Library.Models
{
    public class HomeIndexModel
    {
        public List<Book> Books { get; set; }
        public string Title { get; set; }
    }
}