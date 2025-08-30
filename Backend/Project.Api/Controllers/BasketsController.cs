using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Models;
using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Concrete;

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
    }
}
