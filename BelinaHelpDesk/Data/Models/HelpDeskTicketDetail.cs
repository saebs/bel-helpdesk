using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BelinaHelpDesk.Data.Models
{
    public partial class HelpDeskTicketDetail
    {
        public int Id { get; set; }
        [Required]
        public int HelpDeskTicketId { get; set; }
        [Required]
        public DateTime TicketDetailDate { get; set; }
        [Required]
        [StringLength(500)]
        public string TicketDescription { get; set; }
        
        public virtual HelpDeskTicket HelpDeskTicket { get; set; }

    }
}
