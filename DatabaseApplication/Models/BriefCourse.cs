using DatabaseApplication.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Models
{
    class BriefCourse
    {
        public Course course { set; get; }
        public string Teacher { set; get; }
        public BriefCourse(Course course)
        {
            this.course = course;
            var dbs = new DBService();
            var teacher = dbs.GetTeacherByTid(course.tid);
            Teacher = teacher.tname;
        }
    }
}
