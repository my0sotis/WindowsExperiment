using DatabaseApplication.DataBase;

namespace DatabaseApplication.ViewModels
{
    internal class StudentInfoPageViewModel : BaseViewModel
    {
        public StudentInfoPageViewModel(Student student)
        {
            Student = student;
        }

        public Student Student { get; set; }
    }
}