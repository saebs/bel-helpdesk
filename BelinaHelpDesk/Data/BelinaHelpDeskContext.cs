using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BelinaHelpDesk.Data
{
    public class BelinaHelpDeskContext : IdentityDbContext
    {
        public DbSet<HelpDeskTicket> HelpDeskTickets { get; set; }

        public DbSet<HelpDeskTicketDetail> HelpDeskTicketDetails { get; set; }
        public BelinaHelpDeskContext(DbContextOptions<BelinaHelpDeskContext> options)
            : base(options)
        {
        }
    }
}