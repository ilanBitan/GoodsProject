/*using GoodsProject.Models;
using GoodsProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoodsProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly SaleService _saleService;
        private readonly PurchaseService _purchaseService;

        public DocumentController(SaleService saleService, PurchaseService purchaseService)
        {
            _saleService = saleService;
            _purchaseService = purchaseService;
        }

        // POST /document
        [HttpPost]
        public IActionResult AddDocument([FromBody] Document document)
        {
            try
            {
                if (document.DocumentType == "sale")
                {
                    var result = _saleService.AddDocument(document);
                    return Ok(result);
                }
                else if (document.DocumentType == "purchase")
                {
                    var result = _purchaseService.AddDocument(document);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid document type.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

*//*        // PUT /document/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDocument(int id, [FromBody] Document document)
        {
            try
            {
                if (document.DocumentType == "sale")
                {
                    var result = _saleService.UpdateDocument(id, document);
                    return Ok(result);
                }
                else if (document.DocumentType == "purchase")
                {
                    var result = _purchaseService.UpdateDocument(id, document);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid document type.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
*//*
        // Define the Document class here
        public class Document
        {
            public string DocumentType { get; set; }
            // Add other properties as needed
        }
    }
}
*/