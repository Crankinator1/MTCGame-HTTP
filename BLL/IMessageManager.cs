using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTCGame.Models;

namespace MTCGame.BLL
{
    internal interface IMessageManager
    {
        IEnumerable<Message> ListMessages(User user);
        Message AddMessage(User user, string content);
        void RemoveMessage(User user, int messageId);
        Message ShowMessage(User user, int messageId);
        void UpdateMessage(User user, int messageId, string content);
    }
}
