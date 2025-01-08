using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam2025
{
    public enum EventType
    {
        Music,
        Comedy,
        Theatre
    }

    public class Event
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets { get; set; }
        public EventType TypeOfEvent { get; set; }

        public override string ToString()
        {
            return $"{Name} - {EventDate:dd/MM/yyyy}";
        }
    }
}
