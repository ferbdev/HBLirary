using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Client.Domain.Models;
using Web.Client.Domain.Services;
using Web.Client.Models;

namespace Web.Client.Controllers
{
    public class LibraryBooksController : Controller
    {
        private readonly ILibraryService _libraryService;
        public LibraryBooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public IActionResult Index(string txtBookName)
        {
            List<BookObject> bookList = new List<BookObject>();

            if (!string.IsNullOrWhiteSpace(txtBookName))
                bookList = _libraryService.GetBookByName(txtBookName);
            else
                bookList = _libraryService.GetAllBooks();

            ViewBag.BookName = txtBookName;

            return View(bookList);
        }

        // GET: Employee/Create
        public IActionResult CreateOrEdit(int id)
        {
            BookObject libraryBook = new BookObject();
            if (id > 0)
                libraryBook = _libraryService.GetBookById(id);

            if (libraryBook.IdBook == 0)
                return View(new BookObject());
            else
            {
                return View(libraryBook);
            }
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEditSave([Bind("IdBook,BookName,BookAuthor,BookPublisher,BookRegion,BookReleaseDate")] BookObject libraryBook)
        {
            if (ModelState.IsValid)
            {
                if (libraryBook.IdBook == 0)
                {
                    _libraryService.InsertBook(libraryBook);
                }
                else
                {
                    _libraryService.UpdateBook(libraryBook);
                }
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(libraryBook);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            _libraryService.DeleteBookByID(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}