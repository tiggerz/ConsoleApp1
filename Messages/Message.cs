using System;
using System.Collections.Generic;
using System.Text;

namespace Messages
{
    public class Message
    {
        public Message(int id,string name,DateTime createdDate)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
