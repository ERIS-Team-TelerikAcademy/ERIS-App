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
    /// Interaction logic for CreateRoomWindow.xaml
    /// </summary>
    public partial class CreateRoomWindow : Window
    {
        public CreateRoomWindow()
        {
            InitializeComponent();
            this.RoomName = string.Empty;
        }

        public string RoomName { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.RoomName = this.TextBox.Text;
            this.Close();
        }
    }
}
