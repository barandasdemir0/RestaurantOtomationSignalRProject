using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Models;
using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Concrete;
using Project.DtoLayer.AboutDto;
using Project.DtoLayer.BasketDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {

        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketsController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketsByMenuTableNumber(int id)
        {
            return Ok(_basketService.TGetBasketsByMenuTableNumber(id));
        }
        [HttpGet("GetBasketsByMenuTableWithProductName")]
        public IActionResult GetBasketsByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            //var values = context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableID == id).Select(z=>z.Product!.ProductName);
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                ProductID = z.ProductID,
                ProductCount = z.ProductCount,
                MenuTableID = z.MenuTableID,
                ProductPrice = z.ProductPrice,
                ProductName = z.Product!.ProductName,
                ProductTotalPrice = z.ProductTotalPrice,

            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BasketAdd(CreateBasketDto createBasketDto)
        {
            var detectedValues = _mapper.Map<Basket>(createBasketDto);
            _basketService.TInsert(detectedValues);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value!);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }

    }
}
