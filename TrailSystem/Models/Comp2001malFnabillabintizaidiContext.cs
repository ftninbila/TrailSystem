using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrailSystem.Models;

public partial class Comp2001malFnabillabintizaidiContext : DbContext
{
    public Comp2001malFnabillabintizaidiContext()
    {
    }

    public Comp2001malFnabillabintizaidiContext(DbContextOptions<Comp2001malFnabillabintizaidiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Trail> Trails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dist-6-505.uopnet.plymouth.ac.uk;Database=COMP2001MAL_FNabillabintizaidi;User Id=FNabillabintizaidi;Password=VapI309*;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.TrailHistory).HasName("PK__History__97A1FCDE5F0C3664");

            entity.ToTable("History", "CW1", tb => tb.HasTrigger("UpdateTrailTotalDistance"));

            entity.Property(e => e.TrailHistory)
                .ValueGeneratedNever()
                .HasColumnName("trailHistory");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profileID");
            entity.Property(e => e.TrailId).HasColumnName("trailID");

            entity.HasOne(d => d.Profile).WithMany(p => p.Histories)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK__History__profile__0F624AF8");

            entity.HasOne(d => d.Trail).WithMany(p => p.Histories)
                .HasForeignKey(d => d.TrailId)
                .HasConstraintName("FK__History__trailID__10566F31");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Profile__7D4163996E9E3E9A");

            entity.ToTable("Profile", "CW1");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedNever()
                .HasColumnName("profileID");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Profile__userID__0C85DE4D");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__2ECD6E24ED55F712");

            entity.ToTable("Review", "CW1");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("reviewID");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TrailId).HasColumnName("trailID");

            entity.HasOne(d => d.Trail).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.TrailId)
                .HasConstraintName("FK__Review__trailID__01142BA1");
        });

        modelBuilder.Entity<Trail>(entity =>
        {
            entity.HasKey(e => e.TrailId).HasName("PK__Trail__9D4BB790C263F82D");

            entity.ToTable("Trail", "CW1");

            entity.Property(e => e.TrailId)
                .ValueGeneratedNever()
                .HasColumnName("trailID");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF75528612");

            entity.ToTable("Users", "CW1");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
