namespace ErisSystem.WpfClient.Windows
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Text;
    using System.Reflection;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private string userName;
        const int port = 54545;

        const string broadcastAddress = "255.255.255.255";
        UdpClient receivingClient;
        UdpClient sendingClient;
        Thread receivingThread;
        delegate void AddMessage(string message);
       
        public ChatWindow(string userName)
        {
            this.KeyDown += HandleKeyDown;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.userName = userName;
            this.InitializeSender();
            this.InitializeReceiver();
            InitializeComponent();
            this.UserNameLabel.Content = userName;
        }

        private void ChatButtonSend_Click(object sender, RoutedEventArgs e)
        {
            this.BuildSendRequest();
        }

        private void HandleKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
            {
                this.BuildSendRequest();
            }
        }

        private void BuildSendRequest() //Bad name but who cares
        {
            var msg = this.ChatTxtBox.Text;
            if (msg.Length != 0)
            {
                var messageBackgroundColor = Brushes.LightGray;
                var messageData = this.userName + ": " + msg;

                this.InsertMessageInChatBox(messageData, messageBackgroundColor);

                string toSend = messageData;
                byte[] data = Encoding.ASCII.GetBytes(toSend);
                sendingClient.Send(data, data.Length);
            }
        }

        private void InsertMessageInChatBox(string message, SolidColorBrush brush)
        {
            ListBoxItem item = new ListBoxItem();
            item.FontSize = 26;
            item.Background = brush;
            item.Content = message;
            this.ChatMessages.Items.Add(item);
            this.ChatTxtBox.Text = "";
        }
        
        //Sends the msg to a given recever 
        private void InitializeSender()
        {
            sendingClient = new UdpClient(broadcastAddress, port);
            sendingClient.EnableBroadcast = true;
        }

        //Receves a msg from a given send... this is pointless
        private void InitializeReceiver()
        {
            receivingClient = new UdpClient(port);
            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.SetApartmentState(ApartmentState.STA);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void Receiver()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            AddMessage messageDelegate = MessageReceived;
            while (true)
            {
                byte[] data = receivingClient.Receive(ref endPoint);
                string message = Encoding.ASCII.GetString(data);
                Dispatcher.Invoke(messageDelegate, message);
            }
        }

        private void MessageReceived(string message)
        {
            var messageBackgroundColor = Brushes.LightSkyBlue;
            this.InsertMessageInChatBox(message, messageBackgroundColor);
        }
    }
}
