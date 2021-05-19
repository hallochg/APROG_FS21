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
using System.IO;

namespace SW11_ChatClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private MyChatClient client;
        private List<string> Users;
        private StreamWriter sw;
        private StreamReader sr;

        private readonly string pathUserFile = "User.txt";

        public MainWindow() {
            InitializeComponent();
            this.Users = new List<string>();
            try {
                sr = new StreamReader(pathUserFile);
                string[] line = sr.ReadLine().Split(':');
                textBox_Host.Text = line[0];
                textBox_UserName.Text = line[1];
                sr.Close();

            } catch (Exception) {
                sr?.Close();
            }
        }


        private void Button_Login_Click(object sender, RoutedEventArgs e) {
            try {
                if (textBox_Host.Text == "") {
                    MessageBox.Show("Type in a Host!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } else if (textBox_UserName.Text == "") {
                    MessageBox.Show("Type in a User Name!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } else {
                    client = new MyChatClient(textBox_Host.Text);
                    client.MessageReceived += Client_MessageReceived;
                    client.UserUpdate += Client_UserUpdate;
                    Thread.Sleep(500);
                    client?.Login(textBox_UserName.Text);
                    Button_Login.IsEnabled = false;
                    sw = new StreamWriter("User.txt");
                    sw.WriteLine($"{textBox_Host.Text}:{textBox_UserName.Text}");
                    sw.Flush();
                    sw.Close();
                }
            }catch (Exception error) {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Client_UserUpdate(object sender, UserUpdateEventArgs e) {
            Dictionary<string, List<string>> UserChanges = compareUsers(Users, e.Users.ToList<string>());
            this.Users = e.Users.ToList<string>();
            Dispatcher.BeginInvoke(new Action(delegate () {
                foreach(string d in UserChanges["deleted"]) {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Content = d;
                    ListView_Users.Items.RemoveAt(ListView_Users.Items.IndexOf(lvi));
                }
                foreach(string u in UserChanges["added"]) {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Content = u;
                    ListView_Users.Items.Add(lvi);
                }
            }));
        }

        private void Client_MessageReceived(object sender, MessageReceivedEventArgs e) {
            Dispatcher.BeginInvoke(new Action(delegate () {
                this.TextBox_Messages.Text += e.Message + "\r\n";
            }));
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        private Dictionary<string, List<string>> compareUsers(List<string> old_users, List<string> new_users) {
            List<string> deletedUsers = old_users.Except(new_users).ToList();
            List<string> addedUsers = new_users.Except(old_users).ToList();
            return new Dictionary<string, List<string>>() { { "deleted", deletedUsers }, { "added", addedUsers } };
        }

        
        

        private void SendMessage() {
            ListViewItem liv = ListView_Users.SelectedItem as ListViewItem;
            if(liv == null) {
                MessageBox.Show("You need to send the messages to somebody!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                client.SendMessage(liv.Content.ToString(), TextBox_Send.Text);
                TextBox_Send.Text = "";
            }
        }

        private void TextBox_Send_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key.Equals(Key.Enter)) {
                SendMessage();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            try {
                client.Disconnect();
            }catch(Exception exp) {
                MessageBox.Show(exp.Message, "error", MessageBoxButton.OK);
            }
        }
    }
}
