using Microsoft.AspNetCore.Mvc;
using GoodsProject.Services;

namespace GoodsProject.Controllers
{
    [Route("[controller]")]
    public class BusinessPartnersServicesController : ControllerBase
    {
        private readonly BusinessPartnersService _businessPartnersService;

        public BusinessPartnersServicesController(BusinessPartnersService businessPartnersService)
        {
            _businessPartnersService = businessPartnersService;
        }

        [HttpGet]
        public IActionResult Index(string columnName = null, string filterValue = null, int page = 1)
        {
            var (businessPartners, totalPages) = _businessPartnersService.ReadBusinessPartners(columnName, filterValue, page);

            if (businessPartners == null)
            {
                return NotFound();
            }

            // Return the result along with the total number of pages
            var result = new
            {
                BusinessPartners = businessPartners,
                TotalPages = totalPages
            };

            // Return the result as JSON
            return Ok(result);
        }
    }
}
