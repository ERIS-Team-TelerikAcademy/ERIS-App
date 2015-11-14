namespace ErisSystem.WpfClient.Windows
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message)
        {
            this.Message = message;
            InitializeComponent();
            this.MessageText.Text = message;
        }

        public string Message { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
