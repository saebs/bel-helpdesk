using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BelinaHelpDesk.Data
{
    public class BelinaHelpDeskContext : IdentityDbContext
    {

        public BelinaHelpDeskContext(DbContextOptions<BelinaHelpDeskContext> options)
            : base(options)
        {
        }
    }
}