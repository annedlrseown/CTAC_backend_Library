using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DataTransferClasses.Responses
{
    public class GetBookResponseBody: Book
    {
        public int BookId { get; set; }
    }
}
