using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ErisSystem.WpfClient.Windows
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            InitializeComponent();
        }

        private void ChatButtonSend_Click(object sender, RoutedEventArgs e)
        {
            var msg = this.ChatTxtBox.Text;

            InsertMessageInChatBox("SomeGuy", msg);
        }

        private void InsertMessageInChatBox(string user, string message)
        {
            ListBoxItem itm = new ListBoxItem();
            itm.FontSize = 26;
            itm.Content = user + ": " + message;
            this.ChatMessages.Items.Add(itm);
        }
    }
}
