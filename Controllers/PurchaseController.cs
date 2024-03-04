using GoodsProject.Models;
using GoodsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _purchaseService;

        public PurchaseController(PurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public IActionResult AddDocument(PurchaseOrder document)
        {
            var createdDocument = _purchaseService.AddDocument(document);
            return Ok(createdDocument);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDocument(int id, PurchaseOrder updatedDocument)
        {
            if (id != updatedDocument.ID)
            {
                return BadRequest("ID in URL does not match ID in request body");
            }

            var updatedDocumentResult = _purchaseService.UpdateDocument(updatedDocument);
            return Ok(updatedDocumentResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(int id)
        {
            _purchaseService.DeleteDocument(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetDocument(int id)
        {
            var document = _purchaseService.GetDocument(id);
            if (document == null)
            {
                return NotFound($"Document with ID {id} not found");
            }

            return Ok(document);
        }
    }
}
