using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Identity;

namespace SupportSystemApp.Repository;

public class ApplicationDbContext : IdentityDbContext<SupportSystemAppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Ticket>()
            .HasOne(t => t.OpenedBy)
            .WithMany(u => u.OpenedTickets)
            .HasForeignKey(t => t.RequesterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Ticket>()
            .HasOne(t => t.AssignedTo)
            .WithMany(u => u.AssignedTickets)
            .HasForeignKey(t => t.TechnitianId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<TicketTask> TicketTasks { get; set; }
    public virtual DbSet<Note> Notes { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
    public virtual DbSet<Site> Sites { get; set; }
    public virtual DbSet<SupportGroup> SupportGroups { get; set; }
    public virtual DbSet<EmailMessage> EmailMessages { get; set; }
    public virtual DbSet<TicketShare> TicketShares { get; set; }
    public virtual DbSet<TaskReminder> TaskReminders { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Subcategory> SubCategories { get; set; }
    public virtual DbSet<CategoryItem> CategoryItems { get; set; }
}
