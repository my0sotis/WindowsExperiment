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
using DatabaseApplication.UserControls;

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

        [Obsolete("Cannot Use that Progress Box!", true)]
        private void Button_Click_Progress(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                await Login.ShowDialog(new ProgressBox(), new DialogOpenedEventHandler((object Psender, DialogOpenedEventArgs args) =>
                {
                    Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith((t, _) =>
                    {
                        try
                        {
                            var db = new DBService();
                            if (db.Verify(Account.Text, Password.Password))
                            {
                                ChangePage.Content = new Frame()
                                { Content = new StudentMainPage(db.GetStudentByAccountAndPassword(Account.Text, Password.Password)) };
                                args.Session.Close(false);
                            }
                            else
                            {
                                args.Session.Close(false);
                                ShowMessageInfo("Your account name or password is incorrect!");
                            }

                        }
                        catch (Exception)
                        {
                            args.Session.Close(false);
                            ShowMessageInfo("登陆失败!");
                        }
                    }, null,
                    TaskScheduler.FromCurrentSynchronizationContext());
                }));
            });
        }
    }
}
