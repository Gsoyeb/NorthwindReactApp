using Microsoft.AspNetCore.Mvc;
using NorthwindReactApp.Services;

namespace NorthwindReactApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : Controller
    {
        private readonly WarehouseService _service;

        public WarehouseController(WarehouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var warehouses = await _service.GetAllWarehousesAsync();
            return Ok(warehouses);
        }
    }
}
