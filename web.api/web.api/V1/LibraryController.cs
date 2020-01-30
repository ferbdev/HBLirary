using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Models;

namespace web.api.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/configuration")]
    public class LibraryController
    {
        [Route("GetBookByName")]
        [HttpGet]
        public BookObject GetBookByName(string bookName)
        {
            return new BookObject();
        }

        [Route("GetAllBooks")]
        [HttpGet]
        public List<BookObject> GetAllBooks()
        {
            return new List<BookObject>();
        }

        [Route("DeleteBookById")]
        [HttpPost]
        public DefaultMethodResultObject DeleteBookById(int id)
        {
            return new DefaultMethodResultObject();
        }

        [Route("InsertBook")]
        [HttpPost]
        public DefaultMethodResultObject InsertBook(BookObject bookObject)
        {
            return new DefaultMethodResultObject();
        }

        [Route("UpdateBook")]
        [HttpPost]
        public DefaultMethodResultObject UpdateBook(BookObject bookObject)
        {
            return new DefaultMethodResultObject();
        }
    }
}