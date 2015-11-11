namespace ErisSystem.WpfClient.Windows
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Threading;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private string userName;

        private Thread receivingThread;

        private delegate void AddMessage(string message);

        private ChatServices chatService;

        public ChatWindow(string userName)
        {
            this.KeyDown += HandleKeyDown;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.userName = userName;
            this.chatService = new ChatServices();
            this.InitializeReceiver();
            InitializeComponent();
            this.UserNameLabel.Content = userName;
            this.PopulateChatRoomContainer();
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

        private void PopulateChatRoomContainer()
        {
            var chatRooms = this.chatService.GetAllRooms();

            foreach (var room in chatRooms)
            {
                this.InsertNameInRooms(room.Name);
            }
        }

        private void InsertNameInRooms(string name) // will it be chat "rooms" idk
        {
            ListBoxItem item = new ListBoxItem();
            item.FontSize = 26;
            item.Content = name;
            this.ChatUsers.Items.Add(item);
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

        //Handling sending messages

        private void BuildSendRequest() //Bad name but who cares
        {
            var msg = this.ChatTxtBox.Text;
            if (msg.Length != 0)
            {
                var messageBackgroundColor = Brushes.LightGray;
                var messageData = this.userName + ": " + msg;

                this.InsertMessageInChatBox(messageData, messageBackgroundColor);

                SendMessage(messageData);
            }
        }

        private void SendMessage(string messageToSend)
        {
            this.chatService.Send(messageToSend);
        }

        // Handling message receiving 

        private void InitializeReceiver()
        {
            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.SetApartmentState(ApartmentState.STA);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void MessageReceived(string message)
        {
            var messageBackgroundColor = Brushes.LightSkyBlue;
            this.InsertMessageInChatBox(message, messageBackgroundColor);
        }

        private void Receiver()
        {
            AddMessage messageDelegate = MessageReceived;
            var messageCollection = this.chatService.ReceveAll();
            foreach (var message in messageCollection.Messages) //Get all the messages (turbo)
            {
                Dispatcher.Invoke(messageDelegate, message.Body);
            }

            while (true)
            {
               var msg = this.chatService.Receve();
                if (msg != null)
                {
                    if (msg.Body.Split(':')[0] != this.userName)  //Fixes self spaming 
                    {
                        Dispatcher.Invoke(messageDelegate, msg.Body);
                    }

                }

            }
        }
    }
}
