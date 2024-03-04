using Microsoft.AspNetCore.Mvc;
using GoodsProject.Services;

namespace GoodsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemServicesController : ControllerBase
    {
        private readonly ItemService _itemsService;

        public ItemServicesController(ItemService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet]
        public IActionResult GetItems(string columnName = null, string filterValue = null, int page = 1)
        {
           var (items, totalPages) = _itemsService.ReadItems(columnName, filterValue, page);

            if (items == null)
            {
                return NotFound();
            }

            return new JsonResult(new { items, totalPages });
        }
    }
}
