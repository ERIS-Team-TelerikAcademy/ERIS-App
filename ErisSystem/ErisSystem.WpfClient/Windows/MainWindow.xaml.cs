namespace ErisSystem.WpfClient
{
    using Windows;
    using System.Windows;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var chatWindow = new ChatWindow();
            chatWindow.Show();
            this.Close();
        }
    }
}
