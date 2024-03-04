using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsProject.Models
{
    public class PurchaseOrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineID { get; set; }

        [Required]
        [ForeignKey("PurchaseOrder")]
        public int DocID { get; set; }

        [Required]
        [ForeignKey("Item")]
        [StringLength(128)]
        public string ItemCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(38,18)")]
        public decimal Quantity { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CreatedBy { get; set; }

        [ForeignKey("User")]
        public int? LastUpdatedBy { get; set; }
    }
}
