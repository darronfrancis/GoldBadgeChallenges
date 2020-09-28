using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class Outing
    {
        public enum Type { amusementPark, bowling, concert, golf };
        public Type EventType { get; set; }
        public DateTime Date { get; set; }
        public int Attendance { get; set; }
        public decimal Ticket { get; set; }

        public Outing() { }

        public Outing(Type eventType, DateTime date, int attendance, decimal ticket)
        {
            EventType = eventType;
            Date = date;
            Attendance = attendance;
            Ticket = ticket;
        }
    }
}
