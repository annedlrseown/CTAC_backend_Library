using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DataTransferClasses
{
    public class Book
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public DateTime? DatePurchased { get; set; }
        public bool WantToPurchase { get; set; }
    }
}
