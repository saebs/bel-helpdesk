using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BelinaHelpDesk.Data
{
    public partial class BelinaHelpDeskContext : DbContext
    {
        public BelinaHelpDeskContext()
        {
        }

        public BelinaHelpDeskContext(DbContextOptions<BelinaHelpDeskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HelpDeskTicket> HelpDeskTickets { get; set; }
        public virtual DbSet<HelpDeskTicketDetail> HelpDeskTicketDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");




            modelBuilder.Entity<HelpDeskTicket>(entity =>
            {
                entity.Property(e => e.TicketDate).HasColumnType("datetime");

                entity.Property(e => e.TicketDescription).IsRequired();

                entity.Property(e => e.TicketGuid)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("TicketGUID");

                entity.Property(e => e.TicketRequesterEmail)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TicketStatus)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HelpDeskTicketDetail>(entity =>
            {
                entity.Property(e => e.TicketDescription).IsRequired();

                entity.Property(e => e.TicketDetailDate).HasColumnType("datetime");

                entity.HasOne(d => d.HelpDeskTicket)
                    .WithMany(p => p.HelpDeskTicketDetails)
                    .HasForeignKey(d => d.HelpDeskTicketId)
                    .HasConstraintName("FK_HelpDeskTicketDetails_HelpDeskTickets");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
