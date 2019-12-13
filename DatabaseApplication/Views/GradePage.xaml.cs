using DatabaseApplication.DataBase;
using DatabaseApplication.ViewModels;
using System.Windows.Controls;

namespace DatabaseApplication.Views
{
    /// <summary>
    /// GradePage.xaml 的交互逻辑
    /// </summary>
    public partial class GradePage : UserControl
    {
        public GradePage(Student student)
        {
            InitializeComponent();
            DataContext = new GradePageViewModel(student);
        }
    }
}
