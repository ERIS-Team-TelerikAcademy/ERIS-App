namespace ErisSystem.WpfClient
{
    using Windows;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;

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
            var chatWindow = new ChatWindow(this.UserName.Text);
            chatWindow.Show();
            this.Close();
        }

        private void Field_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var field = sender as TextBox;
            field.Text = "";
        }

        private void Password_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var field = sender as TextBox;
            field.Text = "";
        }
    }
}
