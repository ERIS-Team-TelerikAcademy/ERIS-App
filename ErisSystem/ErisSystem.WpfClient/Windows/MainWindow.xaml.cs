namespace ErisSystem.WpfClient
{
    using Windows;
    using System.Windows;
    using System.Net;
    using System.Text;
    using System.IO;
    using System;

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
            var postData = "grant_type=password";
            postData += "&username=" + this.UserName.Text;
            postData += "&password=" + this.Password.Password;

            var data = Encoding.ASCII.GetBytes(postData);
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:28499/Token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var responseString = string.Empty;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (responseString != "")
            {
                var chatWindow = new ChatWindow(this.UserName.Text);
                chatWindow.Show();
                this.Close();
            }
            else
            {
                var messageBox = new CustomMessageBox("Invalid user name or password");
                messageBox.ShowDialog();
                this.UserName.Text = "";
                this.Password.Password = "";
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
