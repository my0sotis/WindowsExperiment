namespace DatabaseApplication.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("education_system.student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            account = new HashSet<Account>();
            grade1 = new HashSet<Grade>();
        }

        [Key]
        public int sid { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [Required]
        [StringLength(20)]
        public string studentid { get; set; }

        [Required]
        [StringLength(20)]
        public string idnum { get; set; }

        [Required]
        [StringLength(2)]
        public string sex { get; set; }

        [Column(TypeName = "mediumint")]
        public int age { get; set; }

        [Column(TypeName = "mediumint")]
        public int grade { get; set; }

        [Required]
        [StringLength(20)]
        public string college { get; set; }

        [Required]
        [StringLength(20)]
        public string profession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> grade1 { get; set; }
    }
}
