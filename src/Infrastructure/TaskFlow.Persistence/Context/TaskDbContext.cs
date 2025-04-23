using System.Reflection;
using TaskFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Persistence.Context;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<TaskEntity> TaskEntities { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<BoardStep> BoardSteps { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}