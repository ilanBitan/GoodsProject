using System.ComponentModel.DataAnnotations;

namespace GoodsProject.Models
{
    public class Item
    {
        [Key]
        [Required]
        [StringLength(128)]
        public string ItemCode { get; set; }
        [Required]
        [StringLength(254)]
        public string ItemName { get; set; }
        [Required]
        public bool Active { get; set; } = true;

    }
}
