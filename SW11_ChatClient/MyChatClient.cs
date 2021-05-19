using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using ChatClientLib;

namespace SW11_ChatClient {
    class MyChatClient : IChatClient {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public event EventHandler<UserUpdateEventArgs> UserUpdate;

        

        private ChatClientTcp client;
        public MyChatClient(string host) {
            client = new ChatClientTcp(host);
            client.MessageReceived += Client_MessageReceived;
            client.UserUpdate += Client_UserUpdate;

        }

        private void Client_UserUpdate(object sender, UserUpdateEventArgs e) {
            if(e.Users[0] != "") {
                UserUpdate?.Invoke(this, e);
            }
            
        }

        private void Client_MessageReceived(object sender, MessageReceivedEventArgs e) {
            MessageReceived?.Invoke(this, e);
        }

        public void Disconnect() {
            client.Disconnect();
        }

        public bool Login(string user) {
            return client.Login(user);
        }

        public void SendMessage(string toUser, string message) {
            client.SendMessage(toUser, message);
        }
    }
}
