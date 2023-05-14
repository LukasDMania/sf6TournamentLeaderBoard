using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewLEaderboard.Models;

public partial class FgcBeTournamentDataContext : DbContext
{
    public FgcBeTournamentDataContext()
    {
    }

    public FgcBeTournamentDataContext(DbContextOptions<FgcBeTournamentDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FgcBeTournamentData;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Player__4A4E74C8775F32F5");

            entity.ToTable("Player");

            entity.Property(e => e.MainCharacter).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Result__9769020868D00540");

            entity.ToTable("Result");

            entity.Property(e => e.CharacterUsed).HasMaxLength(50);

            entity.HasOne(d => d.Player).WithMany(p => p.Results)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Player");

            entity.HasOne(d => d.Tournament).WithMany(p => p.Results)
                .HasForeignKey(d => d.TournamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Tournament");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.TournamentId).HasName("PK__Tourname__AC6313132F987370");

            entity.ToTable("Tournament");

            entity.Property(e => e.TournamentDate).HasColumnType("datetime");
            entity.Property(e => e.TournamentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
