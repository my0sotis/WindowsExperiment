using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseApplication.DataBase
{
    [Table("education_system.course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            grade = new HashSet<Grade>();
        }

        [Key]
        public int cid { get; set; }

        [Required]
        [StringLength(20)]
        public string cname { get; set; }

        public byte credit { get; set; }

        [Column(TypeName = "mediumint")]
        public int total { get; set; }

        [Column(TypeName = "mediumint")]
        public int exist { get; set; }

        [Required]
        [StringLength(10)]
        public string field { get; set; }

        [Column(TypeName = "umediumint")]
        public int time { get; set; }

        [Required]
        [StringLength(30)]
        public string place { get; set; }

        public int tid { get; set; }

        public virtual Teacher teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> grade { get; set; }
    }
}