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

        private delegate void AwaitServerResponse();

        private ChatServices chatService;

        public ChatWindow(string userName)
        {
            this.KeyDown += HandleKeyDown;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.userName = userName;
            this.chatService = new ChatServices();
            this.InitializeReceiver();
            InitializeComponent();
            this.ChatUsers.PreviewMouseDown += HandleClickOnName;
            this.UserNameLabel.Content = userName;
            this.PopulateChatRoomContainer();
        }

        private void ChatButtonSend_Click(object sender, RoutedEventArgs e)
        {
            this.SendMessageData();
        }

        private void HandleKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
            {
                this.SendMessageData();
            }
        }

        private void HandleClickOnName(object sender, RoutedEventArgs e)
        {
            var room = ItemsControl.ContainerFromElement(this.ChatUsers, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (room != null)
            {
                var roomName = room.Content.ToString();
                if (roomName == "Create Room")
                {
                    this.CreateNewRoom();
                }
                else
                {
                    this.chatService.SwitchRoom(roomName);
                    this.ChatMessages.Items.Clear();
                }

            }
        }

        private void CreateNewRoom()
        {
            var roomCreateWindow = new CreateRoomWindow();
            roomCreateWindow.ShowDialog();
            var a = roomCreateWindow.RoomName;
            if (a.Length != 0)
            {
                this.chatService.SwitchRoom(a);
                this.ChatUsers.Items.Clear();
                this.PopulateChatRoomContainer();
            }

        }

        private void PopulateChatRoomContainer()
        {
            var chatRooms = this.chatService.GetAllRooms();
            foreach (var room in chatRooms)
            {
                this.InsertNameInRooms(room.Name, Brushes.White);
            }

            this.InsertNameInRooms("Create Room", Brushes.Red);
        }

        private void InsertNameInRooms(string name, SolidColorBrush brush) // will it be chat "rooms" idk
        {
            ListBoxItem item = new ListBoxItem();
            item.FontSize = 20;
            item.Background = brush;
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

        private void SendMessageData()
        {
            var msg = this.ChatTxtBox.Text;
            if (msg.Length != 0)
            {
                var messageData = this.userName + ": " + msg;
                this.chatService.Send(messageData);
            }
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
            var messageBackgroundColor = new SolidColorBrush();
            if (message.Split(':')[0] == this.userName)
            {
                messageBackgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FB6653"));
            }
            else
            {
                messageBackgroundColor = Brushes.LightGray;
            }

            this.InsertMessageInChatBox(message, messageBackgroundColor);
        }

        private void Receiver()
        {
            AddMessage messageDelegate = MessageReceived;
            //var messageCollection = this.chatService.ReceveAll();
            //foreach (var message in messageCollection.Messages) //Get all the messages (turbo)
            //{
            //    Dispatcher.Invoke(messageDelegate, message.Body);
            //}

            while (true)
            {
                var msg = this.chatService.Receve();
                if (msg != null)
                {
                    Dispatcher.Invoke(messageDelegate, msg.Body);
                }

            }
        }
    }
}
