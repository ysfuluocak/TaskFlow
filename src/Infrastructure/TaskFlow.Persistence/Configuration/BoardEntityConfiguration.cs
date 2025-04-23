using TaskFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Description)
            .HasMaxLength(2000);

        builder.HasOne(b => b.CreatedBy)
            .WithMany(u => u.BoardsCreated)
            .HasForeignKey(b => b.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.Steps)
            .WithOne(bs => bs.Board)
            .HasForeignKey(bs => bs.BoardId)
            .OnDelete(DeleteBehavior.Cascade); // Board silindiğinde Steps silinsin

        builder.HasMany(b => b.Tasks)
            .WithOne(t => t.Board)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Cascade);  // Board silindiğinde Tasks silinsin

        builder.ToTable("Boards");
    }
}
