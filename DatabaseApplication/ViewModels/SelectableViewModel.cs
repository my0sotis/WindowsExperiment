using DatabaseApplication.DataBase;

namespace DatabaseApplication.ViewModels
{
    internal class SelectableViewModel : BaseViewModel
    {
        public SelectableViewModel(Course course)
        {
            SelectCourse = course;
            IsSelected = false;
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private Course _course;

        public Course SelectCourse
        {
            get { return _course; }
            set
            {
                if (_course == value) return;
                _course = value;
                OnPropertyChanged();
            }
        }
    }
}