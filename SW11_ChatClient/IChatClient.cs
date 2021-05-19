using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatClientLib;

namespace SW11_ChatClient
{
    public interface IChatClient
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
        event EventHandler<UserUpdateEventArgs> UserUpdate;

        void SendMessage(string toUser, string message);

        bool Login(string user);

        void Disconnect();
    }
}
