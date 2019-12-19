using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseApplication.DataBase
{
    [Table("education_system.grade")]
    public partial class Grade
    {
        [Key]
        public int scid { get; set; }

        [Column("grade", TypeName = "mediumint")]
        public int? grade { get; set; }

        public int sid { get; set; }

        public int cid { get; set; }

        public virtual Course course { get; set; }

        public virtual Student student { get; set; }

        public Grade()
        {
        }

        public Grade(int sid, int cid)
        {
            this.sid = sid;
            this.cid = cid;
        }
    }
}