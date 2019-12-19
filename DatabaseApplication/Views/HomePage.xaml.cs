using DatabaseApplication.Command;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseApplication.Views
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
        {
            Link.OpenInBrowser("https://github.com/my0sotis/WindowsExperiment");
        }

        private void EmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            Link.OpenInBrowser("mailto://1274034280@qq.com");
        }
    }
}