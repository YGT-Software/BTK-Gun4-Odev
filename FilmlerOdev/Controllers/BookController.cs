using FilmlerOdev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FilmlerOdev.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Book> bookList = new List<Book>();
            //rest apiye talepte bulunacak nesnemiz.
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7093/api/Books"))
                {
                    string gelenString = await response.Content.ReadAsStringAsync();
                    bookList = JsonConvert.DeserializeObject<List<Book>>(gelenString);
                }
            }
            return View(bookList);
        }

        public async Task<IActionResult> DetayGetir(int id)
        {
            Book bookDetail = new Book();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7093/api/Books/" + id))
                {
                    string gelenString = await response.Content.ReadAsStringAsync();
                    bookDetail = JsonConvert.DeserializeObject<Book>(gelenString);
                }
            }
            return View(bookDetail);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            Book kaydedilmisFilm = new Book();
            using (var httpClient = new HttpClient())
            {
                StringContent serializeEdilecekKitap = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7093/api/Books", serializeEdilecekKitap))
                {
                    string gelenKaydedilmisKitapJsonString = await response.Content.ReadAsStringAsync();
                    kaydedilmisFilm = JsonConvert.DeserializeObject<Book>(gelenKaydedilmisKitapJsonString);
                  
                }
            }

            return RedirectToAction("Index");
        }
    }
}

