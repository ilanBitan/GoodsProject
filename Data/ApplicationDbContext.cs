using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GoodsProject.Models;

namespace GoodsProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GoodsProject.Models.User> User { get; set; }
        public DbSet<GoodsProject.Models.BPType> BPType { get; set; }
        public DbSet<GoodsProject.Models.BusinessPartner> BusinessPartner { get; set; }
        public DbSet<GoodsProject.Models.Item> Item { get; set; }
        public DbSet<GoodsProject.Models.SaleOrder> SaleOrder { get; set; }
        public DbSet<GoodsProject.Models.SaleOrderLine> SaleOrderLine { get; set; }
        public DbSet<GoodsProject.Models.SaleOrderLineComment> SaleOrderLineComment { get; set; }
        public DbSet<GoodsProject.Models.PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<GoodsProject.Models.PurchaseOrderLine> PurchaseOrderLine { get; set; }
    }
}
