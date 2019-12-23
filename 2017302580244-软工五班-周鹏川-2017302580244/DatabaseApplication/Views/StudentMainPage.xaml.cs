using DatabaseApplication.DataBase;
using DatabaseApplication.UserControls;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace DatabaseApplication.Views
{
    /// <summary>
    /// StudentMainPage.xaml 的交互逻辑
    /// </summary>
    public partial class StudentMainPage : Page
    {
        public static Snackbar Snackbar;
        private Student student;

        public StudentMainPage(Student student)
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
            }).ContinueWith(t =>
            {
                MainSnackbar.MessageQueue.Enqueue("Welcome to Educational Management System");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            Snackbar = MainSnackbar;
            this.student = student;
            DataContext = new ViewModels.StudentMainPageViewModel(MainSnackbar.MessageQueue, student);
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new MessageDialog
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };

            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDialog samMessageDialog = new ConfirmDialog
            {
                Message = { Text = "Do you really want to exit?" }
            };
            var result = await DialogHost.Show(samMessageDialog);
            if (Equals(result, true))
            {
                Application.Current.MainWindow.Close();
            }
        }
    }
}