using DatabaseApplication.DataBase;

namespace DatabaseApplication.Models
{
    internal class BriefCourse
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