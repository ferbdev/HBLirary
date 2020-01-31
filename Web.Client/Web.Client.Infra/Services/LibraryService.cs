using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Web.Client.Domain.Models;
using Web.Client.Domain.Services;

namespace Web.Client.Infra.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly HBLibraryService.Client _api;
        private readonly IMapper _mapper;
        private readonly Configs _config;

        public LibraryService(IMapper mapper, Configs configs)
        {
            var httpClient = new HttpClient();

            _config = configs;

            _api = new HBLibraryService.Client(_config.ApiUrl, httpClient);

            _api.BaseUrl = _config.ApiUrl;

            _mapper = mapper;
        }

        public DefaultMethodResultObject DeleteBookByID(int id)
        {
            var call = _api.DeleteBookByIdAsync(id);

            call.Wait();

            Domain.Models.DefaultMethodResultObject resultObj = _mapper.Map<Domain.Models.DefaultMethodResultObject>(call.Result);

            return resultObj;
        }

        public List<BookObject> GetAllBooks()
        {
            var call = _api.GetAllBooksAsync();

            call.Wait();

            List<Domain.Models.BookObject> resultObj = _mapper.Map<List<Domain.Models.BookObject>>(call.Result);

            return resultObj;
        }

        public List<BookObject> GetBookByName(string name)
        {
            var call = _api.GetBooksByNameAsync(name);

            call.Wait();

            List<Domain.Models.BookObject> resultObj = _mapper.Map<List<Domain.Models.BookObject>>(call.Result);

            return resultObj;
        }

        public BookObject GetBookById(int id)
        {
            var call = _api.GetBookByIdAsync(id);

            call.Wait();

            Domain.Models.BookObject resultObj = _mapper.Map<Domain.Models.BookObject>(call.Result);

            return resultObj;
        }

        public DefaultMethodResultObject InsertBook(BookObject bookObject)
        {
            var call = _api.InsertBookAsync(bookObject.IdBook, bookObject.BookName, bookObject.BookAuthor, bookObject.BookPublisher, bookObject.BookRegion, bookObject.BookReleaseDate);

            call.Wait();

            Domain.Models.DefaultMethodResultObject resultObj = _mapper.Map<Domain.Models.DefaultMethodResultObject>(call.Result);

            return resultObj;
        }

        public DefaultMethodResultObject UpdateBook(BookObject bookObject)
        {
            var call = _api.UpdateBookAsync(bookObject.IdBook, bookObject.BookName, bookObject.BookAuthor, bookObject.BookPublisher, bookObject.BookRegion, bookObject.BookReleaseDate);

            call.Wait();

            Domain.Models.DefaultMethodResultObject resultObj = _mapper.Map<Domain.Models.DefaultMethodResultObject>(call.Result);

            return resultObj;
        }
    }
}
