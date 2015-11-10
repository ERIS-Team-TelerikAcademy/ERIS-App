namespace ErisSystem.WpfClient.Windows
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Text;
    using System.Windows.Media;
    using System.Collections;
    using IronMQ;
    using System;
    using IronMQ.Data;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private string userName;

        private const int port = 54545;

        private const string broadcastAddress = "mq-aws-eu-west-1-1.iron.io";

        private Thread receivingThread;

        private delegate void AddMessage(string message);

        public ChatWindow(string userName)
        {
            this.KeyDown += HandleKeyDown;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.userName = userName;
            this.InitializeReceiver();
            InitializeComponent();
            this.SendingTest("Hello there");
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

                SendingTest(messageData);

                //string toSend = messageData;
                //byte[] data = Encoding.ASCII.GetBytes(toSend);

                //var ipAddress = Dns.GetHostEntry("localhost").AddressList[1];

                //var endpoint = new IPEndPoint(IPAddress.Parse(broadcastAddress), port);
                //var sender = (EndPoint)endpoint;
                //var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //if (!socket.Connected)
                //{
                //    socket.Connect(sender);
                //}

                //try
                //{
                //    socket.Send(data);
                //}
                //catch (SocketException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
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

        private void InitializeReceiver()
        {
            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.SetApartmentState(ApartmentState.STA);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        //private void Receiver()
        //{
        //    AddMessage messageDelegate = MessageReceived;

        //    var ipAddress = Dns.GetHostEntry("localhost").AddressList[1];
        //    IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        //    var sender = (EndPoint)endPoint;

        //    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    socket.Bind(endPoint);
        //    socket.Listen(500);
        //    var data = new byte[2000];
        //    while (true)
        //    {
        //        var connector = socket.Accept();
        //        var dataLength = connector.Receive(data);
        //        string message = Encoding.ASCII.GetString(data, 0, dataLength);
        //        Dispatcher.Invoke(messageDelegate, message);
        //    }
        //}

        private void MessageReceived(string message)
        {
            var messageBackgroundColor = Brushes.LightSkyBlue;
            this.InsertMessageInChatBox(message, messageBackgroundColor);
        }

        private void SendingTest(string messageToSend)
        {
            Client client = new Client(
                              "56420b6f9195a800080000b6",
                              "ANgrGMpOtkzSxbTIlWbk"
                              );
            IronMQ.Queue queue = client.Queue("Some");

            queue.Push(messageToSend);
        }


        private void Receiver()
        {
            AddMessage messageDelegate = MessageReceived;

            Client client = new Client(
                              "56420b6f9195a800080000b6",
                              "ANgrGMpOtkzSxbTIlWbk"
                              );

            IronMQ.Queue queue = client.Queue("Some");
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    queue.DeleteMessage(msg);
                    if(msg.Body.Split(':')[0] != this.userName)  //Fixes self spaming 
                    {
                        Dispatcher.Invoke(messageDelegate, msg.Body);
                    }

                }
                Thread.Sleep(300);
            }
        }
    }
}
