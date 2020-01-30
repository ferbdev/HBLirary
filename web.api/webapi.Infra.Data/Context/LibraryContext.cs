using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using webapi.Domain.Models;

namespace webapi.Infra.Data.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<BookObject> Employees { get; set; }
    }
}
