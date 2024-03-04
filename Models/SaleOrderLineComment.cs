using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsProject.Models
{
    public class SaleOrderLineComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentLineID { get; set; }

        [Required]
        [ForeignKey("SaleOrder")]
        public int DocID { get; set; }

        [Required]
        [ForeignKey("SaleOrderLine")]
        public int LineID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Comment { get; set; }
    }
}
