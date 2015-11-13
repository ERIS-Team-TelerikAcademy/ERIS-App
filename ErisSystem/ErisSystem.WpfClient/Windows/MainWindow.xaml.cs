namespace ErisSystem.WpfClient
{
    using Windows;
    using System.Windows;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System;
    using System.Net.Http.Headers;

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
            var userNickname = "BaiIvan";
            var userPassword = "Guest";
            var messageBox = new CustomMessageBox();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:28499/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/hitmen/1").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<object>().Result;
                var chatWindow = new ChatWindow(userNickname);
                chatWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
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
