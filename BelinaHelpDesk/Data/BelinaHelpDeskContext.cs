using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BelinaHelpDesk.Data
{
    public class BelinaHelpDeskContext : DbContext
    {

        public DbSet<HelpDeskTicket> HelpDeskTickets { get; set; }

        public DbSet<HelpDeskTicketDetail> HelpDeskTicketDetails { get; set; }

        public BelinaHelpDeskContext(DbContextOptions<BelinaHelpDeskContext> options)
        : base(options)
        {
            
        }
       
    }
        
}