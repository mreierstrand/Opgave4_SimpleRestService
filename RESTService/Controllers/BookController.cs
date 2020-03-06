using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleRestServiceOpgave4;

namespace RESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static readonly List<Book> books = new List<Book>()
        {
            new Book("Løvernes Konge","JK Rowling",100,"1234567891011"),
            new Book("Harry Potter","Omar Masouk",200,"1234567891012"),
            new Book("Vejen til isbutikken","Rosa Bank",300,"1234567891013"),
            new Book("Charlie og Chokoladefabrikken","HC Andersen",400,"1234567891014"),
            new Book("Albertshave","Kris Sørensen",500,"1234567891015"),
        };

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        [HttpGet("{isbn13}", Name = "Get")]
        public Book GetBook(string isbn13)
        {
            return books.Find(i => i.ISBN13.Equals(isbn13));
        }

        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book book = GetBook(isbn13);
            if (book != null)
            {
                book.ISBN13 = value.ISBN13;
                book.Title = value.Title;
                book.Author = value.Author;
                book.NoOfPages = value.NoOfPages;
            }
        }

        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book book = GetBook(isbn13);
            books.Remove(book);
        }
    }
}