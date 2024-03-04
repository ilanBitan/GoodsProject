using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GoodsProject.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(1024)]
        public string FullName { get; set; }

        [Required]
        [StringLength(254)]
        //[Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;
    }
}
