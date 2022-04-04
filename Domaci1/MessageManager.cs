using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    static class MessageManager
    {
        public delegate void MessageHandler(Employee sender, string message);

        public static event MessageHandler OnMessageReceived;
        
        public static void SendMessage(Employee sender, string message)
        {
            if (OnMessageReceived != null)
            {
                OnMessageReceived(sender, message);
            }
        }
    }
}
