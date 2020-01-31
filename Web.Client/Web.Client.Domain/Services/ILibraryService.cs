using System;
using System.Collections.Generic;
using System.Text;
using Web.Client.Domain.Models;

namespace Web.Client.Domain.Services
{
    public interface ILibraryService
    {
        List<BookObject> GetAllBooks();

        List<BookObject> GetBookByName(string name);

        BookObject GetBookById(int id);

        DefaultMethodResultObject DeleteBookByID(int id);

        DefaultMethodResultObject InsertBook(BookObject bookObject);

        DefaultMethodResultObject UpdateBook(BookObject bookObject);
    }
}
