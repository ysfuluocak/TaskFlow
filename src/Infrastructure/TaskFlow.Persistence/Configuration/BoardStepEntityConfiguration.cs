using TaskFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BoardStepEntityConfiguration : IEntityTypeConfiguration<BoardStep>
{
    public void Configure(EntityTypeBuilder<BoardStep> builder)
    {
        builder.HasKey(bs => bs.Id);

        builder.Property(bs => bs.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(bs => bs.Order)
            .IsRequired();

        builder.HasOne(bs => bs.Board)
            .WithMany(b => b.Steps)
            .HasForeignKey(bs => bs.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(bs => bs.Tasks)
            .WithOne(t => t.StatusStep)
            .HasForeignKey(t => t.StatusStepId)
            .OnDelete(DeleteBehavior.SetNull);  // Task silindiğinde StatusStep silinmesin

        builder.ToTable("BoardSteps");
    }
}
