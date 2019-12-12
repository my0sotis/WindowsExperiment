namespace DatabaseApplication.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AcademicDB : DbContext
    {
        public AcademicDB()
            : base("name=AcademicDB")
        {
        }

        public virtual DbSet<Account> account { get; set; }
        public virtual DbSet<Course> course { get; set; }
        public virtual DbSet<Grade> grade { get; set; }
        public virtual DbSet<Student> student { get; set; }
        public virtual DbSet<Teacher> teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.cname)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.field)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.place)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.studentid)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.idnum)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.college)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.profession)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.tname)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.dept)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.job)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.sex)
                .IsUnicode(false);
        }
    }
}
