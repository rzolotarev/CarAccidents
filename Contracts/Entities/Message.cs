using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderUserId { get; set; }

        public int ReceiverUserId { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }
        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }
}
