using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DatabaseApplication.DataBase
{
    public class DBService
    {
        public DBService()
        {
        }

        // Add Methods
        public void Add(Grade grade)
        {
            using (var db = new AcademicDB())
            {
                db.grade.Add(grade);
                db.SaveChanges();
            }
        }

        // Delete Methods
        public void Delete(Grade grade)
        {
            using (var db = new AcademicDB())
            {
                var target = db.grade.Find(grade.scid);
                db.grade.Remove(target);
                db.SaveChanges();
            }
        }

        // Update Methods
        public void Update(Grade grade)
        {
            using (var db = new AcademicDB())
            {
                db.grade.Attach(grade);
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Update(Course course)
        {
            using (var db = new AcademicDB())
            {
                db.course.Attach(course);
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Retrieve Method
        public List<Course> GetAllCourses()
        {
            using (var db = new AcademicDB())
                return db.course.ToList();
        }

        public Teacher GetTeacherByTid(int tid)
        {
            using (var db = new AcademicDB())
            {
                return db.teacher.Find(tid);
            }
        }

        public Course GetCourseByCid(int cid)
        {
            using (var db = new AcademicDB())
            {
                return db.course.Find(cid);
            }
        }

        public Student GetStudentByAccountAndPassword(string username, string password)
        {
            using (var db = new AcademicDB())
            {
                var account = db.account.Where(l => l.account == username && l.password == password).Single();
                return db.student.Find(account.sid);
            }
        }

        public List<Grade> GetGradesByStudent(Student student)
        {
            using (var db = new AcademicDB())
            {
                return db.grade.Where(g => g.sid == student.sid).ToList();
            }
        }

        public bool Verify(string username, string password)
        {
            using (var db = new AcademicDB())
            {
                var account = db.account.Where(l => l.account == username && l.password == password);
                if (account.Count() == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CheckRemained(Course course)
        {
            if (course.exist <= 0)
            {
                return false;
            }
            return true;
        }

        public bool CheckDuplicate(Course course, Student student)
        {
            using (var db = new AcademicDB())
            {
                var grade = db.grade.Where(l => l.cid == course.cid && l.sid == student.sid);
                if (grade.Count() != 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}