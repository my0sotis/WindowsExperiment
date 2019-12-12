using DatabaseApplication.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DatabaseApplication.DataBase;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using DatabaseApplication.ViewModels;
using System.Threading;

namespace DatabaseApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Set Background Image
            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Source/login_bg.jpg"));
            image.Stretch = Stretch.UniformToFill;
            Background = image;

            InitializeComponent();

        }

        private async void ShowMessageInfo(string message)
        {
            UserControls.MessageDialog samMessageDialog = new UserControls.MessageDialog
            {
                Message = { Text = message }
            };
            await MessageBox.ShowDialog(samMessageDialog);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new DBService();
            if (db.Verify(Account.Text, Password.Password))
            {
                ChangePage.Content = new Frame()
                { Content = new StudentMainPage(db.GetStudentByAccountAndPassword(Account.Text, Password.Password)) };
            }
            else
            {
                ShowMessageInfo("Your account name or password is incorrect!");
            }
        }
    }
}
