using GoodsProject.Data;
using GoodsProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GoodsProject.Services
{
    public class PurchaseService
    {
        private readonly ApplicationDbContext _context;

        public PurchaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PurchaseOrder AddDocument(PurchaseOrder document)
        {
            ValidateAddDocument(document);

            document.CreateDate = DateTime.Now;
            document.LastUpdateDate = null; // Set to null as per requirement
            document.LastUpdatedBy = null; // Set to null as per requirement

            _context.PurchaseOrder.Add(document);
            _context.SaveChanges();

            return document;
        }

        public PurchaseOrder UpdateDocument(PurchaseOrder updatedDocument)
        {
            ValidateUpdateDocument(updatedDocument);

            var existingDocument = _context.PurchaseOrder.Find(updatedDocument.ID);
            if (existingDocument == null)
            {
                throw new ArgumentException("Document not found");
            }

            existingDocument.BPCode = updatedDocument.BPCode;
            existingDocument.LastUpdateDate = DateTime.Now;
            existingDocument.LastUpdatedBy = updatedDocument.LastUpdatedBy;

            _context.SaveChanges();

            return existingDocument;
        }

        public void DeleteDocument(int id)
        {
            var document = _context.PurchaseOrder.Find(id);
            if (document == null)
            {
                throw new ArgumentException("Document not found");
            }

            if (!document.PurchaseOrderLines.Any())
            {
                throw new InvalidOperationException("Document must have at least one line");
            }

            _context.PurchaseOrder.Remove(document);
            _context.SaveChanges();
        }

        public PurchaseOrder GetDocument(int id)
        {
            var document = _context.PurchaseOrder
                            .FirstOrDefault(po => po.ID == id);

            return document;
        }

        private void ValidateAddDocument(PurchaseOrder document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            // Check if BPCode is provided
            if (string.IsNullOrEmpty(document.BPCode))
            {
                throw new ArgumentException("Business partner code is required");
            }

            // Check if business partner exists and is active
            var businessPartner = _context.BusinessPartner.FirstOrDefault(bp => bp.BPCode == document.BPCode);
            if (businessPartner == null || !businessPartner.Active)
            {
                throw new InvalidOperationException("Business partner not found or inactive");
            }

            // It’s not possible to add a purchase document for a business partner of type S
            if (businessPartner.BPType == "S")
            {
                throw new InvalidOperationException("Cannot add a purchase document for a business partner of type Supplier");
            }

            /*
            if (document.PurchaseOrderLines == null || !document.PurchaseOrderLines.Any())
            {
                throw new InvalidOperationException("Document must have at least one line");
            }*/

          /*  foreach (var line in document.PurchaseOrderLines)
            {
                var item = _context.Item.FirstOrDefault(i => i.ItemCode == line.ItemCode);
                if (item == null || !item.Active)
                {
                    throw new InvalidOperationException($"Item '{line.ItemCode}' not found or inactive");
                }
            }*/
        }

        private void ValidateUpdateDocument(PurchaseOrder updatedDocument)
        {
            if (updatedDocument == null)
            {
                throw new ArgumentNullException(nameof(updatedDocument));
            }

            // It’s not possible to update a document that doesn’t exists
            var existingDocument = _context.PurchaseOrder.Find(updatedDocument.ID);
            if (existingDocument == null)
            {
                throw new ArgumentException("Document not found");
            }

            // It’s not possible to use a business partner of type S in a purchase document
            var businessPartner = _context.BusinessPartner.FirstOrDefault(bp => bp.BPCode == updatedDocument.BPCode);
            if (businessPartner != null && businessPartner.BPType == "S")
            {
                throw new InvalidOperationException("Cannot use a business partner of type Supplier in a purchase document");
            }

            // It’s not possible to change the business partner to an inactive one
            if (businessPartner == null || !businessPartner.Active)
            {
                throw new InvalidOperationException("Cannot change the business partner to an inactive one");
            }

            // It’s not possible to delete all the document lines
            if (updatedDocument.PurchaseOrderLines == null || !updatedDocument.PurchaseOrderLines.Any())
            {
                throw new InvalidOperationException("Document must have at least one line");
            }

        }

    }
}
