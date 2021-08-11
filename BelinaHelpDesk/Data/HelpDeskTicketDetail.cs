using System;

#nullable disable

namespace BelinaHelpDesk.Data
{
    public partial class HelpDeskTicketDetail
    {
        public int Id { get; set; }
        public int HelpDeskTicketId { get; set; }
        public DateTime TicketDetailDate { get; set; }
        public string TicketDescription { get; set; }

        public virtual HelpDeskTicket HelpDeskTicket { get; set; }
    }
}
