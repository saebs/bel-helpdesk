using System;

#nullable disable

namespace BelinaHelpDesk.Data.Models
{
    public partial class HelpDeskTicketDetail
    {
        public int Id { get; set; }
        public int HelpDeskTicketId { get; set; }
        public DateTime TicketDetailDate { get; set; }
        public string TicketDescription { get; set; }

    }
}
