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
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void OnRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            // Be lazy and just open the website ? :D
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                var chatWindow = new ChatWindow(this.UserName.Text);
                chatWindow.Show();
                this.Close();
            }
            else
            {
                var messageBox = new CustomMessageBox("Invalid user name or password");
                messageBox.ShowDialog();
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Style _style = null;

                _style = (Style)Resources["GadgetStyle"];
       
            this.Style = _style;
        }
    }
}
