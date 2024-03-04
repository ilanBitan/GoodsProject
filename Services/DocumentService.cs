/*using GoodsProject.Data;
using System;

public class DocumentService
{
    private readonly ApplicationDbContext _context;

    public DocumentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Document AddDocument(Document document)
    {
        // Validate document type
        if (!Enum.IsDefined(typeof(DocumentType), document.Type))
        {
            // Unknown document type
            return null;
        }

        // Validate business partner
        var businessPartner = _context.BusinessPartners.FirstOrDefault(bp => bp.BPCode == document.BPCode);
        if (businessPartner == null || !businessPartner.Active)
        {
            // Business partner not found or not active
            return null;
        }

        // Validate document type and business partner type
        if ((document.Type == DocumentType.SaleOrder && businessPartner.BPType == "V") ||
            (document.Type == DocumentType.PurchaseOrder && businessPartner.BPType == "S"))
        {
            // Invalid document type for the business partner
            return null;
        }

        // Validate lines
        if (document.Lines == null || document.Lines.Count == 0)
        {
            // Document must have at least one line
            return null;
        }

        // Validate item active status for each line (assuming each line has an ItemCode)
        foreach (var line in document.Lines)
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemCode == line.ItemCode);
            if (item == null || !item.Active)
            {
                // Item not found or not active
                return null;
            }
        }

        // Set defaults
        document.CreateDate = DateTime.Now;
        document.LastUpdateDate = null; // Nullable DateTime
        // Set CreatedBy user ID based on your authentication mechanism
        // document.CreatedBy = loggedInUserId;
        document.LastUpdatedBy = null; // Nullable int

        // Add document to the database
        _context.Documents.Add(document);
        _context.SaveChanges();

        return document;
    }
}
*/