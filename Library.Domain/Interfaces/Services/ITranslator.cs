
using Library.Domain.DataTransferClasses.Requests;
using Library.Domain.DataTransferClasses.Responses;

namespace Library.Domain.Interfaces.Services
{
    public interface ITranslator
    {
        Library.Domain.DataTransferClasses.Book Translate(Library.Domain.Services.Book book);
        GetBookResponseBody TranslateToDtc(Domain.Services.Book book);
        Domain.Services.Book TranslateToService(CreateBookRequestBody request);
    }
}