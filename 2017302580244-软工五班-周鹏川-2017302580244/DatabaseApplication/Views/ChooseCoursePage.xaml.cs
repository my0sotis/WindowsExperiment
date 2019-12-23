using DatabaseApplication.DataBase;
using DatabaseApplication.ViewModels;
using System.Windows.Controls;

namespace DatabaseApplication
{
    /// <summary>
    /// ChooseCoursePage.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseCoursePage : UserControl
    {
        public ChooseCoursePage(Student student)
        {
            InitializeComponent();
            DataContext = new ChooseCoursePageViewModel(student);
        }
    }
}