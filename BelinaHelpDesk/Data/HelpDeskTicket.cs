using System;
using System.ComponentModel.DataAnnotations;

namespace BelinaHelpDesk.Data
{
    public class HelpDeskTicket
    {
        
        public int Id { get; set; }
        
        [StringLength(50)]
        public string TicketStatus { get; set; }
        
        public DateTime TicketDate { get; set; }
        
        public string TicketDescription { get; set; }
        
        [StringLength(500)]
        public string TicketRequesterEmail { get; set; }
        
        [StringLength(500)]
        public string TicketGUID { get; set; }
    }
}