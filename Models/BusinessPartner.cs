using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsProject.Models
{
    public class BusinessPartner
    {
        [Key]
        [StringLength(128)]
        public string BPCode { get; set; }

        [Required]
        [StringLength(254)]
        public string BPName { get; set; }

        [Required]
        [ForeignKey("BPType")]
        [StringLength(1)]
        public string BPType { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }


    }
}
