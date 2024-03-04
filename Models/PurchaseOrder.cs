using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GoodsProject.Models
{
    public class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("BusinessPartner")]
        [StringLength(128)]
        public string BPCode { get; set; }


        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CreatedBy { get; set; }

        [ForeignKey("User")]
        public int? LastUpdatedBy { get; set; }
        
        [JsonIgnore]
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
