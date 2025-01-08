using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam2025
{
    public class VIPTicket : Ticket
    {
        public string AdditionalExtras { get; set; }
        public decimal AdditionalCost { get; set; }

        public override string ToString()
        {
            return $"{Name} - €{Price + AdditionalCost} (VIP: {AdditionalExtras}) [AVAILABLE - {AvailableTickets}]";
        }
    }
}

