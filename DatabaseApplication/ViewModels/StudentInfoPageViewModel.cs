using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace DatabaseApplication.ViewModels
{
    class StudentInfoPageViewModel : BaseViewModel
    {
        public StudentInfoPageViewModel(Student student)
        {
            Student = student;
        }

        public Student Student { get; set; }
    }
}
