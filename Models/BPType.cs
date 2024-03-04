using System.ComponentModel.DataAnnotations;

namespace GoodsProject.Models
{
    public class BPType
    {
        [Key]
        [StringLength(1)]
        [Required]
        public string TypeCode { get; set; }

        [StringLength(20)]
        [Required]
        public string TypeName { get; set; }

    }
}
