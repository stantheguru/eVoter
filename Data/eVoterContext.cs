using eVoter.Areas.Identity.Data;
using eVoter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eVoter.Data;
public class CustomUserRole : IdentityUserRole<string> { }
public class eVoterContext : IdentityDbContext
{
    public eVoterContext(DbContextOptions<eVoterContext> options)
        : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<Voter>
{
    public void Configure(EntityTypeBuilder<Voter> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.vote_status).HasMaxLength(255);
    }
}