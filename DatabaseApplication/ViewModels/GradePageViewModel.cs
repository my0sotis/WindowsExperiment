using DatabaseApplication.DataBase;
using System.Collections.ObjectModel;

namespace DatabaseApplication.ViewModels
{
    internal class GradePageViewModel : BaseViewModel
    {
        public GradePageViewModel(Student student)
        {
            GradeItem = new ObservableCollection<GradeViewModel>();
            var dbs = new DBService();
            var list = dbs.GetGradesByStudent(student);
            foreach (var item in list)
            {
                GradeItem.Add(new GradeViewModel(item));
            }
        }

        private ObservableCollection<GradeViewModel> _gradeitem;

        public ObservableCollection<GradeViewModel> GradeItem
        {
            get { return _gradeitem; }
            set
            {
                if (_gradeitem == value) return;
                _gradeitem = value;
            }
        }
    }
}