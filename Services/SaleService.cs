using GoodsProject.Data;
using GoodsProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GoodsProject.Services
{
    public class SaleService
    {
        private readonly ApplicationDbContext _context;

        public SaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public SaleOrder AddDocument(SaleOrder document)
        {
            ValidateAddDocument(document);

            document.CreateDate = DateTime.Now;
            document.LastUpdateDate = null; // Set to null as per requirement
            document.LastUpdatedBy = null; // Set to null as per requirement

            _context.SaleOrder.Add(document);
            _context.SaveChanges();

            return document;
        }

        public SaleOrder UpdateDocument(SaleOrder updatedDocument)
        {
            ValidateUpdateDocument(updatedDocument);

            var existingDocument = _context.SaleOrder.Find(updatedDocument.ID);
            if (existingDocument == null)
            {
                throw new ArgumentException("Document not found");
            }

            // Update fields
            existingDocument.BPCode = updatedDocument.BPCode;
            existingDocument.LastUpdateDate = DateTime.Now;
            existingDocument.LastUpdatedBy = updatedDocument.LastUpdatedBy;

            _context.SaveChanges();

            return existingDocument;
        }

        public void DeleteDocument(int id)
        {
            var document = _context.SaleOrder.Find(id);
            if (document == null)
            {
                throw new ArgumentException("Document not found");
            }

            // Additional validation: Ensure document is not being deleted if it has no lines
            if (!document.SaleOrderLines.Any())
            {
                throw new InvalidOperationException("Document must have at least one line");
            }

            _context.SaleOrder.Remove(document);
            _context.SaveChanges();
        }

        public SaleOrder GetDocument(int id)
        {
            var document = _context.SaleOrder
                            .FirstOrDefault(so => so.ID == id);

            return document;
        }

        // Validate document before adding
        private void ValidateAddDocument(SaleOrder document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            // Additional validations
            if (string.IsNullOrEmpty(document.BPCode))
            {
                throw new ArgumentException("Business partner code is required");
            }

            /*var businessPartner = _context.BusinessPartner.FirstOrDefault(bp => bp.BPCode == document.BPCode);
            if (businessPartner == null || !businessPartner.Active)
            {
                throw new InvalidOperationException("Business partner not found or inactive");
            }

            if (businessPartner.BPType == "V")
            {
                throw new InvalidOperationException("Cannot add a sale document for a business partner of type Vendor");
            }*/
            /*if (!document.SaleOrderLines.Any())
            {
                throw new InvalidOperationException("Document must have at least one line");
            }

            foreach (var line in document.SaleOrderLines)
            {
                var item = _context.Item.FirstOrDefault(i => i.ItemCode == line.ItemCode);
                if (item == null || !item.Active)
                {
                    throw new InvalidOperationException($"Item '{line.ItemCode}' not found or inactive");
                }
            }*/
        }

        // Validate document before updating
        private void ValidateUpdateDocument(SaleOrder updatedDocument)
        {
            if (updatedDocument == null)
            {
                throw new ArgumentNullException(nameof(updatedDocument));
            }

            var existingDocument = _context.SaleOrder.Find(updatedDocument.ID);
            if (existingDocument == null)
            {
                throw new ArgumentException("Document not found");
            }

            // Additional validations
            if (existingDocument.BPCode != updatedDocument.BPCode)
            {
                throw new InvalidOperationException("Cannot change business partner");
            }

            var businessPartner = _context.BusinessPartner.FirstOrDefault(bp => bp.BPCode == updatedDocument.BPCode);
            if (businessPartner == null || !businessPartner.Active)
            {
                throw new InvalidOperationException("Business partner not found or inactive");
            }

            if (businessPartner.BPType == "V")
            {
                throw new InvalidOperationException("Cannot update to a sale document for a business partner of type Vendor");
            }

            /*if (!updatedDocument.SaleOrderLines.Any())
            {
                throw new InvalidOperationException("Document must have at least one line");
            }

            foreach (var line in updatedDocument.SaleOrderLines)
            {
                var item = _context.Item.FirstOrDefault(i => i.ItemCode == line.ItemCode);
                if (item == null || !item.Active)
                {
                    throw new InvalidOperationException($"Item '{line.ItemCode}' not found or inactive");
                }
            }*/
        }
    }
}
