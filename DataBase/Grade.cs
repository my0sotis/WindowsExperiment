namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("education_system.grade")]
    public partial class Grade
    {
        [Key]
        public int scid { get; set; }

        [Column("grade", TypeName = "mediumint")]
        public int? grade1 { get; set; }

        public int sid { get; set; }

        public int cid { get; set; }

        public virtual Course course { get; set; }

        public virtual Student student { get; set; }
    }
}
