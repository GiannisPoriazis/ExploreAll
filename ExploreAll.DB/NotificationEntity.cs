using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreAll.DB
{
    public class NotificationEntity
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public bool ContainsEmptyValue
        {
            get
            {
                return string.IsNullOrEmpty(Sender) || string.IsNullOrEmpty(Message) || string.IsNullOrEmpty(Date);
            }
        }

        public NotificationEntity(string sender, string title, string message, string date = null, int id = 0)
        {
            ID = id;
            Sender = sender;
            Title = title;
            Message = message;
            if (string.IsNullOrEmpty(date))
            {
                Date = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                Date = date;
            }
        }
    }
}
