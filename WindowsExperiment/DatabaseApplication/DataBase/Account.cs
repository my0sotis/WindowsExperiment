using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseApplication.DataBase
{
    [Table("education_system.account")]
    public partial class Account
    {
        [Key]
        public int aid { get; set; }

        [Column("account")]
        [Required]
        [StringLength(20)]
        public string account { get; set; }

        [Required]
        [StringLength(18)]
        public string password { get; set; }

        public int sid { get; set; }

        public virtual Student student { get; set; }
    }
}