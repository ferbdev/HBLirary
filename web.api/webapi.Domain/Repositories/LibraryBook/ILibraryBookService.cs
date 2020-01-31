using System;
using System.Collections.Generic;
using System.Text;
using webapi.Domain.Models;

namespace webapi.Domain.Repositories.LibraryBook
{
    public interface ILibraryBookService
    {
        List<BookObject> GetBookById(int idBook);
        List<BookObject> GetBooksByName(string bookName);

        List<BookObject> GetAllBooks();

        DefaultMethodResultObject DeleteBookById(int id);

        DefaultMethodResultObject InsertBook(BookObject bookObject);

        DefaultMethodResultObject UpdateBook(BookObject bookObject);
    }
}
