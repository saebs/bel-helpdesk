using System;
using System.Linq;
using System.Threading.Tasks;
using BelinaHelpDesk.Data;
using BelinaHelpDesk.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BelinaHelpDesk
{
    public class BelinaHelpDeskService
    {
        private readonly BelinaHelpDeskContext _context;

        public BelinaHelpDeskService(
            BelinaHelpDeskContext context)
        {
            _context = context;
        }

        public IQueryable<HelpDeskTicket>
            GetHelpDeskTickets()
        {
            // Return all HelpDesk Tickets as IQueryable
            // SfGrid will use this to only pull records 
            // for the page that it is currently displaying
            // Note: AsNoTracking() is used because it is 
            // quicker to execute and we do not need
            // Entity Framework change tracking at this point
            return _context.HelpDeskTickets.AsNoTracking();
        }

        public async Task<HelpDeskTicket>
            GetHelpDeskTicketAsync(string HelpDeskTicketGuid)
        {
            // Get the existing record
            var ExistingTicket = await _context.HelpDeskTickets
                // .Include(x => x.HelpDeskTicketDetails)
                .Where(x => x.TicketGuid == HelpDeskTicketGuid)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return ExistingTicket;
        }

        public Task<HelpDeskTicket>
            CreateTicketAsync(HelpDeskTicket newHelpDeskTickets)
        {
            try
            {
                // Add a new Help Desk Ticket
                _context.HelpDeskTickets.Add(newHelpDeskTickets);
                _context.SaveChanges();

                return Task.FromResult(newHelpDeskTickets);
            }
            catch (Exception ex)
            {
                DetachAllEntities();
                throw ex;
            }
        }

        public Task<bool>
            UpdateTicketAsync(
            HelpDeskTicket UpdatedHelpDeskTickets)
        {
            try
            {
                // Get the existing record
                var ExistingTicket =
                    _context.HelpDeskTickets
                    .Where(x => x.Id == UpdatedHelpDeskTickets.Id)
                    .FirstOrDefault();

                if (ExistingTicket != null)
                {
                    ExistingTicket.TicketDate =
                        UpdatedHelpDeskTickets.TicketDate;

                    ExistingTicket.TicketDescription =
                        UpdatedHelpDeskTickets.TicketDescription;

                    ExistingTicket.TicketGuid =
                        UpdatedHelpDeskTickets.TicketGuid;

                    ExistingTicket.TicketRequesterEmail =
                        UpdatedHelpDeskTickets.TicketRequesterEmail;

                    ExistingTicket.TicketStatus =
                        UpdatedHelpDeskTickets.TicketStatus;                    

                    // Insert any new TicketDetails
                    // if (UpdatedHelpDeskTickets.HelpDeskTicketDetails != null)
                    // {
                    //     foreach (var item in 
                    //         UpdatedHelpDeskTickets.HelpDeskTicketDetails)
                    //     {
                    //         if(item.Id == 0)
                    //         {
                    //             // Create New HelpDeskTicketDetails record
                    //             HelpDeskTicketDetail newHelpDeskTicketDetails = 
                    //                 new HelpDeskTicketDetail();
                    //             newHelpDeskTicketDetails.HelpDeskTicketId = 
                    //                 UpdatedHelpDeskTickets.Id;
                    //             newHelpDeskTicketDetails.TicketDetailDate = 
                    //                 DateTime.Now;
                    //             newHelpDeskTicketDetails.TicketDescription = 
                    //                 item.TicketDescription;
                    //
                    //             _context.HelpDeskTicketDetails
                    //                 .Add(newHelpDeskTicketDetails);
                    //         }
                    //     }
                    // }

         
                    _context.SaveChanges();
                }
                else
                {
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                DetachAllEntities();
                throw ex;
            }
        }

        public Task<bool>
            DeleteHelpDeskTicketsAsync(
            HelpDeskTicket DeleteHelpDeskTickets)
        {
            // Get the existing record
            var ExistingTicket =
                _context.HelpDeskTickets
                // .Include(x => x.HelpDeskTicketDetails)
                .Where(x => x.Id == DeleteHelpDeskTickets.Id)
                .FirstOrDefault();

            if (ExistingTicket != null)
            {
                // Delete the Help Desk Ticket
                _context.HelpDeskTickets.Remove(ExistingTicket);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        // Utility

        #region public void DetachAllEntities()
        public void DetachAllEntities()
        {
            // When we have an error we need 
            // to remove EF Core change tracking
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        #endregion

    }
}