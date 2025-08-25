using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.CategoryDtos;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // apiyi çağıran oradaki şeyleri kullanmamıza yarayan yöntem budur 

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //burada bir bağlantı oluşturtuyoruz

            var responseMessage = await client.GetAsync("https://localhost:7240/api/Category");//ulaşacağımız yani buradaki konuma gitsin oradan çeksin veriyi

            if (responseMessage.IsSuccessStatusCode) //yani verim tamam 200 döndü her şey iyiyse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//jsondan gelen içeriği string formatında oku

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                //listlerken deserelize ekleme güncelleme serialize neden deserelize ile bu json verisini okunabilir hale getiriyoruz nereden jsondan gelen veriyi
                return View(values); //gelen veriyi düzledik
            }
            return View();
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CreateCategoryDto createCategoryDto)
        {

            createCategoryDto.CategoryStatus = true;
            var client = _httpClientFactory.CreateClient(); //burada bir bağlantı oluşturtuyoruz

            var jsonData = JsonConvert.SerializeObject(createCategoryDto);//jsona dönüştür

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //jsondatadan gelen veri encodint utf 8 yap ve json formatında ver

            var responseMessage = await client.PostAsync("https://localhost:7240/api/Category", stringContent);//yine ama bu sefer get yerine post yapıp veriyi gönderiyoruz
            if (responseMessage.IsSuccessStatusCode)//yani verim tamam 200 döndü her şey iyiyse
            {
                return RedirectToAction("Index");//indexe beni at

            }
            return View();
        }


        public async Task<IActionResult> CategoryDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7240/api/Category/{id}");
            return RedirectToAction("Index"); // artık view aramıyor
        }

        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(int  id)
        {

            //updateCategoryDto.CategoryStatus = true;
            var client = _httpClientFactory.CreateClient(); //burada bir bağlantı oluşturtuyoruz
            var responseMessage = await client.GetAsync($"https://localhost:7240/api/Category/{id}");//yine ama bu sefer get yerine post yapıp veriyi gönderiyoruz

         
            if (responseMessage.IsSuccessStatusCode)//yani verim tamam 200 döndü her şey iyiyse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            } 
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {

            //createCategoryDto.CategoryStatus = true;
            var client = _httpClientFactory.CreateClient(); //burada bir bağlantı oluşturtuyoruz

            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);//jsona dönüştür

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //jsondatadan gelen veri encodint utf 8 yap ve json formatında ver

            var responseMessage = await client.PutAsync("https://localhost:7240/api/Category", stringContent);//yine ama bu sefer get yerine put yapıp veriyi gönderiyoruz
            if (responseMessage.IsSuccessStatusCode)//yani verim tamam 200 döndü her şey iyiyse
            {
                return RedirectToAction("Index");//indexe beni at

            }
            return View();
        }

    }
}
