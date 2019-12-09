using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase
{
    class DBService
    {
        // Add Methods
        public void Add(Grade grade)
        {
            using (var db = new AcademicModel())
            {
                db.grade.Add(grade);
                db.SaveChanges();
            }
        }

        // Delete Methods
        public void Delete(Grade grade)
        {
            using (var db = new AcademicModel())
            {
                var target = db.grade.Find(grade.scid);
                db.grade.Remove(target);
                db.SaveChanges();
            }
        }

        // Update Methods
        public void Update(Grade grade)
        {
            using (var db = new AcademicModel())
            {
                db.grade.Attach(grade);
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Retrieve Method
        public List<Course> GetAllCourses()
        {
            using (var db = new AcademicModel())
                return db.course.ToList();
        }
    }
}
