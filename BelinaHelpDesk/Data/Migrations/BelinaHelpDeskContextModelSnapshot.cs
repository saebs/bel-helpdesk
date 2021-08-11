﻿// <auto-generated />
using System;
using BelinaHelpDesk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BelinaHelpDesk.Data.Migrations
{
    [DbContext(typeof(BelinaHelpDeskContext))]
    partial class BelinaHelpDeskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BelinaHelpDesk.Data.HelpDeskTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TicketDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TicketDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TicketGuid")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("TicketGUID");

                    b.Property<string>("TicketRequesterEmail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TicketStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("HelpDeskTickets");
                });

            modelBuilder.Entity("BelinaHelpDesk.Data.HelpDeskTicketDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HelpDeskTicketId")
                        .HasColumnType("int");

                    b.Property<string>("TicketDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TicketDetailDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("HelpDeskTicketId");

                    b.ToTable("HelpDeskTicketDetails");
                });

            modelBuilder.Entity("BelinaHelpDesk.Data.HelpDeskTicketDetail", b =>
                {
                    b.HasOne("BelinaHelpDesk.Data.HelpDeskTicket", "HelpDeskTicket")
                        .WithMany("HelpDeskTicketDetails")
                        .HasForeignKey("HelpDeskTicketId")
                        .HasConstraintName("FK_HelpDeskTicketDetails_HelpDeskTickets")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HelpDeskTicket");
                });

            modelBuilder.Entity("BelinaHelpDesk.Data.HelpDeskTicket", b =>
                {
                    b.Navigation("HelpDeskTicketDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
