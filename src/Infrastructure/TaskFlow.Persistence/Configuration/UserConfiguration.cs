using TaskFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskFlow.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IHashingHelper _hashingHelper;

        public UserConfiguration(IHashingHelper hashingHelper)
        {
            _hashingHelper = hashingHelper;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasMany(u => u.BoardsCreated)
                .WithOne(b => b.CreatedBy)
                .HasForeignKey(b => b.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.TasksAssigned)
                .WithOne(t => t.AssignedTo)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.TasksCreated)
                .WithOne(t => t.AssignedBy)
                .HasForeignKey(t => t.AssignedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.TaskComments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(getSeeds());
        }
        private IEnumerable<User> getSeeds()
        {
            List<User> users = new();

            _hashingHelper.CreatePasswordHash(
                password: "Passw0rd",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User adminUser =
                new()
                {
                    FirstName = "Admin",
                    LastName = "NArchitecture",
                    Email = "admin@admin.com",
                    Status = true,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
            users.Add(adminUser);

            return users.ToArray();
        }
    }
}
