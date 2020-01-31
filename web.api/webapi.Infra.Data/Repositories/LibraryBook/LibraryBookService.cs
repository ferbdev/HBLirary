using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webapi.Domain.Models;
using webapi.Domain.Repositories.LibraryBook;
using webapi.Infra.Data.Context;

namespace webapi.Infra.Data.Repositories.LibraryBook
{
    public class LibraryBookService : ILibraryBookService
    {
        private readonly LibraryContext _context;
        public LibraryBookService(LibraryContext Context)
        {
            _context = Context;
        }

        public LibraryBookService()
        {

        }

        public DefaultMethodResultObject DeleteBookById(int id)
        {
            DefaultMethodResultObject result = new DefaultMethodResultObject();

            try
            {
                using (var db = _context)
                {
                    BookObject book = new BookObject() { IdBook = id };
                    _context.Books.Attach(book);
                    _context.Books.Remove(book);
                    _context.SaveChanges();

                    result.Code = 0;
                    result.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Code = 999;
                result.Message = ex.Message;
            }

            return result;
        }

        public List<BookObject> GetAllBooks()
        {
            var result = _context.Books.ToList();

            return result;
        }

        public DefaultMethodResultObject InsertBook(BookObject bookObject)
        {
            DefaultMethodResultObject result = new DefaultMethodResultObject();

            try
            {
                using (var db = _context)
                {
                    _context.Books.Add(bookObject);
                    _context.SaveChanges();

                    result.Code = 0;
                    result.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Code = 999;
                result.Message = ex.Message;
            }

            return result;
        }

        public DefaultMethodResultObject UpdateBook(BookObject bookObject)
        {
            DefaultMethodResultObject result = new DefaultMethodResultObject();

            try
            {
                using (var db = _context)
                {
                    var foundBook = db.Books.SingleOrDefault(b => b.IdBook == bookObject.IdBook);
                    if (foundBook != null)
                    {
                        foundBook.BookName = bookObject.BookName;
                        foundBook.BookAuthor = bookObject.BookAuthor;
                        foundBook.BookPublisher = bookObject.BookPublisher;
                        foundBook.BookRegion = bookObject.BookRegion;
                        foundBook.BookReleaseDate = bookObject.BookReleaseDate;

                        db.Books.Update(foundBook);
                        db.SaveChanges();

                        result.Code = 0;
                        result.Message = "OK";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Code = 999;
                result.Message = ex.Message;
            }

            return result;
        }

        public List<BookObject> GetBookById(int idBook)
        {
            var result = _context.Books.Where(x => x.IdBook == idBook).ToList();

            return result;
        }

        public List<BookObject> GetBooksByName(string bookName)
        {
            var result = _context.Books.Where(x => x.BookName.Contains(bookName)).ToList();

            return result;
        }
    }
}
