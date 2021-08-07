using System;

namespace BelinaHelpDesk.Data
{
    public class HelpDeskTicketDetail
    {
        public int Id { get; set; }
        
        public int HelpDeskTicketId { get; set; }
        
        public DateTime TicketDetailDate { get; set; }
        
        public string TicketDescription { get; set; }
    }
}