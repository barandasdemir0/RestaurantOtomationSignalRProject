using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTablesService _menuTablesService;

        public MenuTablesController(IMenuTablesService menuTablesService)
        {
            _menuTablesService = menuTablesService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTablesService.TMenuTableCount());
        }
    }
}
