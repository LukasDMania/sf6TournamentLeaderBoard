﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewLEaderboard.Models;

#nullable disable

namespace NewLEaderboard.Migrations
{
    [DbContext(typeof(FgcBeTournamentDataContext))]
    partial class FgcBeTournamentDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewLEaderboard.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int>("AmountFirstPlace")
                        .HasColumnType("int");

                    b.Property<int>("AmountSecondPlace")
                        .HasColumnType("int");

                    b.Property<int>("AmountThirdPlace")
                        .HasColumnType("int");

                    b.Property<string>("MainCharacter")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("WeeksCompeted")
                        .HasColumnType("int");

                    b.Property<string>("discordTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId")
                        .HasName("PK__Player__4A4E74C8775F32F5");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("NewLEaderboard.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultId"));

                    b.Property<string>("CharacterUsed")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Placing")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("ResultId")
                        .HasName("PK__Result__9769020868D00540");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Result", (string)null);
                });

            modelBuilder.Entity("NewLEaderboard.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TournamentId"));

                    b.Property<int>("ParticipantsAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("TournamentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TournamentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TournamentId")
                        .HasName("PK__Tourname__AC6313132F987370");

                    b.ToTable("Tournament", (string)null);
                });

            modelBuilder.Entity("NewLEaderboard.Models.Result", b =>
                {
                    b.HasOne("NewLEaderboard.Models.Player", "Player")
                        .WithMany("Results")
                        .HasForeignKey("PlayerId")
                        .IsRequired()
                        .HasConstraintName("FK_Result_Player");

                    b.HasOne("NewLEaderboard.Models.Tournament", "Tournament")
                        .WithMany("Results")
                        .HasForeignKey("TournamentId")
                        .IsRequired()
                        .HasConstraintName("FK_Result_Tournament");

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("NewLEaderboard.Models.Player", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("NewLEaderboard.Models.Tournament", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
