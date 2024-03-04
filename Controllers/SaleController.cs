using GoodsProject.Models;
using GoodsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult AddDocument(SaleOrder document)
        {
            var createdDocument = _saleService.AddDocument(document);
            return Ok(createdDocument);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDocument(int id, SaleOrder updatedDocument)
        {
            if (id != updatedDocument.ID)
            {
                return BadRequest("ID in URL does not match ID in request body");
            }

            var updatedDocumentResult = _saleService.UpdateDocument(updatedDocument);
            return Ok(updatedDocumentResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(int id)
        {
            _saleService.DeleteDocument(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetDocument(int id)
        {
            var document = _saleService.GetDocument(id);
            if (document == null)
            {
                return NotFound($"Document with ID {id} not found");
            }

            return Ok(document);
        }
    }
}
