namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("education_system.teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            course = new HashSet<Course>();
        }

        [Key]
        public int tid { get; set; }

        [Required]
        [StringLength(20)]
        public string tname { get; set; }

        [Required]
        [StringLength(20)]
        public string dept { get; set; }

        [Required]
        [StringLength(10)]
        public string job { get; set; }

        [Required]
        [StringLength(2)]
        public string sex { get; set; }

        [Column(TypeName = "mediumint")]
        public int age { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> course { get; set; }
    }
}
