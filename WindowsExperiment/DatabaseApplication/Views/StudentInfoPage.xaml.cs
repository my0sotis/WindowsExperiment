using DatabaseApplication.DataBase;
using DatabaseApplication.ViewModels;
using System.Windows.Controls;

namespace DatabaseApplication.Views
{
    /// <summary>
    /// StudentInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class StudentInfoPage : UserControl
    {
        public StudentInfoPage(Student student)
        {
            InitializeComponent();
            DataContext = new StudentInfoPageViewModel(student);
        }
    }
}