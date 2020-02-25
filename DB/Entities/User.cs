using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public NotificationMode NotificationMode { get; set; }

        public List<Accident> Accidents { get; set; }
    }
}
