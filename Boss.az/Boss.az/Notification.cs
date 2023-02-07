using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    enum status {unread = 1,readed};
    internal class Notification
    {
        public int Id { get; set; }
        public static int StaticId = 1;
        public string? Text { get; set; }
        public Worker? Worker { get; set; }
        public Vacancy? Vacancy { get; set; }
        public DateTime DateTime { get; set; }
        public status Status = status.unread;
        public bool AcceptOrNot { get; set; }

        public Notification()
        {
            Id = StaticId++;
        }

        public Notification(string? text,Worker worker,Vacancy vacancy)
        {
            Id = StaticId++;
            Text = text;
            Worker = worker;
            Vacancy = vacancy;
            DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Notification Id: {Id} \nFrom: {Worker} \nText: {Text} \nStatus: {Status}";
        }
    }
}
