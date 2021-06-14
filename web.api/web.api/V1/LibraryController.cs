using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Models;
using webapi.Domain.Repositories.LibraryBook;

namespace web.api.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/configuration")]
    public class LibraryController
    {
        private readonly ILibraryBookService _libraryService;
        public LibraryController(ILibraryBookService libraryService)
        {
            _libraryService = libraryService;
        }

        [Route("GetBookByName")]
        [HttpGet]
        public List<BookObject> GetBooksByName(string bookName)
        {
            return _libraryService.GetBooksByName(bookName);
        }

        [Route("GetBookByNameTest")]
        [HttpGet]
        public List<BookObject> GetBookByNameTest(string bookName)
        {
            return _libraryService.GetBooksByName(bookName);
        }

        [Route("GetBookById")]
        [HttpGet]
        public BookObject GetBookById(int id)
        {
            return _libraryService.GetBookById(id);
        }

        [Route("GetAllBooks")]
        [HttpGet]
        public List<BookObject> GetAllBooks()
        {
            return _libraryService.GetAllBooks();
        }

        [Route("DeleteBookById")]
        [HttpPost]
        public DefaultMethodResultObject DeleteBookById(int id)
        {
            return _libraryService.DeleteBookById(id);
        }

        [Route("InsertBook")]
        [HttpPost]
        public DefaultMethodResultObject InsertBook(BookObject bookObject)
        {
            return _libraryService.InsertBook(bookObject);
        }

        [Route("UpdateBook")]
        [HttpPost]
        public DefaultMethodResultObject UpdateBook(BookObject bookObject)
        {
            return _libraryService.UpdateBook(bookObject);
        }
    }
}