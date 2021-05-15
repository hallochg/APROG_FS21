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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClientLib;
using System.Threading;

namespace SW11_ChatClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private IChatClient client;
        public MainWindow() {
            InitializeComponent();
        }


        private void Client_MessageReceived(object sender, MessageReceivedEventArgs e) {
            Dispatcher.BeginInvoke(new Action(delegate () {
                this.TextBox_Messages.Text += e.Message+"\r\n";
            }));
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e) {
            try {
                if (textBox_Host.Text == "") {
                    MessageBox.Show("Type in a Host!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } else if (textBox_UserName.Text == "") {
                    MessageBox.Show("Type in a User Name!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } else {
                    client = new ChatClientTcp(textBox_Host.Text);
                    client.MessageReceived += Client_MessageReceived;
                    Thread.Sleep(500);
                    client.Login(textBox_UserName.Text);
                    Button_Login.IsEnabled = false;
                }
            }catch (Exception error) {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Send_Click(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        

        private void SendMessage() {
            if (TextBox_ChatPartner.Text == "") {
                MessageBox.Show("You need to send the messages to somebody!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                string message_send = TextBox_Send.Text;
                TextBox_Send.Text = "";
                client.SendMessage(TextBox_ChatPartner.Text, message_send);
            }
        }

        private void TextBox_Send_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key.Equals(Key.Enter)) {
                SendMessage();
            }
        }
    }
}
