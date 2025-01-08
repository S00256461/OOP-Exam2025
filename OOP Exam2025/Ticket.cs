using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Exam2025
{
    public class Ticket
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }

        public override string ToString()
        {
            return $"{Name} - €{Price} [AVAILABLE - {AvailableTickets}]";
        }
    }
}

