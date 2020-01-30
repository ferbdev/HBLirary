using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Client.Models
{
    public class LibraryBookViewModel
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

        public int IdBook { get; set; }

        [DisplayName("Nome do Livro")]
        public string BookName { get; set; }

        [DisplayName("Autor")]
        public string BookAuthor { get; set; }

        [DisplayName("Editora")]
        public string BookPublisher { get; set; }

        [DisplayName("País")]
        public string BookRegion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayName("Data de lançamento")]
        public DateTime BookReleaseDate { get; set; }
    }
}
