using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitaplarOdevCodeFirst.Models;

namespace KitaplarOdevCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private KitaplarDbContext dbContext;
        public BooksController(KitaplarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<Book> KitaplariGetir()
        {
            List<Book> books = new List<Book>();
            books = dbContext.Book.ToList(); 
            return books;
        }

        
        [HttpPost]
        public Book KitapEkle(Book book)
        {
            dbContext.Book.Add(book);
            dbContext.SaveChanges();
            return book;
        }

        [HttpPut]
        public Book KitapGuncelle(Book book)
        {
            dbContext.Book.Update(book);
            dbContext.SaveChanges();
            return book;
        }

        [HttpDelete("{id}")]
        public void KitapSil(int id)
        {
            Book silinecekKitap = dbContext.Book.Find(id);
            dbContext.Book.Remove(silinecekKitap);
            dbContext.SaveChanges();
        }

        [HttpGet("{id}")]
        public Book KitapDetayGetir(int id)
        {
            Book detayBook = dbContext.Book.Find(id);
            return detayBook;
        }
    }
}