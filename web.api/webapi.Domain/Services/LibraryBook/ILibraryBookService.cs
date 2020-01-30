using System;
using System.Collections.Generic;
using System.Text;
using webapi.Domain.Models;

namespace webapi.Domain.Services.LibraryBook
{
    public interface ILibraryBookService
    {
        BookObject GetBookByName(string bookName);

        List<BookObject> GetAllBooks();

        DefaultMethodResultObject DeleteBookById(int id);

        DefaultMethodResultObject InsertBook(BookObject bookObject);

        DefaultMethodResultObject UpdateBook(BookObject bookObject);
    }
}
