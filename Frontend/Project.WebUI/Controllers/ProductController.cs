using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.WebUI.Dtos.CategoryDtos;
using Project.WebUI.Dtos.ProductDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient(); //bunu her zaman açmak zorundasın
            var responseMessage = await client.GetAsync("https://localhost:7240/api/Product/ProductListWithCategory"); //ilk adım veriyi çek
            if (responseMessage.IsSuccessStatusCode) // eğer veri çekildiyse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //veriyi oku string formatta
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); //veriyi çevir
                return View(values); //veriyi ver
            }
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> ProductCreate()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7240/api/Category");
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

        //    List<SelectListItem> selectCategoryName = (from x in values
        //                                   select new SelectListItem
        //                                   {
        //                                       Value = x.CategoryID.ToString(),
        //                                       Text = x.CategoryName,
        //                                   }).ToList();

        //    ViewBag.SelectCategoryName = selectCategoryName;




        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ProductCreate(CreateProductDto createProductDto)
        //{
        //    createProductDto.ProductStatus = true; //default olarak true döndürmek için
        //    var client = _httpClientFactory.CreateClient(); //klasik açıyotuz




        //    var jsonData = JsonConvert.SerializeObject(createProductDto); //verimizi önce json formata döndürüyoruz


        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json"); //sonra nasıl göndereceğimize söylüyoruz json datadan gfelen veri encoding olarak utf8 ve json veri diyoruz
        //    var responseMessage = await client.PostAsync("https://localhost:7240/api/Product", content); //sonra veriyi gönderiyoruz


        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");//başarılıysa indxe dön
        //    }
        //    return View();
        //}



        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/Category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7240/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> ProductDelete(int id)
        {
            var client = _httpClientFactory.CreateClient(); //klasik kapıyı aç
            await client.DeleteAsync($"https://localhost:7240/api/Product{id}"); //veriyi bul ve sil
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7240/api/Category");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            List<SelectListItem> values2 = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7240/api/Product/{id}"); // veriyi getir

            if (responseMessage.IsSuccessStatusCode) // veri başarılı gelirse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // veriyi string formatında oku
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData); // veriyi normal formata getr
               
                return View(values); //bana sun
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient(); 
            var jsonData = JsonConvert.SerializeObject(updateProductDto);//giden veriyi bu formata sok
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//nasıl gideceğini söyle
            var responseMessage = await client.PutAsync("https://localhost:7240/api/Product", stringContent); //ardından gönder
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); //başarılı olursa gönder
            }
            return View();
        }
    }
}
