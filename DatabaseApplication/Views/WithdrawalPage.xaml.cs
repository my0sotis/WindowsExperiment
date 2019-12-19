using DatabaseApplication.DataBase;
using DatabaseApplication.ViewModels;
using System.Windows.Controls;

namespace DatabaseApplication.Views
{
    /// <summary>
    /// WithdrawalPage.xaml 的交互逻辑
    /// </summary>
    public partial class WithdrawalPage : UserControl
    {
        public WithdrawalPage(Student student)
        {
            InitializeComponent();
            DataContext = new WithdrawalPageViewModel(student);
        }
    }
}