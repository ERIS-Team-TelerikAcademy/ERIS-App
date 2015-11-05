namespace ErisSystem.WpfClient.Windows
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private string userName;
        public ChatWindow(string userName)
        {
            this.KeyDown += HandleKeyDown;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.userName = userName;
            InitializeComponent();
        }

        private void ChatButtonSend_Click(object sender, RoutedEventArgs e)
        {
            var msg = this.ChatTxtBox.Text;

            InsertMessageInChatBox(this.userName, msg);
        }

        private void InsertMessageInChatBox(string user, string message)
        {
            ListBoxItem itm = new ListBoxItem();
            itm.FontSize = 26;
            itm.Content = user + ": " + message;
            this.ChatMessages.Items.Add(itm);
            this.ChatTxtBox.Text = "";
        }

        private void HandleKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
            {
                var msg = this.ChatTxtBox.Text;
                if (msg.Length != 0)
                {
                    this.InsertMessageInChatBox(this.userName, msg);
                }
            }
        }
    }
}
