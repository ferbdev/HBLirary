using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Client.Domain.Models;

namespace Web.Client.Models
{
    public class LibraryBookViewModel : BookObject
    {
        public LibraryBookViewModel()
        {
            
        }

        public LibraryBookViewModel(int idBook, string bookName, string bookAuthor, string bookPublisher, string bookRegion, DateTime bookReleaseDate)
        {
            IdBook = idBook;
            BookName = bookName;
            BookAuthor = bookAuthor;
            BookPublisher = bookPublisher;
            BookRegion = bookRegion;
            BookReleaseDate = bookReleaseDate;
        }
    }
}
