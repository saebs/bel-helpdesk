using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace BelinaHelpDesk.Data.Models
{
    public partial class HelpDeskTicket
    {
        public HelpDeskTicket()
        {
        }

        public int Id { get; set; }
        [Required]
        public string TicketStatus { get; set; }
        [Required]
        public DateTime TicketDate { get; set; }
        
        [StringLength(50, MinimumLength = 2,
            ErrorMessage =
                "Description must be a minimum of 2 and maximum of 50 characters.")]
        public string TicketDescription { get; set; }
        [EmailAddress]
        public string TicketRequesterEmail { get; set; }
        public string TicketGuid { get; set; }
        public IQueryable HelpDeskTicketDetails { get; }
    }
}
